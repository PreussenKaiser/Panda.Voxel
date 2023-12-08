namespace Panda.Voxel.Configuration;

public sealed class WorldConfiguration
{
	public required byte ChunkSize { get; init; }

	public required byte WorldHeight { get; init; }

	/// <remarks>
	/// Blocks will be generated to this point before noise does the rest.
	/// </remarks>
	public required byte FlatLimit { get; init; }
}