using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PandaQuest.Input;

public sealed class Camera
{
    private Vector3 position;
    private Vector3 target;
    private Vector3 rotation;

    public Camera(GraphicsDevice graphicsDevice)
    {
        this.position = new Vector3(0, 2, 0);

        this.ScreenCenter = new Vector2(
            graphicsDevice.Viewport.Width / 2,
            graphicsDevice.Viewport.Height / 2);

        this.Projection = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.ToRadians(90),
            graphicsDevice.DisplayMode.AspectRatio,
            .1f, 1000);
    }

    public Vector2 ScreenCenter { get; }

    public Matrix Projection { get; }

    public Matrix View => Matrix.CreateLookAt(this.position, this.target, Vector3.Up);

    public Vector3 PreviewMove(Vector3 moveVector)
    {
        Matrix rotationMatrix = Matrix.CreateRotationY(this.rotation.Y);
        Vector3 moveTransform = Vector3.Transform(moveVector, rotationMatrix);

        return this.position + moveTransform;
    }

    public void SetPosition(Vector3 position)
    {
        this.position = this.PreviewMove(position);

        this.UpdateTarget();
    }

    public void SetRotation(Vector3 rotation)
    {
        this.rotation = rotation;

        this.UpdateTarget();
    }

    private void UpdateTarget()
    {
        Matrix rotationMatrix = Matrix.CreateRotationX(this.rotation.X) * Matrix.CreateRotationY(this.rotation.Y);
        Vector3 targetOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);

        this.target = this.position + targetOffset;
    }
}
