using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Api;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Client;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Biztory.EnterpriseToolkit.TableauServer
{
    public partial class TableauPerformanceAccelerator
    {
        /// <summary>
        /// Authenticate using the server, site, and credentials provided at instantiation.
        /// </summary>
        /// <returns>The authentication status (true if successful).</returns>
        public bool Authenticate()
        {
            return Authenticate(tableauServerUri, tableauServerCredentials, contentUrl);
        }

        /// <summary>
        /// Authenticate using the server and credentials provided at instantiation.
        /// </summary>
        /// <returns>The authentication status (true if successful).</returns>
        public bool Authenticate(string ContentUrl)
        {
            if (Authenticate(tableauServerUri, tableauServerCredentials, ContentUrl))
            {
                // Update the saved content Url
                contentUrl = ContentUrl;
                return true;
            }
            else return false;
        }

        public string GetUserSiteRole(DefaultApi TableauApi, string UserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Authenticate the specified TableauServer for the given ContentUrl using Credentials.
        /// </summary>
        /// <returns>The Tableau Server authentication token.</returns>
        /// <param name="TableauServer">Tableau server.</param>
        /// <param name="Credentials">Credentials.</param>
        /// <param name="ContentUrl">Content URL.</param>
        /// <param name="ImpersonateUser">(optional)User to impersonate.</param>
        public string AuthenticateAndGetToken(Uri TableauServer, NetworkCredential Credentials, string ContentUrl, Models.TableauServerSiteUser ImpersonateUser = null)
        {
            SignInResponse authResponse;

            try
            {
                authResponse = Authenticate(tableauServerUri, tableauServerCredentials, contentUrl, ImpersonateUser);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (ApiException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (authResponse != null)
            {
                return authResponse.Credentials.Token;
            }
            else
            {
                if (ImpersonateUser != null)
                {
                    logger.LogDebug($"Unable to impersonate user {ImpersonateUser.Name}.");
                    throw new Exception($"Unable to perform impersonated authentication for user {ImpersonateUser.Name}.");
                }
                else
                {
                    logger.LogDebug($"Unable to authenticate user {Credentials.UserName}.");
                    throw new Exception($"Unable to perform authentication for user {Credentials.UserName}.");
                }
            }
        }

        /// <summary>
        /// Authenticate the specified TableauServer for the given ContentUrl using Credentials.
        /// </summary>
        /// <returns>The authentication status (true if successful).</returns>
        /// <param name="TableauServer">Tableau server.</param>
        /// <param name="Credentials">Credentials.</param>
        /// <param name="ContentUrl">Content URL.</param>
        /// <param name="ImpersonateUser">(optional)User to impersonate.</param>
        public SignInResponse Authenticate(Uri TableauServer, NetworkCredential Credentials, string ContentUrl, Models.TableauServerSiteUser ImpersonateUser = null)
        {
            // Input validation
            if (!TableauServer.IsAbsoluteUri)
            {
                logger.LogError($"The specified Tableau Server URL ({TableauServer}) is not a valid absolute URL.");
                throw new ArgumentException($"The specified Tableau Server URL({ TableauServer }) is not a valid absolute URL.", nameof(TableauServer));
            }
            if (Credentials == null)
            {
                logger.LogError("No Tableau Server credentials specified.");
                throw new ArgumentNullException($"No Tableau Server credentials specified.", nameof(Credentials));
            }
            if ((Credentials.UserName ?? "").Length == 0)
            {
                logger.LogError("No Tableau Server username specified.");
                throw new ArgumentNullException($"No Tableau Server username specified.", nameof(Credentials.UserName));
            }
            if (Credentials.SecurePassword == null || Credentials.SecurePassword.Length == 0)
            {
                logger.LogError("No Tableau Server password specified.");
                logger.LogDebug("The SecurePassword value is null in the specified NetworkCredential object.");

                throw new ArgumentException($"No Tableau Server password specified.", nameof(Credentials.SecurePassword), new Exception("The SecurePassword value is null in the specified NetworkCredential object."));
            }

            if (ImpersonateUser == null)
            {
                logger.LogInformation($"Authenticating to {TableauServer.ToString()} as {Credentials.UserName} on site {siteUIIDForDisplay}.");
            }
            else
            {
                logger.LogInformation(message: $"Authenticating to {TableauServer.ToString()} as {Credentials.UserName} impersonating {ImpersonateUser.Name} on site {siteUIIDForDisplay}.");
            }

            SignInRequestCredentials credentials = new SignInRequestCredentials()
            {
                Name = Credentials.UserName,
                Password = Credentials.Password,
                Site = new SignInRequestCredentialsSite() { ContentUrl = ContentUrl }
            };
            if (ImpersonateUser != null)
            {
                credentials.User = new SignInRequestCredentialsUser() { Id = ImpersonateUser.Id };
            }

            AuthenticationApi authApi = new AuthenticationApi(TableauServer.ToString());
            SignInResponse signInResponse;
            try
            {
                signInResponse = authApi.AuthSigninPost(new SignInRequest() { Credentials = credentials });
            }
            catch (ApiException exception)
            {
                logger.LogCritical("Error on sign-in.", exception);
                logger.LogDebug(exception.Message);
                logger.LogInformation("Unable to sign in. See logs for further information.");

                throw exception;
            }

            // TODO: How to handle fails?
            if (signInResponse != null)
            {
                return signInResponse;
            }
            else
            {
                throw new Exception("Null response from sign in call.");
            }
        }

        /// <summary>
        /// Authenticate the specified TableauServer for the given ContentUrl using Credentials.
        /// </summary>
        /// <returns>The authentication status (true if successful).</returns>
        /// <param name="TableauServer">Tableau server.</param>
        /// <param name="Credentials">Credentials.</param>
        /// <param name="ContentUrl">Content URL.</param>
        public bool Authenticate(Uri TableauServer, NetworkCredential Credentials, string ContentUrl)
        {
            // Input validation
            if (!TableauServer.IsAbsoluteUri)
            {
                logger.LogError($"The specified Tableau Server URL ({TableauServer}) is not a valid absolute URL.");
                return false;
            }
            if (Credentials == null)
            {
                logger.LogError("No Tableau Server credentials specified.");
                return false;
            }
            if ((Credentials.UserName ?? "").Length == 0)
            {
                logger.LogError("No Tableau Server username specified.");
                return false;
            }
            if (Credentials.SecurePassword == null || Credentials.SecurePassword.Length == 0)
            {
                logger.LogError("No Tableau Server password specified.");
                logger.LogDebug("The SecurePassword value is null in the specified NetworkCredential object.");

                return false;
            }

            SignInRequestCredentials credentials = new SignInRequestCredentials()
            {
                Name = Credentials.UserName,
                Password = Credentials.Password,
                Site = new SignInRequestCredentialsSite() { ContentUrl = ContentUrl }
            };

            AuthenticationApi authApi = new AuthenticationApi(TableauServer.ToString());
            SignInResponse signInResponse;
            try
            {
                signInResponse = authApi.AuthSigninPost(new SignInRequest() { Credentials = credentials });
            }
            catch (ApiException exception)
            {
                logger.LogCritical("Error on sign-in.", exception);
                logger.LogDebug(exception.Message);
                logger.LogInformation("Unable to sign in. See logs for further information.");

                return false;
            }

            // TODO: How to handle fails?
            if (signInResponse != null)
            {
                // If the sign-in was successful, store the credentials in memory for future re-authentication
                tableauServerCredentials = Credentials;

                // https://stackoverflow.com/a/43084626
                serviceAccountUserToken = new NetworkCredential("", signInResponse.Credentials.Token).SecurePassword;

                siteId = signInResponse.Credentials.Site.Id;
                userId = signInResponse.Credentials.User.Id;

                logger.LogInformation("Authentication successful.");
                return true;
            }
            else
            {
                // I don't think is is a 500...
                logger.LogError("Unable to authenticate. See logs for further details.");
                logger.LogDebug($"Detailed error: {signInResponse.ToJson()}");
                throw new ApiException(500, "Unable to sign in to Tableau Server.");
            }
        }

        private bool EnsureAuthentication(Models.TableauServerSiteUser ImpersonateUser)
        {
            throw new NotImplementedException("This approach to impersonation is no longer supported.");
        }

        private bool EnsureAuthentication()
        {
            // If we don't currently have an auth token, or if we need to re-do authentication due to
            //  impersonation...
            if (serviceAccountUserToken == null)
            {
                // And so long as we have credentials
                if (tableauServerCredentials != null)
                {
                    // TODO: If we're doing per-user view caching, we need to make sure we're authenticating
                    //  as a server admin

                    // Try authenticating
                    if (!Authenticate(tableauServerUri, tableauServerCredentials, contentUrl))
                    {
                        throw new Exception("Unable to authenticate to the Tableau Server.");
                    }
                }
                else
                {
                    throw new ArgumentException("No Tableau Server credentials available.");
                }
            }

            return true;
        }
    }
}
