using Microsoft.Xna.Framework;
using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Physics;

public sealed class OverworldPhysics : IPhysics
{
	// TODO: Only calculate physics against mesh.
	public void Update(BlockCollection blocks, Player player, GameTime gameTime)
	{
		var playerPositionCeiling = new Vector3(
			(float)Math.Round(player.Position.X),
			(float)Math.Round(player.Position.Y),
			(float)Math.Ceiling(player.Position.Z));

		var moveVector = new Vector3(
			CalculateXVector(playerPositionCeiling, blocks),
			CalculateYVector(playerPositionCeiling, blocks),
			CalculateZVector(playerPositionCeiling, player.MoveVector.Z, blocks));

		player.MoveTo(moveVector);
	}

	private static float CalculateXVector(Vector3 position, BlockCollection blocks)
	{
		// TODO: Finish

		return 0;
	}

	private static float CalculateYVector(Vector3 position, BlockCollection blocks)
	{
		// TODO: Above block collision.
		// var aboveBlockPosition = new Vector3(position.X, position.Y + 2, position.Z);
		var belowBlockPosition = new Vector3(position.X, position.Y, position.Z);

		bool collision = !blocks.IsEmpty(belowBlockPosition);

		return collision ? 0 : -.1f;
	}

	private static float CalculateZVector(Vector3 position, float moveVectorZ, BlockCollection blocks)
	{
		// TODO: Finish

		// var frontBlockPosition = new Vector3(position.X, position.Y, position.Z + 1);

		// bool collision = blocks.Any(b => b.Position == frontBlockPosition);

		return 0; // collision ? 0 : moveVectorZ;
	}
}
