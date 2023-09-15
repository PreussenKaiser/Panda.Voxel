using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Models;
using System.Collections.Generic;

namespace PandaQuest.Generators;

public sealed class WorldGenerator
{
    private readonly List<VertexPositionTexture> vertices;

    public WorldGenerator()
    {
        this.vertices = new List<VertexPositionTexture>();
    }

    public VertexPositionTexture[] Vertices => this.vertices.ToArray();

    public Block Generate(Vector3 position)
    {
        float size = Constants.BLOCK_SIZE;

        var vertices = new VertexPositionTexture[]
        {
            // Front face.
            new(new Vector3(-size, -size, -size), new Vector2(0, 0)),
            new(new Vector3(size, -size, -size), new Vector2(1, 0)),
            new(new Vector3(size, size, -size), new Vector2(1, 1)),
            new(new Vector3(-size, size, -size), new Vector2(0, 1)),

            // Back face.
            new(new Vector3(-size, -size, size), new Vector2(0, 0)),
            new(new Vector3(size, -size, size), new Vector2(1, 1)),
            new(new Vector3(size, size, size), new Vector2(0, 1)),
            new(new Vector3(-size, size, size), new Vector2(0, 1)),
        };

        var indices = new short[36]
        {
            // Front face.
            0, 1, 2,
            0, 2, 3,

            // Back face.
            4, 6, 5,
            4, 7, 6,

            // Left face.
            4, 5, 1,
            4, 1, 0,

            // Right face.
            3, 2, 6,
            3, 6, 7,

            // Top face.
            1, 5, 6,
            1, 6, 2,

            // Bottom face.
            4, 0, 3,
            4, 3, 7,
        };

        return new Block(vertices, indices);
    }
}
