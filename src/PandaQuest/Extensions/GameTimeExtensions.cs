using Microsoft.Xna.Framework;

namespace PandaQuest.Extensions;

public static class GameTimeExtensions
{
	public static GameTime ToGameContextTime(this GameTime gameTime)
		=> new(gameTime.TotalGameTime, gameTime.ElapsedGameTime);
}
