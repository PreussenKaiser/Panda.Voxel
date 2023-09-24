using Microsoft.Xna.Framework;
using PandaQuest.Input;
using PandaQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaQuest.Physics;

public sealed class PhysicsProvider
{
    public void Update(Player player, IEnumerable<Block> blocks)
    {
        double belowPlayer = Math.Ceiling(player.Position.Y);
        bool collision = blocks.Any(b => b.Position.Y == belowPlayer);

        float yMoveVector = collision ? 0 : -Constants.MOVE_SPEED;

        player.MoveVector = new Vector3(
            player.MoveVector.X,
            yMoveVector,
            player.MoveVector.Z);
    }
}
