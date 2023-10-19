using PandaQuest.Extensions;
using PandaQuest.Models;
using Microsoft.Xna.Framework;

namespace PandaQuest.Generators;

public static class MeshGenerator
{
	public static IEnumerable<BlockFace> Generate(BlockCollection blocks)
	{
		for (var x = 0; x < Constants.CHUNK_SIZE; x++)
		{
			for (var y = 0; y < Constants.WORLD_HEIGHT; y++)
			{
				for (var z = 0; z < Constants.CHUNK_SIZE; z++)
				{
					var position = new Vector3(x, y, z);

					bool topBlockEmpty = blocks.IsEmpty(new Vector3(position.X, position.Y + 1, position.Z));

					/*
					bool bottomBlock = blocks.ContainsKey(new Vector3(position.X, position.Y - 1, position.Z));
					bool leftBlock = blocks.ContainsKey(new Vector3(position.X + 1, position.Y, position.Z));
					bool rightBlock = blocks.ContainsKey(new Vector3(position.X - 1, position.Y, position.Z));
					bool frontBlock = blocks.ContainsKey(new Vector3(position.X, position.Y, position.Z + 1));
					bool backBlock = blocks.ContainsKey(new Vector3(position.X, position.Y, position.Z - 1));
					*/

					if (topBlockEmpty)
					{
						yield return new BlockFace(position.ToTopFace());
					}

					/*
					if (!bottomBlock)
					{
						yield return new BlockFace(position.ToBottomFace());
					}

					if (!frontBlock)
					{
						yield return new BlockFace(position.ToFrontFace());
					}

					if (!backBlock)
					{
						yield return new BlockFace(position.ToBackFace());
					}

					if (!leftBlock)
					{
						yield return new BlockFace(position.ToLeftFace());
					}

					if (!rightBlock)
					{
						yield return new BlockFace(position.ToRightFace());
					}
					*/
				}
			}
		}
	}
}
