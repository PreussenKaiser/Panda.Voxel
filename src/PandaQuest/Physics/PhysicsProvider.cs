using Microsoft.Xna.Framework;
using PandaQuest.Input;
using PandaQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaQuest.Physics;

public sealed class PhysicsProvider
{
    public void Update(IEnumerable<Block> blocks, Vector3 playerPosition, ref Vector3 moveVector)
    {
        var playerPositionCeiling = new Vector3(
            (float)Math.Ceiling(playerPosition.X),
            (float)Math.Ceiling(playerPosition.Y),
            (float)Math.Ceiling(playerPosition.Z));

        var aboveBlockPosition = new Vector3(playerPositionCeiling.X, playerPositionCeiling.Y + 2, playerPositionCeiling.Z);
        var belowBlockPosition = new Vector3(playerPositionCeiling.X, playerPositionCeiling.Y, playerPositionCeiling.Z);

        moveVector.Y = blocks.Any(b => b.Position == belowBlockPosition) ? 0 : -Constants.MOVE_SPEED;

    }

    public float CalculateYVector()
    {
        throw new NotImplementedException();
    }
}
