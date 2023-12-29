namespace Panda.Noise.Visualizer.Interfaces;

public interface IVisualizerService
{
	void Create();

	Task CreateAsync(CancellationToken cancellationToken = default);
}
