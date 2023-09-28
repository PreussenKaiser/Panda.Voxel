using Microsoft.Xna.Framework;
using PandaQuest.Extensions;
using PandaQuest.Input.Movement;
using PandaQuest.States;

namespace PandaQuest.Input;

public sealed class Player
{
    public PlayerState State;

    private const int PLAYER_HEIGHT = 2;

    private readonly Camera camera;
    private readonly IMovement movement;

    private Vector3 moveVector;

    public Player(Camera camera, IMovement movement)
    {
        this.camera = camera;
        this.movement = movement;
    }

    public Vector3 Position => new Vector3(
        this.camera.Position.X,
        this.camera.Position.Y - PLAYER_HEIGHT,
        this.camera.Position.Z);

    public Vector3 MoveVector => this.moveVector;

    public void Update(GameTime gameTime)
    {
        this.moveVector = this.movement.GetInput(this.State);
        this.MoveTo(this.moveVector, gameTime);
    }

    public void MoveTo(Vector3 moveVector, GameTime gameTime)
    {
        this.moveVector = moveVector;
        this.State.IsFalling = moveVector.IsDescending();

        this.camera.MoveTo(moveVector, gameTime);
    }
}
