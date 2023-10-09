using Microsoft.Xna.Framework;
using PandaQuest.Input.CameraInput;
using PandaQuest.Models;

namespace PandaQuest.Input;

public sealed class Camera
{
    public readonly Matrix Projection;

    private readonly MouseInput input;

    private Vector3 position;
    private Vector3 target;
    private Vector3 rotation;
	private BoundingFrustum frustrum;

    public Camera(MouseInput input, Vector3 position, float aspectRatio)
    {
        this.input = input;
        this.position = position;

        this.Projection = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.ToRadians(Constants.FIELD_OF_VIEW), aspectRatio, .01f, 1000);

		this.frustrum = new BoundingFrustum(Matrix.Identity * this.Projection);
    }

    public Vector3 Position => this.position;

    public Matrix View => Matrix.CreateLookAt(this.position, this.target, Vector3.Up);

    public void MoveTo(Vector3 position, GameContextTime gameTime)
    {
        this.SetPosition(position);
        this.SetRotation(this.input.CheckRotation(gameTime));
    }

	public bool CanSee(BoundingBox boundingBox)
	{
		return this.frustrum.Intersects(boundingBox);
	}

    private void SetRotation(Vector3 position)
    {
        this.rotation = position;

        this.UpdateTarget();
    }

    private void SetPosition(Vector3 position)
    {
        Matrix rotationMatrix = Matrix.CreateRotationY(this.rotation.Y);
        Vector3 moveTransform = Vector3.Transform(position, rotationMatrix);

        this.position += moveTransform;

        this.UpdateTarget();
    }

    private void UpdateTarget()
    {
        Matrix rotationMatrix = Matrix.CreateRotationX(this.rotation.X) * Matrix.CreateRotationY(this.rotation.Y);
        Vector3 targetOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);

        this.target = this.position + targetOffset;
		this.frustrum.Matrix = this.View * this.Projection;
    }
}
