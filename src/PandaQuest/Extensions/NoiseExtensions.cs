using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using PandaQuest.Configuration;
using PandaQuest.Models;

namespace PandaQuest.Extensions;

public static class NoiseExtensions
{
	public static BlockIndex GetBlockIndex(this INoise2 noise, Vector3 position, WorldConfiguration configuration)
	{
		float value = noise.GetValue(position.X, position.Z);
		float surfaceY = value + configuration.FlatLimit;

		var index = position.Z < surfaceY ? BlockIndex.Dirt : BlockIndex.Air;

		return index;
	}
}
