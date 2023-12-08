using Panda.Extensions;

namespace Panda.Voxel.Tests.Extensions;

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
	[InlineData(1, 0, 15)]
	public void ElementAtOrDefault_HappyPath(int x, int y, int expected)
	{
		// Act
		int actual = array.ElementAtOrDefault(x, y);

		// Assert
		Assert.Equal(expected, actual);
	}
}
