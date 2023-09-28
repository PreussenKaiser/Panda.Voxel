using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Extensions;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.CameraInput;
using PandaQuest.Input.Movement;
using PandaQuest.Physics;
using PandaQuest.Rendering;
using PandaQuest.Time;

namespace PandaQuest.Contexts;

public sealed class GameContext : Game
{
    private readonly GraphicsDeviceManager graphics;

    private Camera camera;
    private WorldContext world;
    private Renderer renderer;

    public GameContext()
    {
        this.graphics = new GraphicsDeviceManager(this);

        this.Content.RootDirectory = "Content";
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

        this.world.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        this.renderer.Draw(this.camera, this.world.Generation.Blocks);

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
        var player = new Player(this.camera, new GroundedMovement());

        this.world = new WorldContext(
            player,
            new PhysicsProvider(),
            new InfiniteWorldGenerator(player),
            new OverworldTimeProvider());
    }
}