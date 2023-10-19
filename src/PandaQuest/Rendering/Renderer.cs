using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Rendering;

public sealed class Renderer : IRenderer
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
			IEnumerable<BlockFace> mesh = MeshGenerator.Generate(chunk.Blocks);

			foreach (BlockFace face in mesh)
			{
				using var buffer = new VertexBuffer(this.graphicsDevice, VertexPositionTexture.VertexDeclaration, face.Vertices.Length, BufferUsage.WriteOnly);
				buffer.SetData(face.Vertices, 0, face.Vertices.Length);
			
				this.graphicsDevice.SetVertexBuffer(buffer);
				
				this.graphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
			}
		}
	}
}
