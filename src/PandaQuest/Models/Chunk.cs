using Microsoft.Xna.Framework;

namespace PandaQuest.Models;

public sealed class Chunk
{
    private readonly Block[] blocks;
    private readonly Vector3 position;

    public Chunk(Vector3 position)
    {
        const int maxBlocks = Constants.CHUNK_SIZE * Constants.CHUNK_SIZE;

        this.blocks = new Block[maxBlocks];
        this.position = position * Constants.CHUNK_SIZE;
    }

    public void Generate()
    {

    }
}
