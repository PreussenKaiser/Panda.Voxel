using Microsoft.Extensions.Logging;
using Panda.Extensions;
using Panda.Noise.Abstractions;
using Panda.Noise.Visualizer.Configuration;
using Panda.Noise.Visualizer.Extensions;
using Panda.Noise.Visualizer.Interfaces;
using System.Drawing;

namespace Panda.Noise.Visualizer.Implementations;

public sealed class PhotoVisualizerService(
	INoise2 noise,
	IColorPicker colorPicker,
	PhotoVisualizerConfiguration configuration,
	ILogger<PhotoVisualizerService> logger)
		: IVisualizerService
{
	private readonly INoise2 noise = noise;
	private readonly IColorPicker colorPicker = colorPicker;
	private readonly PhotoVisualizerConfiguration configuration = configuration;
	private readonly ILogger<PhotoVisualizerService> logger = logger;

	public void Create()
	{
		using var bitmap = new Bitmap(this.configuration.Width, this.configuration.Height);

		bitmap.Fill((x, y) =>
		{
			float noiseValue = this.noise.GetValue(x, y);
			float scaledNoise = noiseValue.Scale(255);

			Color color = this.colorPicker.Pick((int)scaledNoise);

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
