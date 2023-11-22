namespace Panda.Noise.Abstractions;

public interface INoise
{
	int GetValue(int x, int y);

	int[,] Generate();
}
