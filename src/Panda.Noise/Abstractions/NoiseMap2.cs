namespace Panda.Noise.Abstractions;

public sealed class NoiseMap2
{
	public readonly byte[,] Value;
	public readonly bool WasInitialized;

	public NoiseMap2(int x, int y)
	{
		this.Value = new byte[x, y];
	}
}
