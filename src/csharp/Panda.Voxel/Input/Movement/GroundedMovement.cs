﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Panda.Voxel.States;

namespace Panda.Voxel.Input.Movement;

public sealed class GroundedMovement : IMovement
{
    public Vector3 GetInput(PlayerState playerState)
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

        if (keyboardState.IsKeyDown(Keys.Space) && !playerState.IsFalling)
        {
            moveVector.Y = 2;
        }

        return moveVector;
    }
}
