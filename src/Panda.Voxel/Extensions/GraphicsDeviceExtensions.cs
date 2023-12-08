using Microsoft.Xna.Framework.Graphics;

namespace Panda.Voxel.Extensions;

public static class GraphicsDeviceExtensions
{
    public static void Pixelate(this GraphicsDevice graphicsDevice)
    {
        graphicsDevice.SamplerStates[0] = new SamplerState { Filter = TextureFilter.Point };
    }
}
