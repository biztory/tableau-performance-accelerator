using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;

namespace Biztory.EnterpriseToolkit.TableauServer
{
    // https://stackify.com/net-core-loggerfactory-use-correctly/
    public static class ApplicationLogging
    {
        private static ILoggerFactory _Factory = null;

        public static void ConfigureLogger(ILoggerFactory factory)
        {
            // TODO: move all this into configuration
            // TODO: move this stuff into a central library
            factory
//                .AddDebug()
                .AddSerilog(new Serilog.LoggerConfiguration()
                    .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
#if DEBUG
                    .MinimumLevel.Debug()
#else
                    .MinimumLevel.Debug()
#endif
                    .WriteTo.RollingFile(new RenderedCompactJsonFormatter(),
                    "tableau-server-performance-accelerator.log",
#if DEBUG
                    Serilog.Events.LogEventLevel.Verbose, shared: true)
#else
                    Serilog.Events.LogEventLevel.Verbose, shared: true)
#endif
                    .CreateLogger());
        }

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if (_Factory == null)
                {
                    _Factory = new LoggerFactory();
                    ConfigureLogger(_Factory);
                }
                return _Factory;
            }
            set { _Factory = value; }
        }
        public static Microsoft.Extensions.Logging.ILogger CreateLogger()
        {
            return LoggerFactory.CreateLogger("TableauServerLocalizer");
        }
    }
}
