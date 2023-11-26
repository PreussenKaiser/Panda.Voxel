namespace Panda.Noise.Configuration;

public sealed class GradientNoiseConfiguration(byte density, int seed = 0)
{
	public readonly byte Density = density;  
	public readonly int Seed = seed;
}
