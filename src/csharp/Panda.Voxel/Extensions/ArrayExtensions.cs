namespace Panda.Voxel.Extensions;

public static class ArrayExtensions
{
	public static IEnumerable<T> Flatten<T>(this T[,] array)
	{
		int dimensionOne = array.GetLength(0);
		int dimensionTwo = array.GetLength(1);

		for (var i = 0; i < dimensionOne; i++)
		{
			for (var j = 0; j < dimensionTwo; j++)
			{
				yield return array[i, j];
			}
		}
	}
}
