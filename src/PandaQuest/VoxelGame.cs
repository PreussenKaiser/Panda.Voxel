using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Lifecycle;
using PandaQuest.Extensions;
using PandaQuest.Input;
using PandaQuest.Rendering;
using PandaQuest.Generators;
using Game = Microsoft.Xna.Framework.Game;

namespace PandaQuest;

public sealed class VoxelGame : Game, IGame
{
	private readonly GraphicsDeviceManager graphics;
	private readonly Player player;
	private readonly IWorldGenerator worldGenerator;

	private Renderer? renderer;
	private VertexPositionTexture[]? verticesCache;

	public VoxelGame(Player player, IWorldGenerator worldGenerator)
	{
		this.player = player;
		this.worldGenerator = worldGenerator;

		this.graphics = new GraphicsDeviceManager(this);

		this.Content.RootDirectory = "Content";
	}

	private VertexPositionTexture[] Vertices => this.verticesCache ??= this.worldGenerator.Mesh.ToVertices();

	protected override void Initialize()
	{
		this.GraphicsDevice.Pixelate();

		var texture = this.Content.Load<Texture2D>("Textures/Blocks/grass");

		this.renderer = new Renderer(this.GraphicsDevice, texture);
	}

	protected override void Update(GameTime gameTime)
	{
		if (Keyboard.GetState().IsKeyDown(Keys.Escape))
		{
			this.Exit();
		}

		this.player.Update(gameTime);
		this.worldGenerator.Generate();

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		this.renderer?.Draw(this.player.Camera, this.Vertices);
	}
}
