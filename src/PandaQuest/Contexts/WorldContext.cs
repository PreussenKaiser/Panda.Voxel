using Microsoft.Xna.Framework;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.Movement;
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
        var movement = new GroundedMovement();
        var moveVector = movement.GetInput();

        this.Generation.Generate();
        this.physics.Update(this.Generation.Blocks, this.Player.Position, ref moveVector);

        this.Player.MoveVector = moveVector;
    }
}
