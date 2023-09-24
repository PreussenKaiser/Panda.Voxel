using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PandaQuest.Input.CameraInput;

public sealed class MouseInput
{
    private readonly Vector2 screenCenter;
    private readonly float fieldOfView;

    private Vector3 mouseRotationBuffer;
    private MouseState previousMouseState;

    public MouseInput(Vector2 screenCenter)
    {
        this.screenCenter = screenCenter;
        this.fieldOfView = Constants.FIELD_OF_VIEW - .1f;
    }

    public Vector3 CheckRotation(GameTime gameTime)
    {
        MouseState currentMouseState = Mouse.GetState();

        if (currentMouseState != this.previousMouseState)
        {
            float deltaX = currentMouseState.X - this.screenCenter.X;
            float deltaY = currentMouseState.Y - this.screenCenter.Y;

            this.mouseRotationBuffer.X -= .1f * deltaX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.mouseRotationBuffer.Y -= .1f * deltaY * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (this.mouseRotationBuffer.Y < MathHelper.ToRadians(-this.fieldOfView))
            {
                this.mouseRotationBuffer.Y -= (mouseRotationBuffer.Y - MathHelper.ToRadians(-this.fieldOfView));
            }

            if (this.mouseRotationBuffer.Y > MathHelper.ToRadians(this.fieldOfView))
            {
                this.mouseRotationBuffer.Y -= (this.mouseRotationBuffer.Y - MathHelper.ToRadians(this.fieldOfView));
            }
        }

        Mouse.SetPosition((int)this.screenCenter.X, (int)this.screenCenter.Y);

        this.previousMouseState = currentMouseState;

        return new Vector3(
            -MathHelper.Clamp(mouseRotationBuffer.Y, MathHelper.ToRadians(-this.fieldOfView),
            MathHelper.ToRadians(this.fieldOfView)),
            MathHelper.WrapAngle(mouseRotationBuffer.X), 0);
    }
}
