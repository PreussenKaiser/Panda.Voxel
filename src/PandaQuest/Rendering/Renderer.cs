using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Input;

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

    public void Draw(Camera camera)
    {
        this.effect.Projection = camera.Projection;
        this.effect.World = Matrix.Identity;
        this.effect.View = camera.View;

        this.graphicsDevice.Clear(Color.CornflowerBlue);

        var vertexPositionTextures1 = new[]
        {
            new VertexPositionColor(new Vector3(0, 0, 0), Color.White),
            new VertexPositionColor(new Vector3(16, 0, 0), Color.White),
            new VertexPositionColor(new Vector3(16, 16, 0), Color.White),
        };

        var vertexPositionTextures2 = new[]
        {
            new VertexPositionColor(new Vector3(0, 0, 0), Color.White),
            new VertexPositionColor(new Vector3(16, 16, 0), Color.White),
            new VertexPositionColor(new Vector3(0, 16, 0), Color.White),
        };

        foreach (EffectPass effectPass in this.effect.CurrentTechnique.Passes)
        {
            effectPass.Apply();

            this.graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertexPositionTextures1, 0, 1);
            this.graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertexPositionTextures2, 0, 1);
        }
    }
}
