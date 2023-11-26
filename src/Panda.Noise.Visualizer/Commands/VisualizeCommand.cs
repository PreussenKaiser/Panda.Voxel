using Consul.Commands;
using Microsoft.Extensions.Logging;
using Panda.Noise.Abstractions;
using Panda.Noise.Visualizer.Interfaces;

namespace Panda.Noise.Visualizer.Commands;

public sealed class VisualizeCommand : CommandBase
{
	private readonly IVisualizerService visualizerService;
	private readonly ILogger<VisualizeCommand> logger;

	public VisualizeCommand(IVisualizerService visualizerService, ILogger<VisualizeCommand> logger)
	{
		this.visualizerService = visualizerService;
		this.logger = logger;

		base.IsCommand("Visualize");
	}

	protected override Task RunAsync()
	{
		this.logger.LogInformation("Visualizing map");

		CancellationToken cancellationToken = new();
		return this.visualizerService.CreateAsync(cancellationToken);
	}
}
