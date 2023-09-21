using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Input.Movement;

namespace PandaQuest.Input;

public sealed class Player
{
    public Vector3 Position;

    private readonly Camera camera;

    private readonly IMovement movement;
    private Vector3 mouseRotationBuffer;
    private MouseState previousMouseState;

    public Player(Camera camera, Vector3 position)
    {
        this.Position = position;
        this.camera = camera;
        this.movement = new FlyingMovement();
    }

    public Camera Camera => this.camera;

    public void Update(GameTime gameTime)
    {
        this.CheckKeyboard();
        this.CheckMouse(gameTime);
    }

    private void CheckKeyboard()
    {
        Vector3 moveVector = this.movement.GetInput();

        if (moveVector != Vector3.Zero)
        {
            this.Position += moveVector;

            this.camera.SetPosition(moveVector);
        }
    }

    private void CheckMouse(GameTime gameTime)
    {
        MouseState currentMouseState = Mouse.GetState();

        if (currentMouseState != this.previousMouseState)
        {
            float deltaX = currentMouseState.X - this.camera.ScreenCenter.X;
            float deltaY = currentMouseState.Y - this.camera.ScreenCenter.Y;

            this.mouseRotationBuffer.X -= 0.1f * deltaX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.mouseRotationBuffer.Y -= 0.1f * deltaY * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (this.mouseRotationBuffer.Y < MathHelper.ToRadians(-75.0f))
            {
                this.mouseRotationBuffer.Y -= (mouseRotationBuffer.Y - MathHelper.ToRadians(-75.0f));
            }

            if (mouseRotationBuffer.Y > MathHelper.ToRadians(75.0f))
            {
                this.mouseRotationBuffer.Y -= (this.mouseRotationBuffer.Y - MathHelper.ToRadians(75.0f));
            }

            camera.SetRotation(new Vector3(
                -MathHelper.Clamp(mouseRotationBuffer.Y, MathHelper.ToRadians(-75.0f),
                MathHelper.ToRadians(75.0f)),
                MathHelper.WrapAngle(mouseRotationBuffer.X), 0));
        }

        Mouse.SetPosition((int)this.camera.ScreenCenter.X, (int)this.camera.ScreenCenter.Y);

        this.previousMouseState = currentMouseState;
    }
}
