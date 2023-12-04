using Panda.Noise.Visualizer.Interfaces;
using System.Drawing;

namespace Panda.Noise.Visualizer.Implementations;

internal class NaturalColorPicker : IColorPicker
{
	public Color Pick(int value)
	{
		Color color;
		if (value >= 32)
		{
			color = Color.Green;
		}
		else if (value >= 48)
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
