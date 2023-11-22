namespace Panda.Noise.Visualizer.Interfaces;

public interface IVisualizerService
{
	void Create(int[,] map);

	Task CreateAsync(int[,] map, CancellationToken cancellationToken = default);
}
