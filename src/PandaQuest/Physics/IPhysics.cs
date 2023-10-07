using Microsoft.Xna.Framework;
using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Physics;

public interface IPhysics
{
	void Update(IDictionary<Vector3, Block> blocks, Player player, GameContextTime gameTime);
}
