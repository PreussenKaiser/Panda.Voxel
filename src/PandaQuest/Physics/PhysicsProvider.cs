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
        var belowPlayerPosition = player.Position - new Vector3(0, 1, 0);
        double belowCeilingY = Math.Ceiling(belowPlayerPosition.Y);
        double playerCeilingY = Math.Ceiling(player.Position.Y);

        bool collision = blocks.Any(block => belowCeilingY == playerCeilingY);

        if (collision)
        {
            player.Position = 
        }
    }
}
