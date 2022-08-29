using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Actor1
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static async Task Main()
        {
            try
            {
                await Host.CreateDefaultBuilder()
                    .ConfigureServices(services =>
                    {
                        services.AddLogging(builder =>
                        {
                            builder.AddConsole();
                        });
                        services.AddSingleton<IDependency, DependencyImplementation>();
                        services.AddSingleton<ActorWrapper>();
                        services.AddSingleton<PingService>();

                        services.AddHostedService<ActorWrapper>();
                        services.AddHostedService<PingService>();
                    })
                    .RunConsoleAsync();
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
