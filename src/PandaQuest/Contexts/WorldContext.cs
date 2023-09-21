using Microsoft.Xna.Framework;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Physics;
using PandaQuest.Time;

namespace PandaQuest.Contexts;

public sealed class WorldContext
{
    public readonly Player Player;
    public readonly IWorldGenerator Generation;

    private readonly PhysicsProvider physics;
    private readonly ITimeProvider timeProvider;

    public WorldContext(Player player, PhysicsProvider physicsProvider, IWorldGenerator worldGenerator, ITimeProvider timeProvider)
    {
        this.Player = player;
        this.physics = physicsProvider;
        this.Generation = worldGenerator;
        this.timeProvider = timeProvider;
    }

    public void Update(GameTime gameTime)
    {
        this.Generation.Generate();
        this.Player.Update(gameTime);
        this.physics.Update(this.Player, this.Generation.Blocks);
    }
}
