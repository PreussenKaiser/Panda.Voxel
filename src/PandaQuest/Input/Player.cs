using Microsoft.Xna.Framework;
using PandaQuest.Configuration;
using PandaQuest.Extensions;
using PandaQuest.Input.Looking;
using PandaQuest.Input.Movement;
using PandaQuest.States;

namespace PandaQuest.Input;

public sealed class Player
{
	public PlayerState State;

	private const int PLAYER_HEIGHT = 2;

	private readonly IMovement movement;
	private readonly MouseLooking looking;
	private readonly PlayerCamera camera;

	private Vector3 moveVector;

	public Player(PlayerCamera camera, IMovement movement)
	{
		this.camera = camera;
		this.movement = movement;
		this.looking = new MouseLooking(new MouseConfiguration(.001f));
	}

	public Vector3 Position => new(
		this.camera.Position.X,
		this.camera.Position.Y - PLAYER_HEIGHT,
		this.camera.Position.Z);

	public Vector3 MoveVector => this.moveVector;

	public PlayerCamera Camera => this.camera;

	public void Update()
	{
		Vector3 moveVector = this.movement.GetInput(this.State);
		this.MoveTo(moveVector);

		var aspectRatio = new Vector2(this.camera.Display.Width, this.camera.Display.Height);
		Vector2 input = this.looking.GetInput(aspectRatio);

		this.camera.Rotate(input.X, input.Y);
		this.camera.Update();
	}

	public void MoveTo(Vector3 moveVector)
	{
		this.moveVector = moveVector;
		this.State.IsFalling = moveVector.IsDescending();

		this.camera.MoveTo(moveVector);
	}
}
