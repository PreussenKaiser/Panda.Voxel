using Microsoft.Xna.Framework;
using PandaQuest.Contexts;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.Movement;
using PandaQuest.Physics;
using PandaQuest.Time;

namespace PandaQuest.Benchmarks;

internal static class Mocks
{
	internal readonly static PlayerCamera Camera = new(Vector3.Zero, 0);
	internal readonly static IMovement Movement = new GroundedMovement();
	internal readonly static Player Player = new(Camera, Movement);
	internal readonly static IWorldGenerator WorldGenerator = new InfiniteWorldGenerator(Player);
	internal readonly static IPhysics Physics = new OverworldPhysics();
	internal readonly static ITimeProvider Time = new OverworldTimeProvider();
	internal readonly static World WorldContext = new(Player, Physics, WorldGenerator, Time);
	internal readonly static GameTime GameTime = new();
}
