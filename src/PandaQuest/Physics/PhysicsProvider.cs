using Microsoft.Xna.Framework;
using PandaQuest.Input;
using PandaQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaQuest.Physics;

public sealed class PhysicsProvider
{
    public void Update(IEnumerable<Block> blocks, Player player, GameTime gameTime)
    {
        var playerPositionCeiling = new Vector3(
            (float)Math.Ceiling(player.Position.X),
            (float)Math.Ceiling(player.Position.Y),
            (float)Math.Ceiling(player.Position.Z));

        var aboveBlockPosition = new Vector3(playerPositionCeiling.X, playerPositionCeiling.Y + 2, playerPositionCeiling.Z);
        var belowBlockPosition = new Vector3(playerPositionCeiling.X, playerPositionCeiling.Y, playerPositionCeiling.Z);

        float moveVectorY = blocks.Any(b => b.Position == belowBlockPosition) ? 0 : -Constants.MOVE_SPEED;

        player.MoveTo(
            new Vector3(0, moveVectorY, 0),
            gameTime);
    }

    private float CalculateYVector(Vector3 position)
    {
        throw new NotImplementedException();
    }
}
