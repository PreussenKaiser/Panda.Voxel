namespace Panda.Voxel.Configuration;

public sealed class WorldConfiguration(byte chunkSize, byte worldHeight, byte flatLimit)
{
	public readonly byte ChunkSize = chunkSize;
	public readonly byte WorldHeight = worldHeight;

	/// <remarks>
	/// Blocks will be generated to this point before noise does the rest.
	/// </remarks>
	public readonly byte FlatLimit = flatLimit;
}