using Microsoft.Xna.Framework.Graphics;

namespace PandaQuest.Models;

public sealed class Block
{
    public readonly VertexPositionTexture[] Vertices;
    public readonly short[] Indices;

    public Block(VertexPositionTexture[] vertices, short[] indices)
    {
        this.Vertices = vertices;
        this.Indices = indices;
    }
}
