using Panda.Noise.Visualizer.Interfaces;
using System.Drawing;

namespace Panda.Noise.Visualizer.Implementations;

internal class GrayScaleColorPicker : IColorPicker
{
	public Color Pick(int value)
	{
		Color color = Color.FromArgb(value, Color.White);

		return color;
	}
}
