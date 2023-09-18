using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PandaQuest.Input;

public sealed class Player
{
    private readonly Camera camera;

    private Vector3 mouseRotationBuffer;
    private MouseState previousMouseState;

    public Player(Camera camera)
    {
        this.camera = camera;
    }

    public Camera Camera => this.camera;

    public void Update(GameTime gameTime)
    {
        this.CheckKeyboard();
        this.CheckMouse(gameTime);
    }

    private void CheckKeyboard()
    {
        Vector3 moveVector = Vector3.Zero;
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.W))
        {
            moveVector.Z = Constants.MOVE_SPEED;
        }

        if (keyboardState.IsKeyDown(Keys.S))
        {
            moveVector.Z = -Constants.MOVE_SPEED;
        }

        if (keyboardState.IsKeyDown(Keys.A))
        {
            moveVector.X = Constants.MOVE_SPEED;
        }

        if (keyboardState.IsKeyDown(Keys.D))
        {
            moveVector.X = -Constants.MOVE_SPEED;
        }

        if (keyboardState.IsKeyDown(Keys.Space))
        {
            moveVector.Y = Constants.MOVE_SPEED;
        }

        if (keyboardState.IsKeyDown(Keys.LeftControl))
        {
            moveVector.Y = -Constants.MOVE_SPEED;
        }

        if (moveVector != Vector3.Zero)
        {
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
