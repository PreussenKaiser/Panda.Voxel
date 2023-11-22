using Panda.Extensions;

namespace PandaQuest.Tests.Extensions;

public sealed class ArrayExtensionsTests
{
	private static readonly int[,] array = new int[,]
	{
		{ 16, 15, 12, 15 },
		{ 10, 0, 6, 12 },
		{ 2, 0, 0, 5 },
		{ 2, 3, 2, 0 },
	};

	[Theory]
	[InlineData(0, 0, new int[9] { 0, 0, 0, 0, 16, 15, 0, 10, 0 })]
	[InlineData(1, 1, new int[9] { 16, 15, 12, 10, 0, 6, 2, 0, 0 })]
	public void GetNeighbors_HappyPath(int x, int y, int[] expected)
	{
		// Act
		int[] actual = array.GetNeighbors(x, y);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 0, 15)]
	public void ElementAtOrDefault_HappyPath(int x, int y, int expected)
	{
		// Act
		int actual = array.ElementAtOrDefault(x, y);

		// Assert
		Assert.Equal(expected, actual);
	}
}
