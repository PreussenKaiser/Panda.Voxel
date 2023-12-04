using Microsoft.Extensions.DependencyInjection;
using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;
using Panda.Noise.Gradient;
using Panda.Noise.Visualizer.Configuration;
using Panda.Noise.Visualizer.Implementations;
using Panda.Noise.Visualizer.Interfaces;

namespace Panda.Noise.Visualizer.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddVisualizer(this IServiceCollection services)
	{
		services
			.AddSingleton<IColorPicker, GrayScaleColorPicker>()
			.AddSingleton<INoise2, GradientNoise2>()
			.AddSingleton<IVisualizerService, PhotoVisualizerService>();

		return services;
	}

	public static IServiceCollection AddConfiguration(this IServiceCollection services, string[] args)
	{
		// TODO: Getting configuration like this is cringe.
		var gradientNoiseConfiguration = new GradientNoiseConfiguration();
		var whiteNoiseConfiguration = new WhiteNoiseConfiguration();
		var photoVisualizerConfiguration = new PhotoVisualizerConfiguration
		{
			FilePath = args[2],
			Width = 128,
			Height = 128,
		};

		services
			.AddSingleton(gradientNoiseConfiguration)
			.AddSingleton(whiteNoiseConfiguration)
			.AddSingleton(photoVisualizerConfiguration);

		return services;
	}
}
