using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Rendering;

public interface IRenderer
{
	void Draw(Camera camera, IEnumerable<Block> blocks);
}
