using Consul.Commands;
using Microsoft.Extensions.Logging;
using Panda.Noise.Abstractions;
using Panda.Noise.Visualizer.Interfaces;

namespace Panda.Noise.Visualizer.Commands;

public sealed class VisualizeCommand : CommandBase
{
	private readonly INoise noise;
	private readonly IVisualizerService visualizerService;
	private readonly ILogger<VisualizeCommand> logger;

	public VisualizeCommand(INoise noise, IVisualizerService visualizerService, ILogger<VisualizeCommand> logger)
	{
		this.noise = noise;
		this.visualizerService = visualizerService;
		this.logger = logger;

		base.IsCommand("Visualize");
	}

	protected override Task RunAsync()
	{
		this.logger.LogInformation("Visualizing map");

		int[,] map = this.noise.Generate();

		return this.visualizerService.CreateAsync(map);
	}
}
