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

		vertices = new VertexPositionTexture[6]
		{
			new VertexPositionTexture(new Vector3(0, 0, 0), new Vector2(0, 0)),
			new VertexPositionTexture(new Vector3(1, 0, 0), new Vector2(1, 0)),
			new VertexPositionTexture(new Vector3(0, 1, 0), new Vector2(0, 1)),

			new VertexPositionTexture(new Vector3(1, 0, 0), new Vector2(1, 0)),
			new VertexPositionTexture(new Vector3(1, 1, 0), new Vector2(1, 1)),
			new VertexPositionTexture(new Vector3(0, 1, 0), new Vector2(0, 1)),
		};

		using var buffer = new VertexBuffer(this.graphicsDevice, typeof(VertexPositionTexture), 4, BufferUsage.WriteOnly);
		buffer.SetData(vertices, 0, 4);

		this.graphicsDevice.SetVertexBuffer(buffer);
		this.graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 2);

		//using var buffer = new VertexBuffer(this.graphicsDevice, VertexPositionTexture.VertexDeclaration, vertices.Length, BufferUsage.WriteOnly);
		//buffer.SetData(vertices, 0, vertices.Length);
			
		//this.graphicsDevice.SetVertexBuffer(buffer);
		//this.graphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, vertices.Length);
	}
}
