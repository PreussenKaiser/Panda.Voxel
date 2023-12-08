using Microsoft.Xna.Framework.Graphics;

namespace Panda.Voxel.Models;

public readonly struct BlockFace(VertexPositionTexture[] vertices)
{
	public readonly VertexPositionTexture[] Vertices = vertices;
}
