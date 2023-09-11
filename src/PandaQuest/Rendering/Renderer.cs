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
            TextureEnabled = true
        };
    }

    public void Draw(Camera camera)
    {
        this.graphicsDevice.Clear(Color.CornflowerBlue);

        this.effect.Projection = camera.Projection;
        this.effect.World = Matrix.Identity;
        this.effect.View = camera.View;

        var vertices = new VertexPositionTexture[3]
        {
            new(new Vector3(0, 0, 0), new Vector2(0, 0)),
            new(new Vector3(16, 0, 0), new Vector2(1, 0)),
            new(new Vector3(16, 16, 0), new Vector2(1, 1))
        };

        var buffer = new VertexBuffer(this.graphicsDevice, typeof(VertexPositionTexture), vertices.Length, BufferUsage.WriteOnly);

        buffer.SetData(vertices);

        foreach (EffectPass effectPass in this.effect.CurrentTechnique.Passes)
        {
            effectPass.Apply();

            this.graphicsDevice.SetVertexBuffer(buffer);
            this.graphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
        }
    }
}
