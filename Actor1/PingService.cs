using Actor1.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace Actor1
{
	internal class PingService : IHostedService
	{
		private readonly ILogger<PingService> m_logger;

		public PingService(ILogger<PingService> logger)
		{
			this.m_logger = logger;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			await Task.Delay(1000, cancellationToken);
			try
			{
				m_logger.LogInformation("Start ping");
                var actorId = ActorId.CreateRandom();
                var proxy = ActorProxy.Create<IActor1>(actorId, new Uri("fabric:/ActorTest/Actor1ActorService"));

                await proxy.SetCountAsync(2, cancellationToken);
                var count = await proxy.GetCountAsync(cancellationToken);

                m_logger.LogInformation("The new count is: {Count}", count);
			}
			catch (Exception ex)
			{
				m_logger.LogInformation(ex, "An exception occurred");
			}
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
