﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Builders;
using PandaQuest.Extensions;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.CameraInput;
using PandaQuest.Input.Movement;
using PandaQuest.Physics;
using PandaQuest.Rendering;
using PandaQuest.Time;
using PanDI;

namespace PandaQuest.Contexts;

public sealed class GameContext : Game, IGame
{
	private readonly ServiceProvider serviceProvider;
	private readonly GraphicsDeviceManager graphics;

	private Camera? camera;
	private WorldContext? world;
	private IRenderer? renderer;

	public GameContext(ServiceProvider serviceProvider) : base()
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

		base.Initialize();
	}

	protected override void Update(GameTime gameTime)
	{
		if (Keyboard.GetState().IsKeyDown(Keys.Escape))
		{
			this.Exit();
		}

		this.world?.Update(gameTime.ToGameContextTime());

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		if (this.camera is not null && this.world is not null)
		{
			this.renderer?.Draw(this.camera, this.world.Blocks);
		}

		base.Draw(gameTime);
	}

	private void InitializeCamera()
	{
		var mouseInput = new MouseInput(new Vector2(
			this.GraphicsDevice.Viewport.Width / 2,
			this.GraphicsDevice.Viewport.Height / 2));

		this.camera = new Camera(
			mouseInput,
			new Vector3(0, 8, 0),
			this.GraphicsDevice.Viewport.AspectRatio);
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

		this.world = new WorldContext(
			player,
			new OverworldPhysics(),
			new InfiniteWorldGenerator(player),
			new OverworldTimeProvider());
	}
}