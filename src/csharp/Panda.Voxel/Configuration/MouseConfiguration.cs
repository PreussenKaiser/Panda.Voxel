namespace Panda.Voxel.Configuration;

// Will contain more options like IsInverted.
public sealed class MouseConfiguration(float sensitivity)
{
	public readonly float Sensitivity = sensitivity;
}
