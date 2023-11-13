using PandaQuest.Models;

namespace PandaQuest.Generators;

public interface IWorldGenerator
{
	IEnumerable<Chunk> Chunks { get; }

	IEnumerable<BlockFace> Mesh { get; }

	void Generate();
}
