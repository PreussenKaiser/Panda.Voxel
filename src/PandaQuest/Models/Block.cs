using Microsoft.Xna.Framework;

namespace PandaQuest.Models;

public readonly struct Block
{
	public readonly Vector3 Position;

	public Block(Vector3 position)
	{
		this.Position = position;
	}
}
