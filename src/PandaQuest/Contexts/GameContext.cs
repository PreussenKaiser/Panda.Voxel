using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Extensions;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.CameraInput;
using PandaQuest.Physics;
using PandaQuest.Rendering;
using PandaQuest.Time;

namespace PandaQuest.Contexts;

public sealed class GameContext : Game
{
    private readonly GraphicsDeviceManager graphics;

    private WorldContext world;
    private Renderer renderer;
    private PlayerCamera camera;

    public GameContext()
    {
        this.graphics = new GraphicsDeviceManager(this);

        this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        this.GraphicsDevice.Pixelate();

        var texture = this.Content.Load<Texture2D>("Textures/Blocks/grass");
        var player = new Player(new Vector3(0, 6, 0));
        var mouseInput = new MouseInput(new Vector2(
            this.GraphicsDevice.Viewport.Width / 2,
            this.GraphicsDevice.Viewport.Height / 2));

        this.world = new WorldContext(
            player,
            new PhysicsProvider(),
            new TestWorldGenerator(),
            new OverworldTimeProvider());

        this.renderer = new Renderer(this.GraphicsDevice, texture);
        this.camera = new PlayerCamera(player, mouseInput, this.GraphicsDevice.Viewport.AspectRatio);

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }

        this.world.Update(gameTime);
        this.camera.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        this.renderer.Draw(this.camera, this.world.Generation.Blocks);

        base.Draw(gameTime);
    }
}