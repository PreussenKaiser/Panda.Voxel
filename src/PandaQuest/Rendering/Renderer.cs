using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Rendering;

public sealed class Renderer : IRenderer
{
	private readonly GraphicsDevice graphicsDevice;
	private readonly VertexBuffer vertexBuffer;
	private readonly BasicEffect effect;

	public Renderer(GraphicsDevice graphicsDevice, Texture2D texture)
	{
		this.graphicsDevice = graphicsDevice;
		this.vertexBuffer = new VertexBuffer(this.graphicsDevice, typeof(VertexPositionTexture), 4, BufferUsage.WriteOnly);

		this.effect = new BasicEffect(graphicsDevice)
		{
			Texture = texture,
			TextureEnabled = true,
			World = Matrix.Identity
		};
	}

	public void Draw(Camera camera, IEnumerable<Block> blocks)
	{
		this.graphicsDevice.Clear(Color.CornflowerBlue);

		this.effect.Projection = camera.Projection;
		this.effect.View = camera.View;

		foreach (Block block in blocks)
		{
			foreach (var face in block.Faces)
			{
				if (!face.IsVisible)
				{
					continue;
				}

				this.vertexBuffer.SetData(face.Vertices);
		
				this.graphicsDevice.SetVertexBuffer(this.vertexBuffer);
				this.effect.CurrentTechnique.Passes[0].Apply();

				this.graphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
			}
		}

	}
}
