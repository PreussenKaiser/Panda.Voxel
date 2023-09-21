using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PandaQuest.Extensions;

public static class Vector3Extensions
{
    public static VertexPositionTexture[] ToFrontFace(this Vector3 position)
    {
        var faces = new VertexPositionTexture[4]
        {
            new(new Vector3(position.X - .5f, position.Y - 1, position.Z - .5f), new Vector2(0, 0)),
            new(new Vector3(position.X + .5f, position.Y - 1, position.Z - .5f), new Vector2(1, 0)),
            new(new Vector3(position.X - .5f, position.Y, position.Z - .5f), new Vector2(0, 1)),
            new(new Vector3(position.X + .5f, position.Y, position.Z - .5f), new Vector2(1, 1)),
        };

        return faces;
    }

    public static VertexPositionTexture[] ToBackFace(this Vector3 position)
    {
        var faces = new VertexPositionTexture[4]
        {
            new(new Vector3(position.X + .5f, position.Y - 1, position.Z + .5f), new Vector2(1, 1)),
            new(new Vector3(position.X - .5f, position.Y - 1, position.Z + .5f), new Vector2(0, 1)),
            new(new Vector3(position.X + .5f, position.Y, position.Z + .5f), new Vector2(1, 0)),
            new(new Vector3(position.X - .5f, position.Y, position.Z + .5f), new Vector2(0, 0)),
        };

        return faces;
    }

    public static VertexPositionTexture[] ToLeftFace(this Vector3 position)
    {
        var faces = new VertexPositionTexture[4]
        {
            new(new Vector3(position.X + .5f, position.Y - 1, position.Z - .5f), new Vector2(1, 1)),
            new(new Vector3(position.X + .5f, position.Y - 1, position.Z + .5f), new Vector2(0, 1)),
            new(new Vector3(position.X + .5f, position.Y, position.Z - .5f), new Vector2(1, 0)),
            new(new Vector3(position.X + .5f, position.Y, position.Z + .5f), new Vector2(0, 0)),
        };

        return faces;
    }

    public static VertexPositionTexture[] ToRightFace(this Vector3 position)
    {
        var faces = new VertexPositionTexture[4]
        {
            new(new Vector3(position.X - .5f, position.Y - 1, position.Z - .5f), new Vector2(0, 1)),
            new(new Vector3(position.X - .5f, position.Y, position.Z - .5f), new Vector2(0, 0)),
            new(new Vector3(position.X - .5f, position.Y - 1, position.Z + .5f), new Vector2(1, 1)),
            new(new Vector3(position.X - .5f, position.Y, position.Z + .5f), new Vector2(1, 0)),
        };

        return faces;
    }
    
    public static VertexPositionTexture[] ToTopFace(this Vector3 position)
    {
        var faces = new VertexPositionTexture[4]
        {
            new(new Vector3(position.X - .5f, position.Y, position.Z + .5f), new Vector2(0, 1)),
            new(new Vector3(position.X - .5f, position.Y, position.Z - .5f), new Vector2(0, 0)),
            new(new Vector3(position.X + .5f, position.Y, position.Z + .5f), new Vector2(1, 1)),
            new(new Vector3(position.X + .5f, position.Y, position.Z - .5f), new Vector2(1, 0)),
        };

        return faces;
    }

    public static VertexPositionTexture[] ToBottomFace(this Vector3 position)
    {
        var faces = new VertexPositionTexture[4]
        {
            new(new Vector3(position.X - .5f, position.Y - 1, position.Z - .5f), new Vector2(0, 1)),
            new(new Vector3(position.X - .5f, position.Y - 1, position.Z + .5f), new Vector2(1, 1)),
            new(new Vector3(position.X + .5f, position.Y - 1, position.Z - .5f), new Vector2(0, 0)),
            new(new Vector3(position.X + .5f, position.Y - 1, position.Z + .5f), new Vector2(1, 0)),
        };

        return faces;
    }
}
