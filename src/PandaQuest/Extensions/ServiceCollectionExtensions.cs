using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;
using Panda.Noise.Gradient;
using PandaQuest.Configuration;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.Camera;
using PandaQuest.Input.Looking;
using PandaQuest.Input.Movement;
using PandaQuest.Lifecycle;

namespace PandaQuest.Extensions;

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
			.AddSingleton<INoise2, GradientNoise2>();
	}

	public static IServiceCollection AddConfiguration(this IServiceCollection services)
	{
		var displayConfiguration = new DisplayConfiguration { Width = 800, Height = 480, FieldOfView = 90, };
		var finiteWorldConfiguration = new FiniteWorldConfiguration { Dimensions = new Vector2(8) };
		var mouseConfiguration = new MouseConfiguration { Sensitivity = .001f };
		var worldConfiguration = new WorldConfiguration { ChunkSize = 16, FlatLimit = 48, WorldHeight = 128, };
		var gradientNoiseConfiguration = new GradientNoiseConfiguration(4);

		return services
			.AddSingleton(displayConfiguration)
			.AddSingleton(finiteWorldConfiguration)
			.AddSingleton(mouseConfiguration)
			.AddSingleton(worldConfiguration)
			.AddSingleton(gradientNoiseConfiguration);
	}
}
