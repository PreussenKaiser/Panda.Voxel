using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Rendering;

public sealed class Renderer
{
	private readonly GraphicsDevice graphicsDevice;
	private readonly BasicEffect effect;

	public Renderer(GraphicsDevice graphicsDevice, Texture2D texture)
	{
		this.graphicsDevice = graphicsDevice;
		this.effect = new BasicEffect(graphicsDevice){ TextureEnabled = true, Texture =  texture };
	}

	public void Draw(PlayerCamera camera, IEnumerable<Chunk> chunks)
	{
		this.graphicsDevice.Clear(Color.CornflowerBlue);
		this.effect.CurrentTechnique.Passes[0].Apply();

		this.effect.Projection = camera.Projection;
		this.effect.View = camera.View;

		foreach (var chunk in chunks)
		{
			VertexPositionTexture[] vertices = MeshGenerator
				.Generate(chunk.Blocks)
				.SelectMany(f => f.Vertices)
				.ToArray();

			using var buffer = new VertexBuffer(this.graphicsDevice, VertexPositionTexture.VertexDeclaration, vertices.Length, BufferUsage.WriteOnly);
			buffer.SetData(vertices, 0, vertices.Length);
			
			this.graphicsDevice.SetVertexBuffer(buffer);
			
			this.graphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, vertices.Length);
		}
	}
}
