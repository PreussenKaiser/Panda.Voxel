using Microsoft.Xna.Framework;

namespace PandaQuest.Input;

public sealed class PlayerCamera
{
	public readonly Matrix Projection;

	private Vector3 position;
	private float yaw;
	private float pitch;
	private BoundingFrustum frustum;
	private Matrix rotation;
	private Matrix view;
	private Vector3 up;
	private Vector3 forward;

	public PlayerCamera(Vector3 position, float aspectRatio)
	{
		this.Projection = Matrix.CreatePerspectiveFieldOfView(
			MathHelper.ToRadians(Constants.FIELD_OF_VIEW), aspectRatio, .01f, 1000);

		this.position = position;
		this.view = Matrix.Identity;
		this.frustum = new BoundingFrustum(this.view * this.Projection);
		this.up = Vector3.Up;
		this.forward = Vector3.Forward;
	}

	public Vector3 Position => this.position;

	public Matrix View => this.view;

	public float Yaw
	{
		get => this.yaw;
		private set
		{
			this.yaw = value;

			while (this.yaw >= MathHelper.TwoPi)
			{
				this.yaw -= MathHelper.TwoPi;
			}

			while (this.yaw < 0)
			{
				this.yaw += MathHelper.TwoPi;
			}
		}
	}

	public float Pitch
	{
		get => this.pitch;
		private set => this.pitch = MathHelper.Clamp(value, -MathHelper.PiOver2, MathHelper.PiOver2);
	}

	public void Rotate(float yaw, float pitch)
	{
		if (!float.IsNaN(yaw))
		{
			this.Yaw += yaw;
		}

		if (!float.IsNaN(pitch))
		{
			this.Pitch += pitch;
		}
	}

	public bool IsVisible(BoundingBox boundingBox)
	{
		return this.frustum.Intersects(boundingBox);
	}

	public void Update(GameTime gameTime)
	{
		this.rotation = Matrix.CreateFromYawPitchRoll(this.yaw, this.pitch, 0);

		this.forward = Vector3.Transform(Vector3.Forward, this.rotation);
		this.up = Vector3.Transform(Vector3.Up, this.rotation);

		this.view = Matrix.CreateLookAt(this.position, this.position + this.forward, this.up);
		this.frustum.Matrix = this.view * this.Projection;
	}
}
