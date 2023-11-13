using PandaQuest;
using PandaQuest.Lifecycle;
using PandaQuest.Extensions;
using PandaQuest.Generators;

Game.CreateDefaultBuilder()
	.ConfigureServices(services => services
		.AddGame<VoxelGame>()
		.AddMovement(true)
		.AddPcInput()
		.AddPlayer()
		.AddWorldGeneration<FiniteWorldGenerator>()
		.AddConfiguration())
	.Build()
	.Run();
