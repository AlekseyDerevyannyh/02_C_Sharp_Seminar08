// **Задача 62**. Заполните спирально массив 4 на 4. 
// Например, на выходе получается вот такой массив:
// 1 2 3 4
// 12 13 14 5
// 11 16 15 6
// 10 9 8 7
using System;
using static System.Console;

Clear();
Write("Введите количество строк спирального массива: ");
int m = Convert.ToInt32(ReadLine());
Write("Введите количество столбцов спирального массива: ");
int n = Convert.ToInt32(ReadLine());
WriteLine();
PrintArray(SpiralArray(m, n));
WriteLine();


int[,] SpiralArray (int row, int column) {
	if (row < 2 || column < 2) {
		WriteLine("ОШИКА! Число строк и столбцов спиральной матрицы должно быть >= 2 !");
		return new int[,]{{0}};
	}
	int[,] result = new int[row, column];
	int index = 1;
	int round = 0;
	while(index <= result.Length) {
		int i = round;
		int j;
		for (j = round; j < result.GetLength(1) - round; j ++) {
			result[i, j] = index;
			index ++;
		}
		j = result.GetLength(1) - 1 - round;
		for (i = round + 1; i < result.GetLength(0) - round; i ++) {
			result[i, j] = index;
			index ++;
		}
		i = result.GetLength(0) - 1 - round;
		for (j = result.GetLength(1) - 2 - round; j >= round ; j --) {
			result[i, j] = index;
			index ++;
		}
		j = round;
		for (i = result.GetLength(0) - 2 - round; i >= round + 1; i --) {
			result[i, j] = index;
			index ++;
		}
		round ++;
	}
	return result;
}

void PrintArray(int[,] array) {
	for (int i = 0; i < array.GetLength(0); i ++) {
		for (int j = 0; j < array.GetLength(1); j ++) {
			Write($"{array[i, j]} ");
		}
		WriteLine();
	}
}