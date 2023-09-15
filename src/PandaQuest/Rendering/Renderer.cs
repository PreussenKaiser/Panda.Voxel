using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Input;

namespace PandaQuest.Rendering;

public sealed class Renderer
{
    private readonly GraphicsDevice graphicsDevice;
    private readonly BasicEffect effect;

    public Renderer(GraphicsDevice graphicsDevice, Texture2D texture)
    {
        this.graphicsDevice = graphicsDevice;

        this.effect = new BasicEffect(graphicsDevice)
        {
            Texture = texture,
            TextureEnabled = true,
            World = Matrix.Identity
        };
    }

    public void Draw(Camera camera, VertexPositionTexture[] vertices, short[] indices)
    {
        this.graphicsDevice.Clear(Color.CornflowerBlue);

        this.effect.Projection = camera.Projection;
        this.effect.View = camera.View;

        var vertexBuffer = new VertexBuffer(this.graphicsDevice, typeof(VertexPositionTexture), vertices.Length, BufferUsage.WriteOnly);
        var indexBuffer = new IndexBuffer(this.graphicsDevice, IndexElementSize.SixteenBits, sizeof(short) * indices.Length, BufferUsage.WriteOnly);

        vertexBuffer.SetData(vertices);
        indexBuffer.SetData(indices);
        
        this.graphicsDevice.SetVertexBuffer(vertexBuffer);
        this.graphicsDevice.Indices = indexBuffer;

        foreach (EffectPass effectPass in this.effect.CurrentTechnique.Passes)
        {
            effectPass.Apply();

            this.graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, indices.Length);
        }
    }
}
