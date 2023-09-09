using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandaQuest.Rendering;

namespace PandaQuest;

public sealed class GameContext : Game
{
    private readonly GraphicsDeviceManager graphics;
    private Renderer renderer;

    public GameContext()
    {
        this.graphics = new GraphicsDeviceManager(this);

        this.Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        this.renderer = new Renderer(this.GraphicsDevice);

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        this.renderer.Draw();

        base.Draw(gameTime);
    }
}