using PandaQuest;
using PandaQuest.Lifecycle;
using PandaQuest.Extensions;
using PandaQuest.Generators;
using Panda.Noise.Gradient;

Game.CreateDefaultBuilder()
	.ConfigureServices(services => services
		.AddGame<VoxelGame>()
		.AddMovement(true)
		.AddPcInput()
		.AddPlayer()
		.AddWorldGeneration<FiniteWorldGenerator, PerlinNoise2>()
		.AddConfiguration())
	.Build()
	.Run();
