using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Configuration;

namespace PandaQuest.Input.Looking;

public sealed class MouseLooking : ILooking
{
	private readonly MouseConfiguration configuration;

	private MouseState previousState;

	public MouseLooking(MouseConfiguration configuration)
	{
		this.configuration = configuration;

		MouseState state = Mouse.GetState();
		this.previousState = state;
		this.previousState = state;
	}

	public Vector2 GetInput(Vector2 aspectRatio)
	{
		MouseState currentState = Mouse.GetState();

		var input = new Vector2(
			(this.previousState.X - currentState.X) * this.configuration.Sensitity,
			(this.previousState.Y - currentState.Y) * this.configuration.Sensitity);

		this.previousState = currentState;

		//Mouse.SetPosition(
		//	(int)aspectRatio.X / 2,
		//	(int)aspectRatio.Y / 2);

		return input;
	}
}
