﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PandaQuest.Rendering;

public sealed class Renderer
{
    private readonly GraphicsDevice graphicsDevice;
    private readonly BasicEffect effect;

    public Renderer(GraphicsDevice graphicsDevice)
    {
        this.graphicsDevice = graphicsDevice;
        this.effect = new BasicEffect(graphicsDevice);
    }

    public void Draw()
    {
        this.graphicsDevice.Clear(Color.CornflowerBlue);

        var vertexPositionTextures1 = new[]
{
            new VertexPositionColor(new Vector3(0, 0, 0), Color.White),
            new VertexPositionColor(new Vector3(64, 0, 0), Color.White),
            new VertexPositionColor(new Vector3(64, 64, 0), Color.White),
        };

        var vertexPositionTextures2 = new[]
        {
            new VertexPositionColor(new Vector3(0, 0, 0), Color.White),
            new VertexPositionColor(new Vector3(64, 64, 0), Color.White),
            new VertexPositionColor(new Vector3(0, 64, 0), Color.White),
        };

        this.effect.World = Matrix.CreateOrthographicOffCenter(
            0, this.graphicsDevice.Viewport.Width, this.graphicsDevice.Viewport.Height, 0, 0, 1);

        foreach (EffectPass effectPass in this.effect.CurrentTechnique.Passes)
        {
            effectPass.Apply();

            this.graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertexPositionTextures1, 0, 1);
            this.graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertexPositionTextures2, 0, 1);
        }
    }
}