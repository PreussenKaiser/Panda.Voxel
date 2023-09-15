using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Models;
using PandaQuest.Rendering;

namespace PandaQuest;

public sealed class GameContext : Game
{
    private readonly GraphicsDeviceManager graphics;
    private readonly WorldGenerator worldGenerator;

    private Player player;
    private Renderer renderer;

    public GameContext()
    {
        this.graphics = new GraphicsDeviceManager(this);
        this.worldGenerator = new WorldGenerator();

        this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        this.GraphicsDevice.SamplerStates[0] = new SamplerState { Filter = TextureFilter.Point };

        var camera = new Camera(this.GraphicsDevice);
        var texture = this.Content.Load<Texture2D>("Textures/Blocks/test");

        this.player = new Player(camera);
        this.renderer = new Renderer(this.GraphicsDevice, texture);

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            base.Exit();
        }

        this.player.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        Block block = this.worldGenerator.Generate(new Vector3(1, 1, 1));

        this.renderer.Draw(this.player.Camera, block.Vertices, block.Indices);

        base.Draw(gameTime);
    }
}