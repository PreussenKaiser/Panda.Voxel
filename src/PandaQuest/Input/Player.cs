using Microsoft.Xna.Framework;
using PandaQuest.Input.Movement;

namespace PandaQuest.Input;

public sealed class Player
{
    private readonly IMovement movement;

    private Vector3 position;
    private Vector3 moveVector;

    public Player(Vector3 position)
    {
        this.position = position;
        this.movement = new GroundedMovement();
    }

    public Vector3 Position => this.position;

    public Vector3 MoveVector
    {
        get => this.moveVector;
        set
        {
            this.moveVector = value;

            this.position += value;
        }
    }

    public void Update(GameTime gameTime)
    {
        this.MoveVector = this.movement.GetInput();
    }
}
