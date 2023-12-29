using System.Drawing;

namespace Panda.Noise.Visualizer.Extensions;

public static class BitmapExtensions
{
	public static void Fill(this Bitmap image, Action<int, int> action)
	{
		for (int x = 0; x < image.Width; x++)
		{
			for (int y = 0; y < image.Height; y++)
			{
				action(x, y);
			}
		}
	}
}
