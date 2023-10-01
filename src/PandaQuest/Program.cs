
using PandaQuest.Contexts;

using var game = GameContext
	.CreateBuilder()
	.Build();

game.Run();
