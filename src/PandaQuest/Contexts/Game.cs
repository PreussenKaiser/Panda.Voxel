using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Panda.Noise.Gradient;
using PandaQuest.Configuration;
using PandaQuest.Extensions;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.Movement;
using PandaQuest.Models;
using PandaQuest.Physics;
using PandaQuest.Rendering;

namespace PandaQuest.Contexts;

public sealed class Game : Microsoft.Xna.Framework.Game, IGame
{
	private readonly GraphicsDeviceManager graphics;

	private PlayerCamera? camera;
	private World? world;
	private IRenderer? renderer;

	public Game() : base()
	{
		this.graphics = new GraphicsDeviceManager(this);

		this.Content.RootDirectory = "Content";
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

		this.world?.Update(gameTime);
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
		var position = new Vector3(0, 128, 0);
		var displayConfiguration = new DisplayConfiguration(
			this.GraphicsDevice.Viewport.Width,
			this.GraphicsDevice.Viewport.Height);

		this.camera = new PlayerCamera(position, displayConfiguration);
	}

	private void InitializeRendering()
	{
		this.GraphicsDevice.Pixelate();

		var texture = this.Content.Load<Texture2D>("Textures/Blocks/test");

		this.renderer = new Renderer(this.GraphicsDevice, texture);
	}

	private void InitializeWorld()
	{
		if (this.camera is null)
		{
			return;
		}

		const int PLACEHOLDER_SEED = 0;

		var player = new Player(this.camera, new GroundedMovement());
		var physics = new OverworldPhysics();
		var noise = new GradientNoise2(PLACEHOLDER_SEED);
		var generator = new InfiniteWorldGenerator(player, noise);

		this.world = new World(player, physics, generator);
	}
}