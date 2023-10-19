using Microsoft.Xna.Framework;

namespace PandaQuest.Models;

public readonly struct Block
{
	public readonly BlockIndex Id;

	public Block(BlockIndex id)
	{
		this.Id = id;
	}
}
