using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace Actor1
{
	internal class ActorWrapper : IHostedService
	{
		private readonly ILogger<ActorWrapper> logger;

		public ActorWrapper(ILogger<ActorWrapper> logger)
		{
			this.logger = logger;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			try
			{
				logger.LogInformation("Starting actor");
				await ActorRuntime.RegisterActorAsync<Actor1>((context, actorType) =>
					new ActorService(context, actorType), cancellationToken: cancellationToken);
				logger.LogInformation("Actor started");
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Actor startup failing");
			}
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
