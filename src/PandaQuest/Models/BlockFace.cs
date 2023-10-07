using Microsoft.Xna.Framework.Graphics;

namespace PandaQuest.Models;

public readonly struct BlockFace
{
	public readonly VertexPositionTexture[] Vertices;

	public BlockFace(VertexPositionTexture[] vertices)
	{
		this.Vertices = vertices;
	}
}
