using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Rendering;

public interface IRenderer
{
	void Draw(PlayerCamera camera, IEnumerable<Chunk> chunks);
}
