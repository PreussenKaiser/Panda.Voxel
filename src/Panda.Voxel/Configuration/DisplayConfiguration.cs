namespace Panda.Voxel.Configuration;

public sealed class DisplayConfiguration(int width, int height, int fieldOfView)
{
	public readonly int Width = width;
	public readonly int Height = height;
	public readonly int FieldOfView = fieldOfView;
}
