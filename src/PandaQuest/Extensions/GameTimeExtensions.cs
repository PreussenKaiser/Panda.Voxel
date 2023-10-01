using Microsoft.Xna.Framework;
using PandaQuest.Models;

namespace PandaQuest.Extensions;

public static class GameTimeExtensions
{
	public static GameContextTime ToGameContextTime(this GameTime gameTime)
		=> new(gameTime.TotalGameTime, gameTime.ElapsedGameTime);
}
