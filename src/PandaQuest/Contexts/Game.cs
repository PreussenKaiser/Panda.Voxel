using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Builders;
using PandaQuest.Configuration;
using PandaQuest.Extensions;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.Movement;
using PandaQuest.Physics;
using PandaQuest.Rendering;
using PandaQuest.Time;
using PanDI;

namespace PandaQuest.Contexts;

public sealed class Game : Microsoft.Xna.Framework.Game, IGame
{
	private readonly ServiceProvider serviceProvider;
	private readonly GraphicsDeviceManager graphics;

	private PlayerCamera? camera;
	private World? world;
	private IRenderer? renderer;

	public Game(ServiceProvider serviceProvider) : base()
	{
		this.serviceProvider = serviceProvider;
		this.graphics = new GraphicsDeviceManager(this);

		this.Content.RootDirectory = "Content";
	}

	public static GameBuilder CreateBuilder()
	{
		var gameBuilder = new GameBuilder();

		return gameBuilder;
	}

	protected override void Initialize()
	{
		this.InitializeCamera();
		this.InitializeRendering();
		this.InitializeWorld();
	}

	protected override void Update(GameTime gameTime)
	{
		if (Keyboard.GetState().IsKeyDown(Keys.Escape))
		{
			this.Exit();
		}

		this.world?.Update(gameTime.ToGameContextTime());
	}

	protected override void Draw(GameTime gameTime)
	{
		if (this.camera is not null && this.world is not null)
		{
			this.renderer?.Draw(this.camera, this.world.Generation.Chunks);
		}
	}

	private void InitializeCamera()
	{
		var position = new Vector3(0, 8, 0);
		var displayConfiguration = new DisplayConfiguration(
			this.GraphicsDevice.Viewport.Width,
			this.GraphicsDevice.Viewport.Height);

		this.camera = new PlayerCamera(position, displayConfiguration);
	}

	private void InitializeRendering()
	{
		this.GraphicsDevice.Pixelate();

		var texture = this.Content.Load<Texture2D>("Textures/Blocks/grass");

		this.renderer = new Renderer(this.GraphicsDevice, texture);
	}

	private void InitializeWorld()
	{
		if (this.camera is null)
		{
			return;
		}

		var player = new Player(this.camera, new GroundedMovement());

		this.world = new World(
			player,
			new OverworldPhysics(),
			new InfiniteWorldGenerator(player),
			new OverworldTimeProvider());
	}
}