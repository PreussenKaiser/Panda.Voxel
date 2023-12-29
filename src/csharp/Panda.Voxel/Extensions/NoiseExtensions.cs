using Microsoft.Xna.Framework;
using Panda.Extensions;
using Panda.Noise.Abstractions;
using Panda.Voxel.Configuration;
using Panda.Voxel.Models;

namespace Panda.Voxel.Extensions;

public static class NoiseExtensions
{
	public static BlockIndex GetBlockIndex(this INoise2 noise, Vector3 position, WorldConfiguration configuration)
	{
		float value = noise.GetValue(position.X, position.Z);
		float surfaceY = value.Scale(configuration.WorldHeight);

		var index = position.Y < surfaceY ? BlockIndex.Dirt : BlockIndex.Air;

		return index;
	}
}
