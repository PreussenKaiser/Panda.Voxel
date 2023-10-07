using PandaQuest.Models;

namespace PandaQuest.Generators;

public interface IWorldGenerator
{
	IEnumerable<Chunk> Chunks { get; }

    void Generate();
}
