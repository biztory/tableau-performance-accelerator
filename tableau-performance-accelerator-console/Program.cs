using Args;
using Args.Help;
using Biztory.EnterpriseToolkit.TableauServer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MMMTools.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Biztory.EnterpriseToolkit.TableauServer.PerformanceAcceleratorConsole
{
    class Program
    {
        const int DEFAULT_PARALLEL_THREADS = 4;
        const int MINIMUM_TIMEOUT_IN_SECONDS = 15;
        const int DEFAULT_TIMEOUT_IN_SECONDS = 120;
        const int DEFAULT_THINK_TIME_IN_MILLISECONDS = 1;

        static ILogger logger = ApplicationLogging.LoggerFactory.CreateLogger<Program>();
        static CommandObject command;
        static Models.FilterAndCubeConfiguration filterAndCubeConfiguration;
        static int parallelThreads = DEFAULT_PARALLEL_THREADS;
        static int requestTimeoutInSeconds = DEFAULT_TIMEOUT_IN_SECONDS;
        static int thinkTimeInMilliseconds = DEFAULT_THINK_TIME_IN_MILLISECONDS;
        static TableauPerformanceAccelerator.ViewRequestMode viewRequestMode = TableauPerformanceAccelerator.ViewRequestMode.RestApi;
        /// <summary>
        /// The content URL (what the UI calls the "Site ID," unless empty, in which case
        /// we use the name "Default" even though the content URL for the Default site
        /// is an empty string.
        /// </summary>
        public static string ContentUrlDisplayValue(string ContentUrl) { return (ContentUrl ?? "").Length > 0 ? ContentUrl : "Default"; }

        static void Main(string[] args)
        {
            logger.LogInformation("Tableau Performance Accelerator starting...");
            logger.LogInformation("Parsing command-line arguments...");

            // Validate the inputs and output the command parameters if necessary.
            try
            {
                logger.LogInformation("Validating command-line arguments");
                if (!ValidateArguments(args))
                {
                    ConsoleTools.WriteHelpToConsole<CommandObject>();

                    return;
                }
            }
            catch (Exception ex)
            {
                ConsoleTools.WriteHelpToConsole<CommandObject>();

                logger.LogDebug(ex, ex.Message);
                logger.LogError($"Error: {ex.Message}");

                return;
            }

            int performanceAcceleratedViewsCount;
            TableauPerformanceAccelerator performanceAccelerator;
            performanceAccelerator = new TableauPerformanceAccelerator(new Uri(command.TableauServerUrl)
                , Credentials: new System.Net.NetworkCredential(command.ServerAdminUsername, command.ServerAdminPassword)
                , ContentUrl: command.TableauServerSite
                , ParallelThreads: parallelThreads
                , RequestMode: viewRequestMode
                , RequestTimeoutInSeconds: requestTimeoutInSeconds
                , ThinkTimeInMilliseconds: thinkTimeInMilliseconds);

            if (!performanceAccelerator.Authenticate())
            {
                logger.LogCritical("Unable to authenticate with the Tableau Server. Check the username, password, URL, and site.");

                return;
            }

            // Execute the specified localization command 
            switch (command.Mode)
            {
                case PerformanceAcceleratorMode.CacheContent:
                    // Workaround
                    if (filterAndCubeConfiguration == null)
                    {
                        filterAndCubeConfiguration = new Models.FilterAndCubeConfiguration()
                        {
                            // All content just for this one user
                            Scope = new Models.Scope()
                            {
                                Projects = new Models.ScopeConfiguration()
                                {
                                    Regex = ".*",
                                    Exclude = new List<object>(),
                                    Include = new List<object>()
                                },
                                Workbooks = new Models.ScopeConfiguration()
                                {
                                    Regex = ".*",
                                    Exclude = new List<object>(),
                                    Include = new List<object>()
                                },
                                Views = new Models.ScopeConfiguration()
                                {
                                    Regex = ".*",
                                    Exclude = new List<object>(),
                                    Include = new List<object>()
                                },
                                Users = new Models.ScopeConfiguration()
                                {
                                    Regex = "",
                                    Exclude = new List<object>(),
                                    Include = new List<object>() { command.ServerAdminUsername }
                                }
                            },
                            Filters = new List<Models.FilterConfiguration>(),
                            Parameters = new List<Models.ParameterConfiguration>(),
                            UserFilters = new List<Models.UserFilterConfiguration>()
                        };
                    } else
                    {
                        filterAndCubeConfiguration.Scope.Users.Include = new List<object>() { command.ServerAdminUsername };
                    }

                    performanceAcceleratedViewsCount = performanceAccelerator.PreCacheViewsForAllUsersFullyInParallel(command.FilterMode.GetValueOrDefault(Models.FilterCombinatoricsMode.Individual), filterAndCubeConfiguration);
                    if (performanceAcceleratedViewsCount >= 0)
                    {
                        logger.LogInformation($"Pre-cached {performanceAcceleratedViewsCount.ToString()} views or view-filter combinations in site {ContentUrlDisplayValue(command.TableauServerSite)} on {command.TableauServerUrl}.");
                    }
                    else
                    {
                        logger.LogError("Unable to successfully pre-cache all views.");
                    }

                    break;
                case PerformanceAcceleratorMode.CacheContentPerUser:
                    performanceAcceleratedViewsCount = performanceAccelerator.PreCacheViewsForAllUsersFullyInParallel(command.FilterMode.GetValueOrDefault(Models.FilterCombinatoricsMode.Individual), filterAndCubeConfiguration);
                    if (performanceAcceleratedViewsCount >= 0)
                    {
                        logger.LogInformation($"Pre-cached {performanceAcceleratedViewsCount.ToString()} views or view-filter combinations in site {ContentUrlDisplayValue(command.TableauServerSite)} on {command.TableauServerUrl}.");
                    }
                    else
                    {
                        logger.LogError("Unable to successfully pre-cache all views.");
                    }

                    break;

                default:
                    logger.LogError($"Performance Accelerator mode \"{command.Mode}\" is not implemented.");

                    break;
            }

            logger.LogInformation("Tableau Performance Acceleration completed successfully.");

            return;
        }
        static bool ValidateArguments(string[] args)
        {
            if (args.Length == 0)
            {
                return false;
            }

            // Parse command line
            // App has two main modes: generating public/private key pairs, and generating license keys
            try
            {
                command = Args.Configuration.Configure<CommandObject>().CreateAndBind(args);

#if DEBUG
                // Debug command inputs
                Tools.DumpClassAttributes(command)
                     .ToList()
                     .ForEach(ca => logger.LogDebug(ca));
#endif
            }
            catch (FormatException ex)
            {
                string validLicensingActions = String.Join("\r\n", Enum.GetNames(typeof(PerformanceAcceleratorMode)));

                logger.LogError($"This licensing action is not recognized. Please specify a valid licensing action: \r\n{validLicensingActions}");
                logger.LogDebug("Error parsing arguments", ex);

                return false;
            }

            switch (command.Mode)
            {
                case PerformanceAcceleratorMode.CacheContent:
                case PerformanceAcceleratorMode.CacheContentPerUser:
                    if ((command.TableauServerUrl ?? "").Length == 0)
                    {
                        logger.LogError("No Tableau server Url specified.");

                        return false;
                    }
                    if (!Uri.IsWellFormedUriString(command.TableauServerUrl, UriKind.Absolute))
                    {
                        logger.LogError($"{command.TableauServerUrl} is not a valid URL.");

                        return false;
                    }
                    if ((command.ServerAdminUsername ?? "").Length == 0)
                    {
                        logger.LogError("Please specifiy a server admin username.");

                        return false;
                    }

                    if (command.TableauServerSite == null)
                    {
                        command.TableauServerSite = "";
                        logger.LogWarning("No site specified; reverting to Default site.");
                    }

                    // --------------------------------------------
                    if ((command.ServerAdminPassword ?? "").Length == 0)
                    {
                        Console.Write("Enter password: ");
                        try
                        {
                            string adminPassword = "";
                            // https://stackoverflow.com/a/3404522/2239885
                            do
                            {
                                ConsoleKeyInfo key = Console.ReadKey(true);
                                // Backspace should not work
                                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                                {
                                    adminPassword += key.KeyChar;
                                    Console.Write("*");
                                }
                                else
                                {
                                    if (key.Key == ConsoleKey.Backspace && adminPassword.Length > 0)
                                    {
                                        adminPassword = adminPassword.Substring(0, (adminPassword.Length - 1));
                                        Console.Write("\b \b");
                                    }
                                    else if (key.Key == ConsoleKey.Enter)
                                    {
                                        break;
                                    }
                                }
                            } while (true);
                            Console.WriteLine("");
                            command.ServerAdminPassword = adminPassword;
                        }
                        catch (Exception ex)
                        {
                            logger.LogError("Error reading the Tableau server admin password.", ex);

                            return false;
                        }
                    }

                    if ((command.PathToFilterAndCube ?? "").Length > 0)
                    {
                        if (!File.Exists(command.PathToFilterAndCube))
                        {
                            logger.LogError($"Unable to locate the specified microcube configuration file at {command.PathToFilterAndCube}.");

                            return false;
                        }

                        try
                        {
                            filterAndCubeConfiguration = Models.FilterAndCubeConfiguration.FromJson(File.ReadAllText(command.PathToFilterAndCube));
                        }
                        catch (Exception ex)
                        {
                            logger.LogError("Unable to load the specified microcube configuration file. See log for further details.");
                            logger.LogDebug("Error reading microcube JSON configuration file.", ex);

                            return false;
                        }

                        // Note that it's not necessasry to specify a filter mode because the app will assume individual filtering
                    }


                    if (command.ParallelThreads >= 1)
                    {
                        parallelThreads = command.ParallelThreads;
                    }
                    else
                    {
                        parallelThreads = DEFAULT_PARALLEL_THREADS;
                    }

                    if (command.RequestTimeoutInSeconds >= MINIMUM_TIMEOUT_IN_SECONDS)
                    {
                        requestTimeoutInSeconds = command.RequestTimeoutInSeconds;
                    }
                    else
                    {
                        requestTimeoutInSeconds = DEFAULT_TIMEOUT_IN_SECONDS;
                    }

                    if (command.ThinkTimeInMilliseconds >= 0)
                    {
                        thinkTimeInMilliseconds = command.ThinkTimeInMilliseconds;
                    }
                    else
                    {
                        requestTimeoutInSeconds = DEFAULT_THINK_TIME_IN_MILLISECONDS;
                    }

                    if ((command.RequestMode ?? "").Length > 0)
                    {
                        switch (command.RequestMode.ToLowerInvariant().Trim())
                        {
                            case "restapi":
                            case "rest":
                            case "r":
                            case "api":
                            case "rest api":
                            case "rest-api":
                                viewRequestMode = TableauPerformanceAccelerator.ViewRequestMode.RestApi;
                                break;
                            case "httpget":
                            case "get":
                            case "http":
                            case "http get":
                            case "http-get":
                            case "vizql":
                                viewRequestMode = TableauPerformanceAccelerator.ViewRequestMode.HttpGet;
                                break;
                        }
                    }
                    break;
                default:
                    logger.LogError($"Caching action \"{command.Mode}\" is not implemented.");
                    // Pessimism.
                    return false;
            }

            return true;
        }

    }


    [ArgsModel(SwitchDelimiter = "-")]
    public class CommandObject
    {
        [ArgsMemberSwitch(0)]
        [System.ComponentModel.Description("CacheContent, CacheContentPerUser")]
        public PerformanceAcceleratorMode Mode { get; set; }

        [System.ComponentModel.Description("The Tableau Server (e.g. https://tableau.biztory.com)")]
        [ArgsMemberSwitch("s", "S")]
        public string TableauServerUrl { get; set; }

        [System.ComponentModel.Description("The username of a server admin.")]
        [ArgsMemberSwitch("u", "U")]
        public string ServerAdminUsername { get; set; }

        [System.ComponentModel.Description("The password of a server admin.")]
        [ArgsMemberSwitch("p", "P")]
        public string ServerAdminPassword { get; set; }

        [System.ComponentModel.Description("The site ID (aka the 'content URL') to pre-cache.")]
        [ArgsMemberSwitch("t", "T")]
        public string TableauServerSite { get; set; }

        [System.ComponentModel.Description("The path to the filter-and-cube configuration file (JSON format).")]
        [ArgsMemberSwitch("f", "F")]
        public string PathToFilterAndCube { get; set; }

        [System.ComponentModel.Description("The filter mode (required when providing a filter configuration). NoFilter, Cartesian, Individual, AllCombinations.")]
        [ArgsMemberSwitch("m", "M")]
        public Models.FilterCombinatoricsMode? FilterMode { get; set; }

        [System.ComponentModel.Description("The number of processer cores to use in parallel (default: 4).")]
        [ArgsMemberSwitch("x", "X")]
        public int ParallelThreads { get; set; }

        [System.ComponentModel.Description("The request mode to use: RestApi or HttpGet (default: RestApi).")]
        [ArgsMemberSwitch("r", "R")]
        public string RequestMode { get; set; }

        [System.ComponentModel.Description("The number of seconds to wait per request before timing out (minimum 15).")]
        [ArgsMemberSwitch("timeout")]
        public int RequestTimeoutInSeconds { get; set; }

        [System.ComponentModel.Description("The number of milliseconds to wait between requests.")]
        [ArgsMemberSwitch("think")]
        public int ThinkTimeInMilliseconds { get; set; }
    }

    public enum PerformanceAcceleratorMode { CacheContent, CacheContentPerUser }

}
