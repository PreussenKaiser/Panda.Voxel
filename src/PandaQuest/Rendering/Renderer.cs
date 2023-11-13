using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Input.Camera;

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

	public void Draw(ICamera camera, VertexPositionTexture[] vertices)
	{
		this.graphicsDevice.Clear(Color.CornflowerBlue);
		this.effect.CurrentTechnique.Passes[0].Apply();

		this.effect.Projection = camera.Projection;
		this.effect.View = camera.View;

		using var buffer = new VertexBuffer(this.graphicsDevice, VertexPositionTexture.VertexDeclaration, vertices.Length, BufferUsage.WriteOnly);
		buffer.SetData(vertices, 0, vertices.Length);
			
		this.graphicsDevice.SetVertexBuffer(buffer);
		
		this.graphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, vertices.Length);
	}
}
