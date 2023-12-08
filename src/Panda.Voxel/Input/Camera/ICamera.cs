using Microsoft.Xna.Framework;

namespace Panda.Voxel.Input.Camera;

public interface ICamera
{
	Matrix Projection { get; }

	Matrix View { get; }

	Vector3 Position { get; }

	void Update();

	void Rotate(float yaw, float pitch);

	void MoveTo(Vector3 moveVector);
}
