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
			.AddSingleton<INoise, GradientNoise2>()
			.AddSingleton<IVisualizerService, PhotoVisualizerService>();

		return services;
	}

	public static IServiceCollection AddConfiguration(this IServiceCollection services, string[] args)
	{
		// TODO: Getting configuration like this is cringe.
		var noiseConfiguration = new GradientNoiseConfiguration(4);
		var photoVisualizerConfiguration = new PhotoVisualizerConfiguration
		{
			FilePath = args[2],
			Width = 1024,
			Height = 1024,
		};

		services
			.AddSingleton(noiseConfiguration)
			.AddSingleton(photoVisualizerConfiguration);

		return services;
	}
}
