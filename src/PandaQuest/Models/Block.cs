using Microsoft.Xna.Framework;
using PandaQuest.Extensions;

namespace PandaQuest.Models;

public sealed class Block
{
	public readonly Vector3 Position;
	public readonly BlockFace[] Faces;

	public Block(Vector3 position)
	{
		this.Position = position;
		this.Faces = new BlockFace[6]
		{
			new BlockFace(position.ToFrontFace()),
			new BlockFace(position.ToBackFace()),
			new BlockFace(position.ToLeftFace()),
			new BlockFace(position.ToRightFace()),
			new BlockFace(position.ToTopFace()),
			new BlockFace(position.ToBottomFace())
		};
	}

	public void EnableFace(CubeFace face)
	{
		BlockFace blockFace = this.Faces[(int)face];

		blockFace.IsVisible = true;
	}

	public void DisableFace(CubeFace face)
	{
		BlockFace blockFace = this.Faces[(int)face];

		blockFace.IsVisible = false;
	}
}
