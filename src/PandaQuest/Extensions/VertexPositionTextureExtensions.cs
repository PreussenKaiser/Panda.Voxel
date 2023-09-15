using Microsoft.Xna.Framework.Graphics;

namespace PandaQuest.Extensions;

public static class VertexPositionTextureExtensions
{
    public static int GetPrimitiveCount(this VertexPositionTexture[] vertices)
    {
        return vertices is null || vertices.Length == 0 ? 0 : vertices.Length;
    }
}
