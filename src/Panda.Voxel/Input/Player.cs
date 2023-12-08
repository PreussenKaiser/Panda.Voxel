using Microsoft.Xna.Framework;
using Panda.Voxel.Extensions;
using Panda.Voxel.Input.Camera;
using Panda.Voxel.Input.Looking;
using Panda.Voxel.Input.Movement;
using Panda.Voxel.States;

namespace Panda.Voxel.Input;

public sealed class Player
{
	public PlayerState State;

	private const int PLAYER_HEIGHT = 2;

	private readonly ICamera camera;
	private readonly IMovement movement;
	private readonly MouseLooking looking;

	private Vector3 moveVector;

	public Player(ICamera camera, IMovement movement, MouseLooking looking)
	{
		this.camera = camera;
		this.movement = movement;
		this.looking = looking;
	}

	public Vector3 Position => new(
		this.camera.Position.X,
		this.camera.Position.Y - PLAYER_HEIGHT,
		this.camera.Position.Z);

	public Vector3 MoveVector => this.moveVector;

	public ICamera Camera => this.camera;

	public void Update(GameTime gameTime)
	{
		Vector3 moveVector = this.movement.GetInput(this.State);
		this.MoveTo(moveVector);

		Vector2 input = this.looking.GetInput(gameTime);

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
