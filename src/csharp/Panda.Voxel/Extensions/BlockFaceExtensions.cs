using Microsoft.Xna.Framework.Graphics;
using Panda.Voxel.Models;

namespace Panda.Voxel.Extensions;

public static class BlockFaceExtensions
{
	private const int FACE_VERTICES = 6;

	public static VertexPositionTexture[] ToVertices(this IEnumerable<BlockFace> mesh)
	{
		var vertices = new VertexPositionTexture[mesh.Count() * FACE_VERTICES];
		int index = default;

		foreach (BlockFace face in mesh)
		{
			for (var i = 0; i < FACE_VERTICES; i++)
			{
				vertices[index++] = face.Vertices[i];
			}
		}
		

		return vertices;
	}
}
