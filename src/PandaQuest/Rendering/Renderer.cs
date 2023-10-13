using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Rendering;

public sealed class Renderer : IRenderer
{
	private readonly GraphicsDevice graphicsDevice;
	private readonly DynamicVertexBuffer vertexBuffer;
	private readonly BasicEffect effect;

	public Renderer(GraphicsDevice graphicsDevice, Texture2D texture)
	{
		this.graphicsDevice = graphicsDevice;
		this.vertexBuffer = new DynamicVertexBuffer(this.graphicsDevice, typeof(VertexPositionTexture), (int)2e4, BufferUsage.WriteOnly);
		this.effect = new BasicEffect(graphicsDevice) { TextureEnabled = true };

		this.graphicsDevice.SetVertexBuffer(this.vertexBuffer);
	}

	public void Draw(PlayerCamera camera, IEnumerable<Chunk> chunks)
	{
		this.graphicsDevice.Clear(Color.CornflowerBlue);

		this.effect.Projection = camera.Projection;
		this.effect.View = camera.View;

		IDictionary<Vector3, Block> blocks = chunks.SelectMany(c => c.Blocks);

		foreach (Chunk chunk in chunks)
		{
			if (!camera.IsVisible(chunk.BoundingBox))
			{
				continue;
			}

			IEnumerable<BlockFace> mesh = MeshGenerator.Generate(chunk.Blocks);

			foreach (BlockFace face in mesh)
			{
				this.vertexBuffer.SetData(face.Vertices);
				
				this.effect.CurrentTechnique.Passes[0].Apply();

				this.graphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
			}
		}
	}
}
