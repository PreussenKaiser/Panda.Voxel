using PandaQuest;
using PandaQuest.Contexts;
using PandaQuest.Extensions;

Game.CreateDefaultBuilder()
	.ConfigureServices(services => services
		.AddGame<VoxelGame>()
		.AddMovement(true)
		.AddPcInput()
		.AddPlayer()
		.AddWorldGeneration()
		.AddConfiguration())
	.Build()
	.Run();
