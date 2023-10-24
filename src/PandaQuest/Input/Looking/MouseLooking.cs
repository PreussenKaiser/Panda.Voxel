using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Configuration;

namespace PandaQuest.Input.Looking;

public sealed class MouseLooking
{
	private readonly MouseConfiguration mouse;
	private readonly DisplayConfiguration display;
	private readonly Vector2 screenCenter;

	private MouseState previousState;

	public MouseLooking(MouseConfiguration mouseConfiguration, DisplayConfiguration displayConfiguration)
	{
		this.mouse = mouseConfiguration;
		this.display = displayConfiguration;
		this.screenCenter = new Vector2(displayConfiguration.Width / 2, displayConfiguration.Height / 2);

		MouseState state = Mouse.GetState();
		this.previousState = state;
	}

	public Vector2 GetInput(GameTime gameTime)
	{
		MouseState currentState = Mouse.GetState();

		if (currentState == this.previousState)
		{
			return Vector2.Zero;
		}

		float deltaX = this.screenCenter.X - currentState.X;
		float deltaY = this.screenCenter.Y - currentState.Y;

		var lookVector = new Vector2(deltaX * this.mouse.Sensitity, deltaY * this.mouse.Sensitity);

		Mouse.SetPosition((int)this.screenCenter.X, (int)this.screenCenter.Y);
		
		this.previousState = currentState;

		return lookVector;
	}
}
