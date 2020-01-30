using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;

namespace Biztory.EnterpriseToolkit.TableauServer.PerformanceAcceleratorConsole
{
    // https://stackify.com/net-core-loggerfactory-use-correctly/
    public static class ApplicationLogging
    {
        private static ILoggerFactory _Factory;

        public static void ConfigureLogger(ILoggerFactory factory)
        {
            // TODO: move all this into configuration
            // TODO: move this stuff into a central library
            factory
                //.AddDebug()
                .AddSerilog(new Serilog.LoggerConfiguration()
                    .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                    .MinimumLevel.Debug()
                    .WriteTo.RollingFile(new RenderedCompactJsonFormatter(),
                    "tableau-server-performance-accelerator-console.log",
#if DEBUG
                    Serilog.Events.LogEventLevel.Verbose, shared: true)
#else
                    Serilog.Events.LogEventLevel.Warning, shared: true)
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
            return LoggerFactory.CreateLogger("TableauServerLocalizerConsole");
        }
    }
}
