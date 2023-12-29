namespace Panda.Extensions;

public static class ArrayExtensions
{
	public static (int, int) GetLength<T>(this T[,] array)
	{
		int xLength = array.GetLength(0);
		int yLength = array.GetLength(1);

		return (xLength, yLength);
	}

	public static T ElementAtOrDefault<T>(this T[,] array, int x, int y) where T : struct
	{
		var (xLength, yLength) = array.GetLength();

		T result = x >= 0 && y >= 0 && x < xLength && y < yLength
			? array[x, y]
			: default;

		return result;
	}
}
