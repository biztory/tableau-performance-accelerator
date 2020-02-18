using Args;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace Biztory.EnterpriseToolkit
{
    public static class Tools
    {
        public static IEnumerable<string> DumpClassAttributes<T>(T x)
        {
            return typeof(T).GetProperties()
                .Select(p => ($"{p.Name}: {new string(' ', typeof(T).GetProperties().Max(pi => pi.Name.Length) - p.Name.Length)} {p.GetValue(x)}"));
        }
    }
    public static class ConsoleTools
    {
        /// <summary>
        /// Writes the help for an Args command object to the console.
        /// Apparently this is a built-in function of Args.Help...ooops.
        /// </summary>
        /// <typeparam name="T">An Args command object type.</typeparam>
        public static void WriteHelpToConsole<T>()
        {
            string commandLineArgumentDelimiter = typeof(T).GetCustomAttribute<ArgsModelAttribute>().SwitchDelimiter;

            Console.WriteLine();
            Console.WriteLine($"{System.AppDomain.CurrentDomain.FriendlyName.ToUpper()} v{Assembly.GetEntryAssembly().GetName().Version.ToString()}");
            Console.WriteLine($"(c){System.DateTime.Now.Year.ToString()} Biztory NV");

            Console.WriteLine();
            Console.WriteLine($"Usage: ");
            Console.WriteLine();

            // Who am I, what's my name?
            Console.Write($"   {System.AppDomain.CurrentDomain.FriendlyName.ToUpper()} ");
            // Use the Args command-line help generator, but fix the output a bit 
            StringWriter helpOutput = new StringWriter();
            new Args
                .Help
                .Formatters
                .ConsoleHelpFormatter()
                .WriteHelp(new Args
                           .Help
                           .HelpProvider()
                           .GenerateModelHelp(Configuration
                                              .Configure<T>()), helpOutput);
            Console.Write(helpOutput.ToString().Replace("<command> ", ""));

            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine();

            typeof(T)
                .GetProperties()
                .ToList()
                .ForEach(pi =>
                {
                    pi.GetCustomAttributes<DescriptionAttribute>(false).ToList().ForEach(ca =>
                    {

                        Console.WriteLine($"   {pi.Name}: {ca.Description.ToString()}");
                    }
                    );
                });

            Console.WriteLine();
        }
    }
}