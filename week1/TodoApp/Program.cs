using System;
using Serilog;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Error.WriteLine("initializing...");

            var builder = WebApplication.CreateBuilder(args);

            // serilog - logging for .NET apps
            //   logging sinks (console, file, etc.)
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            builder.Host.UseSerilog();
            
            var app = builder.Build();

            app.MapGet("/", (ILogger<Program> logger) =>
            {
                logger.LogInformation("Hello World endpoint was called");
                return "Hello World!";
            });

            app.Run();

            Console.Error.WriteLine("started!");
        }
    }
}
