using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;
using Panda.Extensions;
using Panda.Noise.Visualizer.Configuration;
using Panda.Noise.Visualizer.Interfaces;
using Panda.Noise.Visualizer.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Panda.Noise.Visualizer.Implementations;

[SupportedOSPlatform("windows")]
public sealed class PhotoVisualizerService(PhotoVisualizerConfiguration configuration, ILogger<PhotoVisualizerService> logger) : IVisualizerService
{
	private readonly PhotoVisualizerConfiguration configuration = configuration;
	private readonly ILogger<PhotoVisualizerService> logger = logger;

	public void Create(int[,] map)
	{
		var (width, height) = map.GetLength();

		using var bitmap = new Bitmap(width, height);
		
		map.ForEach((x, y) => bitmap.SetPixel(x, y, ColorHelper.GetColor(map[x, y])));

		this.logger.LogInformation("Saving visual to {FilePath}", this.configuration.FilePath);
		bitmap.Save($"{this.configuration.FilePath}\\noise.png");
	}

	public Task CreateAsync(int[,] map, CancellationToken cancellationToken = default)
	{
		this.Create(map);

		return Task.CompletedTask;
	}
}
