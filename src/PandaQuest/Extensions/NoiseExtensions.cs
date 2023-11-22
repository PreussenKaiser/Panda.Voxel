using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using PandaQuest.Configuration;
using PandaQuest.Models;

namespace PandaQuest.Extensions;

public static class NoiseExtensions
{
	public static BlockIndex GetBlockIndex(this INoise noise, Vector3 position, WorldConfiguration configuration)
	{
		var x = (int)position.X;
		var y = (int)position.Y;

		int value = noise.GetValue(x, y);
		int surfaceY = value + configuration.FlatLimit;

		var index = y < surfaceY ? BlockIndex.Dirt : BlockIndex.Air;

		return index;
	}
}
