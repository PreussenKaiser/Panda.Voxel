using PandaQuest.Models;

namespace PandaQuest.Generators;

public interface IWorldGenerator
{
    IEnumerable<Block> Blocks { get; }

    void Generate();
}
