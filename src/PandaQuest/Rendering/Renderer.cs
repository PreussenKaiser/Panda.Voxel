using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

	public void Draw(PlayerCamera camera, VertexPositionTexture[] mesh)
	{
		this.graphicsDevice.Clear(Color.CornflowerBlue);
		this.effect.CurrentTechnique.Passes[0].Apply();

		this.effect.Projection = camera.Projection;
		this.effect.View = camera.View;

		using var buffer = new VertexBuffer(this.graphicsDevice, VertexPositionTexture.VertexDeclaration, mesh.Length, BufferUsage.WriteOnly);
		buffer.SetData(mesh, 0, mesh.Length);
			
		this.graphicsDevice.SetVertexBuffer(buffer);
		
		this.graphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, mesh.Length / 2);
	}
}
