using PandaQuest;
using PandaQuest.Contexts;
using PandaQuest.Extensions;

Game.CreateDefaultBuilder()
	.ConfigureServices(services => services
		.AddGame<VoxelGame>()
		.AddRendering()
		.AddMovement(true)
		.AddPcInput()
		.AddPlayer()
		.AddFiniteWorldGeneration()
		.AddConfiguration())
	.Build()
	.Run();
