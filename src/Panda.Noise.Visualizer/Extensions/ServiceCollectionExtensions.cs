using Microsoft.Extensions.DependencyInjection;
using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;
using Panda.Noise.Gradient;
using Panda.Noise.Visualizer.Configuration;
using Panda.Noise.Visualizer.Implementations;
using Panda.Noise.Visualizer.Interfaces;
using Panda.Noise.White;

namespace Panda.Noise.Visualizer.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddVisualizer<TColorPicker>(this IServiceCollection services, string[] args) where TColorPicker : class, IColorPicker
		=> services
			.AddSingleton<IVisualizerService, PhotoVisualizerService>()
			.AddSingleton<IColorPicker, TColorPicker>()
			.AddSingleton(new PhotoVisualizerConfiguration(args[2], 1024, 1024));

	public static IServiceCollection AddRandomNoise(this IServiceCollection services)
		=> services
			.AddSingleton<INoise2, RandomNoise2>()
			.AddSingleton(new WhiteNoiseConfiguration());

	public static IServiceCollection AddPerlinNoise(this IServiceCollection services)
		=> services
			.AddSingleton<INoise2, PerlinNoise2>()
			.AddSingleton(new PerlinNoiseConfiguration());
}
