using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Input;
using PandaQuest.Rendering;

namespace PandaQuest;

public sealed class GameContext : Game
{
    private readonly GraphicsDeviceManager graphics;

    private Camera camera;
    private Renderer renderer;

    public GameContext()
    {
        this.graphics = new GraphicsDeviceManager(this);

        this.Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        this.camera = new Camera(this.GraphicsDevice);
        this.renderer = new Renderer(this.GraphicsDevice);

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        this.camera.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        this.renderer.Draw(this.camera);

        base.Draw(gameTime);
    }
}