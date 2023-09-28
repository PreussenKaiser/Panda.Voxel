using PandaQuest.Input;
using PandaQuest.Models;
using System.Numerics;

namespace PandaQuest.Generators;

public sealed class InfiniteWorldGenerator : IWorldGenerator
{
    private readonly Player player;
    private readonly List<Block> blocks;
    private readonly List<Chunk> loadedChunks;

    private bool generated;

    public InfiniteWorldGenerator(Player player)
    {
        this.player = player;
        this.blocks = new List<Block>();

        this.Initialize();
    }

    public IEnumerable<Block> Blocks => this.blocks;

    public void Generate()
    {
        if (this.generated)
        {
            return;
        }

        this.generated = true;
    }

    private void Initialize()
    {
        for (var x = 0; x < Constants.CHUNK_SIZE; x++)
        {
            for (var z = 0; z < Constants.CHUNK_SIZE; z++)
            {
                var position = new Vector3(x, 0, z);
                var block = new Block(position);

                this.blocks.Add(block);
            }
        }
    }
}
