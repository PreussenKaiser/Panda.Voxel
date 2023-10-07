using PandaQuest.Extensions;
using PandaQuest.Models;
using Microsoft.Xna.Framework;

namespace PandaQuest.Generators;

public static class MeshGenerator
{
	public static IEnumerable<BlockFace> Generate(IDictionary<Vector3, Block> blocks)
	{
		foreach (var pair in blocks)
		{
			Vector3 position = pair.Key;

			bool topBlock = blocks.ContainsKey(new Vector3(position.X, position.Y + 1, position.Z));
			bool bottomBlock = blocks.ContainsKey(new Vector3(position.X, position.Y - 1, position.Z));
			bool leftBlock = blocks.ContainsKey(new Vector3(position.X + 1, position.Y, position.Z));
			bool rightBlock = blocks.ContainsKey(new Vector3(position.X - 1, position.Y, position.Z));
			bool frontBlock = blocks.ContainsKey(new Vector3(position.X, position.Y, position.Z + 1));
			bool backBlock = blocks.ContainsKey(new Vector3(position.X, position.Y, position.Z - 1));

			if (!topBlock)
			{
				yield return new BlockFace(position.ToTopFace());
			}

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
		}
	}
}
