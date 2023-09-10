using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PandaQuest.Input;
using PandaQuest.Rendering;

namespace PandaQuest;

public sealed class GameContext : Game
{
    private readonly GraphicsDeviceManager graphics;

    private Player player;
    private Renderer renderer;

    public GameContext()
    {
        this.graphics = new GraphicsDeviceManager(this);

        this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        var camera = new Camera(this.GraphicsDevice);

        this.player = new Player(camera);
        this.renderer = new Renderer(this.GraphicsDevice);

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
        this.renderer.Draw(this.player.Camera);

        base.Draw(gameTime);
    }
}