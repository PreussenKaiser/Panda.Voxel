using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Panda.Voxel.Configuration;

namespace Panda.Voxel.Input.Looking;

public sealed class MouseLooking(MouseConfiguration mouseConfiguration, DisplayConfiguration displayConfiguration)
{
	private readonly MouseConfiguration mouse = mouseConfiguration;
	private readonly Vector2 screenCenter = new(displayConfiguration.Width / 2, displayConfiguration.Height / 2);

	private MouseState previousState = Mouse.GetState();

	public Vector2 GetInput(GameTime gameTime)
	{
		MouseState currentState = Mouse.GetState();

		if (currentState == this.previousState)
		{
			return Vector2.Zero;
		}

		float deltaX = this.screenCenter.X - currentState.X;
		float deltaY = this.screenCenter.Y - currentState.Y;

		var lookVector = new Vector2(deltaX * this.mouse.Sensitivity, deltaY * this.mouse.Sensitivity);

		Mouse.SetPosition((int)this.screenCenter.X, (int)this.screenCenter.Y);
		
		this.previousState = currentState;

		return lookVector;
	}
}
