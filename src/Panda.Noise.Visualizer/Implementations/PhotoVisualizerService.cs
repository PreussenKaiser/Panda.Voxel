using Microsoft.Extensions.Logging;
using Panda.Noise.Abstractions;
using Panda.Noise.Visualizer.Configuration;
using Panda.Noise.Visualizer.Extensions;
using Panda.Noise.Visualizer.Interfaces;
using Panda.Noise.Visualizer.Utilities;
using System.Drawing;
using System.Runtime.Versioning;

namespace Panda.Noise.Visualizer.Implementations;

[SupportedOSPlatform("windows")]
public sealed class PhotoVisualizerService(
	INoise noise,
	PhotoVisualizerConfiguration configuration,
	ILogger<PhotoVisualizerService> logger)
		: IVisualizerService
{
	private readonly INoise noise = noise;
	private readonly PhotoVisualizerConfiguration configuration = configuration;
	private readonly ILogger<PhotoVisualizerService> logger = logger;

	public void Create()
	{
		using var bitmap = new Bitmap(this.configuration.Width, this.configuration.Height);

		bitmap.Fill((x, y) =>
		{
			int value = this.noise.GetValue(x, y);
			Color color = ColorHelper.GetColor(value);

			bitmap.SetPixel(x, y, color);
		});

		string path = CreateFullPath(this.configuration.FilePath);
		this.logger.LogInformation("Saving visual to {FilePath}", path);

		bitmap.Save(path);
		// TODO: Open file.
	}

	public Task CreateAsync(CancellationToken cancellationToken = default)
	{
		this.Create();

		return Task.CompletedTask;
	}

	private static string CreateFullPath(string path)
	{
		// TODO: Decouple from system clock.
		string dateStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
		string fullPath = $"{path}\\{dateStamp}.png";

		return fullPath;
	}
}
