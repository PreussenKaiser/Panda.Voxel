using Microsoft.Xna.Framework;

namespace PandaQuest.Models;

public readonly struct Block
{
	public readonly BlockIndex Id;
	public readonly Vector3 Position;

	public Block(BlockIndex id, Vector3 position)
	{
		this.Id = id;
		this.Position = position;
	}
}
