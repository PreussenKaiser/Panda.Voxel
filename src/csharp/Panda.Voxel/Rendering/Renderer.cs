using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Panda.Voxel.Extensions;
using Panda.Voxel.Input.Camera;

namespace Panda.Voxel.Rendering;

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

		using var buffer = new VertexBuffer(this.graphicsDevice, typeof(VertexPositionTexture), vertices.Length, BufferUsage.WriteOnly);
		buffer.SetData(vertices, 0, vertices.Length);

		this.graphicsDevice.SetVertexBuffer(buffer);
		this.graphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, vertices.Length / 3);
	}
}
