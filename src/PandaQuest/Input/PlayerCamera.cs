using Microsoft.Xna.Framework;
using PandaQuest.Input.CameraInput;

namespace PandaQuest.Input;

public sealed class PlayerCamera
{
    public readonly Matrix Projection;

    private readonly Player player;
    private readonly MouseInput input;
    private const float Y_OFFSET = 2;

    private Vector3 position;
    private Vector3 target;
    private Vector3 rotation;

    public PlayerCamera(Player player, MouseInput input, float aspectRatio)
    {
        this.player = player;
        this.input = input;
        this.position = player.Position + new Vector3(0, Y_OFFSET, 0);

        this.Projection = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.ToRadians(Constants.FIELD_OF_VIEW), aspectRatio, .1f, 1000);
    }

    public Matrix View => Matrix.CreateLookAt(this.position, this.target, Vector3.Up);

    public void Update(GameTime gameTime)
    {
        this.SetPosition(this.player.MoveVector);
        this.SetRotation(this.input.CheckRotation(gameTime));
    }

    private void SetRotation(Vector3 value)
    {
        this.rotation = value;

        this.UpdateTarget();
    }

    private void SetPosition(Vector3 value)
    {
        Matrix rotationMatrix = Matrix.CreateRotationY(this.rotation.Y);
        Vector3 moveTransform = Vector3.Transform(value, rotationMatrix);

        this.position += moveTransform;
        this.position.Y = this.player.Position.Y + Y_OFFSET;

        this.UpdateTarget();
    }

    private void UpdateTarget()
    {
        Matrix rotationMatrix = Matrix.CreateRotationX(this.rotation.X) * Matrix.CreateRotationY(this.rotation.Y);
        Vector3 targetOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);

        this.target = this.position + targetOffset;
    }
}
