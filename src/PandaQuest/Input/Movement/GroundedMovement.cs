using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PandaQuest.Input.Movement;

public sealed class GroundedMovement : IMovement
{
    public Vector3 GetInput()
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

        return moveVector;
    }
}
