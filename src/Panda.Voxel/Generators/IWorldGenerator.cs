using Panda.Voxel.Models;

namespace Panda.Voxel.Generators;

public interface IWorldGenerator
{
	IEnumerable<Chunk> Chunks { get; }

	IEnumerable<BlockFace> Mesh { get; }

	void Generate();
}
