using Microsoft.Xna.Framework;
using PandaQuest.Models;
using System.Collections.Generic;

namespace PandaQuest.Generators;

public sealed class TestWorldGenerator : IWorldGenerator
{
    private readonly List<Block> blocks;
    private bool generated;

    public TestWorldGenerator()
    {
        this.blocks = new List<Block>();
    }

    public IEnumerable<Block> Blocks => blocks;

    public void Generate()
    {
        if (this.generated)
        {
            return;
        }

        for (var x = 0; x < Constants.CHUNK_SIZE; x++)
        {
            for (var z = 0; z < Constants.CHUNK_SIZE; z++)
            {
                var position = new Vector3(x, 0, z);
                var block = new Block(position);

                this.blocks.Add(block);
            }
        }

        // this.blocks.Add(new Block(new Vector3(0, 1, 0)));
        // this.blocks.Add(new Block(new Vector3(0, 2, 0)));

        this.generated = true;
    }
}
