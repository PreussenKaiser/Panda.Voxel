using System.Drawing;

namespace Panda.Noise.Visualizer.Utilities;

public static class ColorHelper
{
	public static Color GetColor(int height)
	{
		Color color;

		if (height >= 32)
		{
			color = Color.Green;
		}
		else if (height >= 48)
		{
			color = Color.Brown;
		}
		else
		{
			color = Color.Blue;
		}

		return color;
	}
}
