using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PandaQuest.Input;

public sealed class Camera
{
    private readonly Matrix projectionMatrix;
    private readonly Matrix worldMatrix;

    private readonly Vector2 screenCenter;

    private Vector3 target;
    private Vector3 position;
    private Matrix viewMatrix;
    private Vector2 cameraDelta;

    private MouseState previousMouseState;
    private MouseState currentMouseState;

    public Camera(GraphicsDevice graphicsDevice)
    {
        this.target = new Vector3(0, 0, 0);
        this.position = new Vector3(0, 0, -16);

        this.screenCenter = new Vector2(
            graphicsDevice.Viewport.Width / 2,
            graphicsDevice.Viewport.Height / 2);

        this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.ToRadians(90),
            graphicsDevice.DisplayMode.AspectRatio,
            1, 1000);

        this.viewMatrix = Matrix.CreateLookAt(this.position, this.target, new Vector3(0, 1, 0));
        this.worldMatrix = Matrix.CreateWorld(this.target, Vector3.Forward, Vector3.Up);

        this.currentMouseState = Mouse.GetState();

        Mouse.SetPosition((int)this.screenCenter.X, (int)this.screenCenter.Y);
    }

    public Matrix Projection => this.projectionMatrix;

    public Matrix View => this.viewMatrix;

    public Matrix World => this.worldMatrix;

    public void Update(GameTime gameTime)
    {
        this.UpdateKeyboard();
        this.UpdateMouse(gameTime);
    }

    private void UpdateKeyboard()
    {
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.W))
        {
            this.position.Z += 1;
        }

        if (keyboardState.IsKeyDown(Keys.S))
        {
            this.position.Z -= 1;
        }

        if (keyboardState.IsKeyDown(Keys.A))
        {
            this.position.X += 1;
            this.target.X += 1;
        }

        if (keyboardState.IsKeyDown(Keys.D))
        {
            this.position.X -= 1;
            this.target.X -= 1;
        }

        if (keyboardState.IsKeyDown(Keys.Space))
        {
            this.position.Y += 1;
            this.target.Y += 1;
        }

        if (keyboardState.IsKeyDown(Keys.LeftControl))
        {
            this.position.Y -= 1;
            this.target.Y -= 1;
        }

        this.viewMatrix = Matrix.CreateLookAt(this.position, this.target, Vector3.Up);
    }

    private void UpdateMouse(GameTime gameTime)
    {
        this.previousMouseState = this.currentMouseState;
        this.currentMouseState = Mouse.GetState();

        float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 20f;

        var currentMousePosition = new Vector2(this.currentMouseState.X, this.currentMouseState.Y);
        var previousMousePosition = new Vector2(this.previousMouseState.X, this.previousMouseState.Y);

        this.cameraDelta = Vector2.Clamp(
            delta * (currentMousePosition - previousMousePosition),
            new Vector2(-20, -20),
            new Vector2(20, 20));

        this.target.X -= this.cameraDelta.X;
        this.target.Y -= this.cameraDelta.Y;
    }
}
