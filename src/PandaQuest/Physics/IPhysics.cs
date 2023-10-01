using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Physics;

public interface IPhysics
{
	void Update(IEnumerable<Block> blocks, Player player, GameContextTime gameTime);
}
