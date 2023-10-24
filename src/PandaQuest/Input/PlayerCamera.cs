using Microsoft.Xna.Framework;
using PandaQuest.Configuration;

namespace PandaQuest.Input;

public sealed class PlayerCamera : Camera
{
	public readonly Matrix Projection;
	public readonly DisplayConfiguration Display;

	private readonly BoundingFrustum frustum;

	private Vector3 position;
	private float yaw;
	private float pitch;
	private Matrix rotation;
	private Matrix view;
	private Vector3 up;
	private Vector3 forward;

	public PlayerCamera(Vector3 position, DisplayConfiguration configuration)
	{
		this.Display = configuration;

		var aspectRatio = (float)configuration.Width / (float)configuration.Height;
		this.Projection = Matrix.CreatePerspectiveFieldOfView(
			MathHelper.ToRadians(Constants.FIELD_OF_VIEW), aspectRatio, .01f, 1000);

		this.position = position;
		this.view = Matrix.Identity;
		this.frustum = new BoundingFrustum(this.view * this.Projection);
		this.up = Vector3.Up;
		this.forward = Vector3.UnitZ;
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
		this.Yaw += yaw;
		this.Pitch -= pitch;
	}

	public bool IsVisible(BoundingBox boundingBox)
	{
		return this.frustum.Intersects(boundingBox);
	}

	public void Update()
	{
		this.rotation = Matrix.CreateFromYawPitchRoll(this.yaw, this.pitch, 0);

		this.forward = Vector3.Transform(Vector3.UnitZ, this.rotation);
		this.up = Vector3.Transform(Vector3.Up, this.rotation);

		this.view = Matrix.CreateLookAt(this.position, this.position + this.forward, this.up);
		this.frustum.Matrix = this.view * this.Projection;
	}

	public void MoveTo(Vector3 moveVector)
	{
		Vector3 moveTransform = Vector3.Transform(moveVector, this.rotation);

		this.position += moveTransform;
	}
}
