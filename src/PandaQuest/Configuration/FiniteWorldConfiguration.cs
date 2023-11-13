using Microsoft.Xna.Framework;

namespace PandaQuest.Configuration;

public sealed class FiniteWorldConfiguration
{
	/// <summary>
	/// Length and width od the generated map.
	/// </summary>
	public required Vector2 Dimensions { get; init; }
}
