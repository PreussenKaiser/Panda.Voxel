using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;
using Panda.Noise.Gradient;
using Panda.Voxel.Configuration;
using Panda.Voxel.Generators;
using Panda.Voxel.Input;
using Panda.Voxel.Input.Camera;
using Panda.Voxel.Input.Looking;
using Panda.Voxel.Input.Movement;
using Panda.Voxel.Lifecycle;

namespace Panda.Voxel.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddGame<TGame>(this IServiceCollection services)
		where TGame : class, IGame
	{
		return services.AddSingleton<IGame, TGame>();
	}

	public static IServiceCollection AddMovement(this IServiceCollection services, bool isDebug = false)
	{
		IMovement movement = isDebug ? new FlyingMovement() : new GroundedMovement();

		return services.AddSingleton(movement);
	}

	public static IServiceCollection AddPcInput(this IServiceCollection services)
	{
		return services.AddSingleton<MouseLooking>();
	}

	public static IServiceCollection AddPlayer(this IServiceCollection services)
	{
		return services
			.AddSingleton<Player>()
			.AddSingleton<ICamera, PlayerCamera>();
	}

	public static IServiceCollection AddWorldGeneration<TWorldGenerator, TNoise>(this IServiceCollection services)
		where TWorldGenerator : class, IWorldGenerator
		where TNoise : class, INoise2
	{
		return services
			.AddSingleton<IWorldGenerator, TWorldGenerator>()
			.AddSingleton<INoise2, TNoise>();
	}

	public static IServiceCollection AddConfiguration(this IServiceCollection services)
	{
		var displayConfiguration = new DisplayConfiguration(800, 480, 90);
		var finiteWorldConfiguration = new FiniteWorldConfiguration(new Vector2(8));
		var mouseConfiguration = new MouseConfiguration(.001f);
		var worldConfiguration = new WorldConfiguration(16, 48, 128);
		var perlineNoiseConfiguration = new PerlinNoiseConfiguration();

		return services
			.AddSingleton(displayConfiguration)
			.AddSingleton(finiteWorldConfiguration)
			.AddSingleton(mouseConfiguration)
			.AddSingleton(worldConfiguration)
			.AddSingleton(perlineNoiseConfiguration);
	}
}
