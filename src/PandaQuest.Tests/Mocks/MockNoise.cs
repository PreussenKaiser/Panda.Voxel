using Panda.Noise.Abstractions;

namespace PandaQuest.Tests.Mocks;

internal sealed class MockNoise : INoise
{
	public int GetValue(int x, int y)
	{
		return 0;
	}
}
