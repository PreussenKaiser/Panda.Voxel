namespace Panda.Extensions;

public static class ArrayExtensions
{
	public static int[,] Smoothen(this int[,] array)
	{
		var (xLength, yLength) = array.GetLength();

		for (var x = 0; x < xLength; x++)
		{
			for (var y = 0; y < yLength; y++)
			{
				int[] neighbors = array.GetNeighbors(x, y);
				var average = (int)neighbors.Average();

				array[x, y] = average;
			}
		}

		return array;
	}

	public static (int, int) GetLength<T>(this T[,] array)
	{
		int xLength = array.GetLength(0);
		int yLength = array.GetLength(1);

		return (xLength, yLength);
	}

	public static int[] GetNeighbors(this int[,] array, int row, int column)
	{
		int[] neighbors =
		[
			array.ElementAtOrDefault(row - 1, column - 1),
			array.ElementAtOrDefault(row - 1, column),
			array.ElementAtOrDefault(row - 1, column + 1),
			
			array.ElementAtOrDefault(row, column - 1),
			array.ElementAtOrDefault(row, column),
			array.ElementAtOrDefault(row, column + 1),

			array.ElementAtOrDefault(row + 1, column - 1),
			array.ElementAtOrDefault(row + 1, column),
			array.ElementAtOrDefault(row + 1, column + 1),
		];

		return neighbors;
	}

	public static T ElementAtOrDefault<T>(this T[,] array, int x, int y) where T : struct
	{
		var (xLength, yLength) = array.GetLength();

		T result = x >= 0 && y >= 0 && x < xLength && y < yLength
			? array[x, y]
			: default;

		return result;
	}

	public static void ForEach<T>(this T[,] array, Action<int, int> action)
	{
		var (xLength, yLength) = array.GetLength();

		for (var x = 0; x < xLength; x++)
		{
			for (var y = 0; y < yLength; y++)
			{
				action(x, y);
			}
		}
	}
}
