using Panda.Voxel;
using Panda.Voxel.Lifecycle;
using Panda.Voxel.Extensions;
using Panda.Voxel.Generators;
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
