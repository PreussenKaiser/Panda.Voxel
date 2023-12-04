namespace Panda.Noise.Configuration;

public sealed class PerlinNoiseConfiguration(float frequency = 1.01f, ushort permutatations = 256, int seed = 0)
{
	public readonly float Frequency = frequency;
	public readonly ushort Permutations = permutatations;
	public readonly int Seed = seed;
}
