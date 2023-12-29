using Microsoft.Xna.Framework;

namespace Panda.Voxel.Models;

public readonly struct Block(BlockIndex id, Vector3 position)
{
	public readonly BlockIndex Id = id;
	public readonly Vector3 Position = position;
}
