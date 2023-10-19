using Microsoft.Xna.Framework;
using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Physics;

public interface IPhysics
{
	void Update(BlockCollection blocks, Player player, GameTime gameTime);
}
