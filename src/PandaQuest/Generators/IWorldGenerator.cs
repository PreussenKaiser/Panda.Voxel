using PandaQuest.Models;
using System.Collections.Generic;

namespace PandaQuest.Generators;

public interface IWorldGenerator
{
    IEnumerable<Block> Blocks { get; }

    void Generate();
}
