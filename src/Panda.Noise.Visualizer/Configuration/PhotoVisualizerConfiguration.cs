namespace Panda.Noise.Visualizer.Configuration;

public sealed class PhotoVisualizerConfiguration(string filePath, int width, int height)
{
	public readonly string FilePath = filePath;
	public readonly int Width = width;
	public readonly int Height = height;
}
