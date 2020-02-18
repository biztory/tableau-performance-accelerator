using Biztory.EnterpriseToolkit.TableauServer.Models;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Api;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Client;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Model;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Biztory.EnterpriseToolkit.TableauServer
{
    /// <summary>
    /// Tableau Tableau Performance Accelerator. Given a Tableau Server site, it caches the living daylights out of it.
    /// </summary>
    public partial class TableauPerformanceAccelerator
    {
        static ILogger logger = ApplicationLogging.LoggerFactory.CreateLogger<TableauPerformanceAccelerator>();

        // Assumes a four-core machine, in other words
        const int DEFAULT_PARALLELISM = 4;
        // We presume that slow dashboards are slow
        const int DEFAULT_REQUEST_TIMEOUT_IN_SECONDS = 60;
        // We should default to waiting just a _little_ before resuming our spamming
        const int DEFAULT_THINK_TIME_IN_MILLISECONDS = 1;
        const string USER_AGENT = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36";
        private const string SITE_VIEWS_FIELD_LIST = "view.id,view.name,project.id,project.name,workbook.id,workbook.name,contentUrl,tags,workbook.tags";

        private int parallelThreads;
        private int requestTimeoutInSeconds;
        private int thinkTimeInMilliseconds;
        private SecureString serviceAccountUserToken;
        private NetworkCredential tableauServerCredentials;
        private ViewRequestMode viewRequestMode;
        private Uri tableauServerUri;

        /// <summary>
        /// The content URL (aka what the Server UI calls the Site ID)
        /// </summary>
        private string contentUrl;

        // The Default site has an empty "content URL". 
        private string siteUIIDForDisplay { get { return contentUrl == "" ? "Default" : contentUrl; } }

        private string siteId;
        public string SiteId { get { return SiteId; } }
        private string userId;
        public string UserId { get { return UserId; } }

        public IFileProvider ImageOutputProvider { get => imageOutputProvider; set => imageOutputProvider = value; }

        private IFileProvider imageOutputProvider;

        /// <summary>
        /// This class provides authentication and pre-caching functionality toward Tableau Server.
        /// </summary>
        /// <param name="TableauServer">Tableau Server.</param>
        /// <param name="Credentials">Username/password for the Tableau Server.</param>
        /// <param name="ContentUrl">Tableau Server Content URL (aka Site ID in Server UI parlance).</param>
        public TableauPerformanceAccelerator(Uri TableauServer,
                                 NetworkCredential Credentials,
                                 string ContentUrl,
                                 int ParallelThreads = DEFAULT_PARALLELISM,
                                 int RequestTimeoutInSeconds = DEFAULT_REQUEST_TIMEOUT_IN_SECONDS,
                                 int ThinkTimeInMilliseconds = DEFAULT_THINK_TIME_IN_MILLISECONDS,
                                 ViewRequestMode RequestMode = ViewRequestMode.RestApi,
                                 bool TraceLogging = false,
                                 IFileProvider ImageOutputProvider = null)
        {
            if (ContentUrl == null) ContentUrl = "";

#if DEBUG
            logger.LogDebug($"Setting up Tableau Performance Accelerator instance for server {TableauServer.ToString()} for user {Credentials.UserName} toward {ContentUrl} with {ParallelThreads.ToString()} parallel threads.");
#endif

            tableauServerUri = TableauServer;
            contentUrl = ContentUrl;
            tableauServerCredentials = Credentials;
            parallelThreads = ParallelThreads < 1 ? DEFAULT_PARALLELISM : ParallelThreads;
            requestTimeoutInSeconds = RequestTimeoutInSeconds < 15 ? DEFAULT_REQUEST_TIMEOUT_IN_SECONDS : RequestTimeoutInSeconds;
            thinkTimeInMilliseconds = ThinkTimeInMilliseconds < 1 ? DEFAULT_THINK_TIME_IN_MILLISECONDS : ThinkTimeInMilliseconds;
            viewRequestMode = RequestMode;

            logger.LogInformation($"Setting up Tableau Performance Accelerator instance for {TableauServer.ToString()} on site {siteUIIDForDisplay}.");
        }

        /// <summary>
        /// Brute-force pre-caching of all views each user has access to. All requests are queued then processed in parallel.
        /// </summary>
        /// <returns>The cache views for all users.</returns>
        /// <param name="FilterConfiguration">Filter configuration.</param>
        public int PreCacheViewsForAllUsersFullyInParallel(Models.FilterCombinatoricsMode FilterMode = Models.FilterCombinatoricsMode.NoFilter, Models.FilterAndCubeConfiguration FilterConfiguration = null)
        {
            if (!EnsureAuthentication())
                return 0;

            // ConcurrentQueue<T> is thread-safe (List<T> is not), and concurrent queue is FIFO
            ConcurrentQueue<UserRequestSet> userRequestSets = new ConcurrentQueue<UserRequestSet>();

            // TODO: See if we can re-use this same method for the CacheContent approach, but skip the list of users
            //  and see if we can push down logic to avoid doing impersonation
            // If the service account user is the one-and-only user specified in the FilterConfiguration,
            //  we can skip enumerating the users list.
            //if (FilterConfiguration)

            logger.LogInformation("Retrieving the list of users...");
            // Retrieve the list of users
            if (!GetUsersList(FilterConfiguration, out IEnumerable<TableauServerSiteUser> users))
            {
                logger.LogError("Unable to retrieve list of users.");

                return 0;
            }

            logger.LogDebug($"Building list of user request sets ({parallelThreads.ToString()} max parallel threads).");

            // Setup a Tableau REST API instance
            DefaultApi TableauApi = new DefaultApi(tableauServerUri.ToString());
            TableauApi.ApiClient.RestClient.Timeout = (requestTimeoutInSeconds * 1000);

            // Build the master list of user-view-filters
            // Uses the elegant Parallel.ForEach to get the views per user up to the specified MaxDegreeOfParallelism
            _ = Parallel.ForEach(users, new ParallelOptions { MaxDegreeOfParallelism = parallelThreads }, user =>
            {
                IEnumerable<ViewWithFilter> viewRequests;
                IEnumerable<QueryViewsForSiteResponseViewsView> viewsResponse;

                // Capture the impersonated user's token
                UserRequestSet userRequestSet;

                // BET-82
                try
                {
                    userRequestSet = new UserRequestSet(TableauApi, user)
                    {
                        TableauServerAuthToken = AuthenticateAndGetToken(tableauServerUri, tableauServerCredentials, contentUrl, user)
                    };
                }
                // TODO: Implement more granular logging
                //catch (ArgumentNullException ex)
                //{
                //    throw ex;
                //}
                //catch (ArgumentException ex)
                //{
                //    throw ex;
                //}
                //catch (ApiException ex)
                //{
                //    throw ex;
                //}
                catch (Exception ex)
                {
                    logger.LogError($"Unable to authenticate and get token for {tableauServerCredentials.UserName}. See logs for more information.");
                    logger.LogDebug(ex.Message);

                    throw ex;
                }

                if (userRequestSet.TableauServerAuthToken == null)
                {
                    logger.LogError($"Tableau Server authentication token cannot be null. Skipping user {user.Name}");

                    return;
                }

                logger.LogInformation($"Retrieving list of views for user {user.Name}...");
                try
                {
                    viewsResponse = TableauApi.SitesSiteIdViewsGet(siteId, SITE_VIEWS_FIELD_LIST, null, null);
                }
                catch (ApiException ex)
                {
                    // https://help.tableau.com/current/api/rest_api/en-us/REST/rest_api_ref.htm#query_views_for_site
                    switch (ex.ErrorCode)
                    {
                        // Invalid page number
                        case 400006:
                            logger.LogError("Attempted to read more view results than exist for this user. See logs for more information");
                            break;
                        // Invalid page size
                        case 400007:
                            logger.LogError("Attempted to read views list with an invalid page size. See logs for more information");
                            break;
                        default:
                            logger.LogError($"Unable to retrieve list of views for user {user.Name}. See logs for more information.");
                            break;
                    }

                    logger.LogDebug($"Exception message: {ex.Message}");
                    logger.LogDebug($"API error code: {ex.ErrorCode}; API error content: {ex.ErrorContent.ToString()}");
#if DEBUG
                    // Log detailed info
                    logger.LogDebug($"Stack trace: {ex.StackTrace}");
#endif

                    return;
                }
                catch (Exception ex)
                {
                    logger.LogError($"Unable to retrieve list of views for user {user.Name}. See logs for more information.");
                    logger.LogDebug($"Exception message: {ex.Message}");

                    return;
                }
                logger.LogInformation($"Found {viewsResponse.Count().ToString()} views for user {user.Name}.");

                // If the user has access to no views, exit.
                if (!viewsResponse.Any())
                {
                    return;
                }

                // That is, if we have been given a filter configuration
                if (FilterConfiguration != null)
                {
                    logger.LogInformation("Filter configuration specified; using filtered and cubed mode.");
                    logger.LogDebug($"Retrieving filter sets for filter mode {FilterMode.ToString()}.");

                    // Filter the views list based on the scope in the configuration
                    var viewsToCache = viewsResponse
                          .Where(view => ProjectFilterBasedOnConfiguration(view, filterAndCubeConfiguration: FilterConfiguration))
                          .Where(view => WorkbookFilterBasedOnConfiguration(view, filterAndCubeConfiguration: FilterConfiguration))
                          .Where(view => ViewFilterBasedOnConfiguration(view, filterAndCubeConfiguration: FilterConfiguration));

                    if (!viewsToCache.Any())
                    {
                        logger.LogInformation($"Filter configuration excludes all views for user {user.Name}.");

                        return;
                    }
                    else
                    {
                        logger.LogInformation($"Filter applied. Will process {viewsToCache.Count()} views for user {user.Name}.");
                    }

                    // Build out the filter sets based on the filter mode (provided at run-time) and the filter configuration (provided
                    //  in the configuration file)
                    List<Models.FilterSet> filterSets;

                    // If the filter configuration has no user filters defined and/or if the user
                    //  matches none of the user-filters, use the "global" filters
                    // Default behavior of GetFilterSets is to return a union of all parameters and filters
                    if (!(FilterConfiguration.UserFilters ?? new List<Models.UserFilterConfiguration>()).Any())
                    {
                        filterSets = FilterConfiguration.GetFilterSets(FilterMode);
                    }
                    else
                    {
                        // Otherwise, for each user-filter that matches this user, get the DISTINCT list of all applicable filtersets
                        filterSets = FilterConfiguration.UserFilters.Where(uf => uf.Users.ScopeMatch(user.Name))
                              .SelectMany(uf => FilterConfiguration.GetFilterSets(uf.Filters.ToInputs().Union(uf.Parameters.ToInputs()).ToList(), FilterMode))
                              .Distinct<Models.FilterSet>(new Models.FilterSet.FilterSetComparer())
                              .ToList();
                    }

                    // If there are filtersets...
                    if (filterSets != null)
                    {
                        // Get the list of views along with all Tableau Server filter string combinations we will apply
                        // It is theoretically possible to have view requests with different View Request Modes.
                        viewRequests =
                              from view in viewsToCache
                              from filterSet in filterSets
                              select new ViewWithFilter(view, filterSet.AsFilterString(viewRequestMode), viewRequestMode);

                        logger.LogInformation($"Found {viewRequests.Count().ToString()} view filter combinations.");

                    }
                    else
                    {
                        logger.LogInformation("No filtersets specified; using one-load-per-view mode.");
                        // TODO: double-check that we aren't double-requesting the "default" view of the dashboard
                        viewRequests =
                              from view in viewsToCache
                              select new ViewWithFilter(view, "", viewRequestMode);
                    }

                    // Always cache the empty/no-filter version even if there are filters - BET-45
                    viewRequests = viewRequests.Union(viewsToCache.Select(view => new ViewWithFilter(view, "", viewRequestMode)));
                }
                else
                // If no filter configuration is specified, so basically if we're in all-views-for-all-site-users mode...
                {
                    logger.LogInformation("No filter configuration specified; using one-load-per-view mode.");

                    viewRequests =
                        from view in viewsResponse
                        select new ViewWithFilter(view, "", viewRequestMode);
                }

                userRequestSet.ViewWithFilters.AddRange(viewRequests);

                userRequestSets.Enqueue(userRequestSet);
            });

            return ParallelPrecacheUserRequestSets(userRequestSets);
        }

        private bool GetUsersList(Models.FilterAndCubeConfiguration FilterConfiguration, out IEnumerable<Models.TableauServerSiteUser> users)
        {
            DefaultApi defaultApi = new DefaultApi(tableauServerUri.ToString());
            defaultApi.ApiClient.RestClient.Timeout = (requestTimeoutInSeconds * 1000);

            IEnumerable<GetUsersOnSiteResponseUsersUser> usersResponse;

            if (!EnsureAuthentication())
            {
                throw new Exception("Unable to authenticate.");
            }

            defaultApi.ApiClient.TableauAuthToken = Configuration.ApiKey["X-Tableau-Auth"];

            // Retrieve the list of users for this site
            try
            {
                usersResponse = defaultApi.SitesSiteIdUsersGet(siteId, "_default_", null, null);
            }
            catch (ApiException ex)
            {
                logger.LogError($"Unable to retrieve list of users for site {siteUIIDForDisplay} ({siteId}). See logs for more information.");

                // If the user isn't authorized to list users
                if (ex.ErrorContent != null)
                {
                    dynamic errorResponse = (JsonObject)SimpleJson.DeserializeObject(ex.ErrorContent.ToString());
                    if (errorResponse.ContainsKey("error")
                        && errorResponse["error"].ContainsKey("code")
                        && errorResponse["error"]["code"] == "403000"
                        && errorResponse["error"].ContainsKey("detail"))
                    {
                        logger.LogError((string)errorResponse["error"]["detail"]);
                    }
                }

                logger.LogDebug($"Exception message: {ex.Message}");
                logger.LogDebug($"API error code: {ex.ErrorCode}; API error content: {ex.ErrorContent.ToString()}");
#if DEBUG
                // Log detailed info
                logger.LogDebug($"Stack trace: {ex.StackTrace}");
#endif
                users = null;
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError($"Unable to retrieve list of users for site {siteUIIDForDisplay} ({siteId}). See logs for more information.");
                logger.LogDebug($"Exception message: {ex.Message}");

                users = null;
                return false;
            }

            if (FilterConfiguration != null)
            {
                logger.LogInformation("Filter configuration specified; using filtered and cubed mode.");

                // Filter users by A) the FilterConfiguration and B) if they are licensed users, as you can't impersonate an Unlicensed user
                users = usersResponse
                    .Where(user => UserFilterBasedOnConfiguration(user, filterAndCubeConfiguration: FilterConfiguration))
                    .Select(GetModelUserFromTableauApiUser);
            }
            else
            {
                users = usersResponse
                    .Where(u => u.SiteRole != "Unlicensed" && u.Name.ToLowerInvariant() != "guest") // Resolves BET-10
                    .Select(GetModelUserFromTableauApiUser);
            }

            logger.LogInformation($"Pre-caching views for {users.Count().ToString()} users.");

            return true;
        }

        /// <summary>
        /// Translates a TableauAPI user to our new model. This is a temporary helper until we switch to the unified API.
        /// </summary>
        /// <returns>The Tableau API user as a TableauServerSiteUser.</returns>
        /// <param name="user">User.</param>
        private static Models.TableauServerSiteUser GetModelUserFromTableauApiUser(GetUsersOnSiteResponseUsersUser user)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.TableauServerSiteUser>(user.ToJson());
        }

        private int ParallelPrecacheUserRequestSets(IEnumerable<UserRequestSet> userRequestSets)
        {
            int viewsCount = 0;

            var userRequests = userRequestSets.SelectMany(u => u.ViewWithFilters, (u, u2) => new { u.UserApiInstance, ViewRequest = u2, u.TableauServerAuthToken, u.SiteUser });

            logger.LogDebug($"Precaching user request sets ({parallelThreads.ToString()} max parallel threads).");

            // Uses the elegant Parallel.ForEach to make a request for the PNG of each view up to the specified MaxDegreeOfParallelism
            ParallelLoopResult parallelLoopResult = Parallel.ForEach(userRequests, new ParallelOptions() { MaxDegreeOfParallelism = this.parallelThreads }, userRequest =>
            {
#if DEBUG
                //logger.LogDebug($"Auth token for user {userRequest.SiteUser.Name}: {userRequest.UserApiInstance.ApiClient.TableauAuthToken}");
                logger.LogDebug($"Requesting view {userRequest.ViewRequest.View.ContentUrl} with filter {userRequest.ViewRequest.Filter}");
#endif
                // https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.add?view=netframework-4.8
                Interlocked.Add(ref viewsCount, PreCacheView(userRequest.UserApiInstance, userRequest.ViewRequest, userRequest.TableauServerAuthToken, userRequest.SiteUser));
            });

            // TODO: this isn't the total views count; it's the number of specific times we've requested views
            // The same views get counted repeatedly. It's a minor bug, but annoying.
            return viewsCount;
        }

        private int PreCacheView(DefaultApi defaultApi, ViewWithFilter filteredView, string AuthToken, Models.TableauServerSiteUser User = null)
        {
            logger.LogInformation($"Precaching {filteredView.View.Name}{((filteredView.Filter.Length > 0) ? " for filter " : "")}{filteredView.Filter} for user {((User != null) ? User.Name : "unknown")}...");

            try
            {
#if DEBUG
                logger.LogDebug($"Sleeping for {thinkTimeInMilliseconds.ToString()} milliseconds.");
#endif
                System.Threading.Thread.Sleep(thinkTimeInMilliseconds);

                // I'm not sure that this is thread-safe
                defaultApi.ApiClient.TableauAuthToken = AuthToken;

                // TODO: Store the image, then either report its size (to identify blanks) or
                //  write it somewhere via the IFileProvider.  - BET-15

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                switch (filteredView.RequestMode)
                {
                    case ViewRequestMode.ClientXml:
                        throw new NotImplementedException("Client XML API requests for pre-caching are not yet implemented.");
                    case ViewRequestMode.HttpGet:
                        var cookieContainer = new CookieContainer();
                        cookieContainer.Add(new Cookie("workgroup_session_id", AuthToken, "/", new Uri(defaultApi.ApiClient.BasePath).Authority));
                        defaultApi.ApiClient.RestClient.CookieContainer = cookieContainer;// .GetCookies(new Uri(defaultApi.ApiClient.BasePath).Authority)["workgroup_session_id"].Value = AuthToken;

#if DEBUG
                        logger.LogDebug($"BasePath: {defaultApi.ApiClient.BasePath}");

#endif
                        // TODO: This should be moved out of this method so as to improve performance
                        UriBuilder requestUri = new UriBuilder("https", new Uri(defaultApi.ApiClient.BasePath).Authority, 443);
                        requestUri.Path = $"/t/{contentUrl}/views/{filteredView.View.ContentUrl.Replace("/sheets/", "/")}.png";
                        requestUri.Query = filteredView.Filter;

                        RestResponse response = (RestResponse)defaultApi.ApiClient.RestClient.Get(new RestRequest(requestUri.ToString()));

                        break;
                    case ViewRequestMode.RestApi:
                    default:
                        defaultApi.SitesSiteIdViewsViewIdImageGet(siteId, filteredView.View.Id, filteredView.Filter);
                        break;
                }

                stopWatch.Stop();

                logger.LogDebug($"View {filteredView.View.Name}{((filteredView.Filter.Length > 0) ? " for filter expression " : "")}{filteredView.Filter} pre-cached in {stopWatch.Elapsed.ToString()}.");

                return 1;
            }
            catch (Exception ex)
            {
                logger.LogWarning($"Unable to pre-cache view {filteredView.View.Name}{((filteredView.Filter.Length > 0) ? " for filter expression " : "")}{filteredView.Filter}");
                logger.LogDebug($"Tableau Server error pre-caching view {filteredView.View.Name}{((filteredView.Filter.Length > 0) ? " for filter expression " : "")}{filteredView.Filter}.", ex);

                return 0;
            }
        }
    }
}
