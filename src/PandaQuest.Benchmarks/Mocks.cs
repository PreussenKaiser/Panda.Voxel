using Microsoft.Xna.Framework;
using Panda.Noise.Gradient;
using PandaQuest.Configuration;
using PandaQuest.Contexts;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.Movement;
using PandaQuest.Physics;

namespace PandaQuest.Benchmarks;

internal static class Mocks
{
	internal readonly static PlayerCamera Camera = new(Vector3.Zero, new DisplayConfiguration(0, 0));
	internal readonly static IMovement Movement = new GroundedMovement();
	internal readonly static Player Player = new(Camera, Movement);
	internal readonly static IWorldGenerator WorldGenerator = new InfiniteWorldGenerator(Player, new GradientNoise2(0));
	internal readonly static IPhysics Physics = new OverworldPhysics();
	internal readonly static World WorldContext = new(Player, Physics, WorldGenerator);
	internal readonly static GameTime GameTime = new();
}
