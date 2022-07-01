// **Задача 56:** Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с
// наименьшей суммой элементов: 1 строка
using System;
using static System.Console;

Clear();
Write("Введите количество строк массива: ");
int m = Convert.ToInt32(ReadLine());
Write("Введите количество столбцов массива: ");
int n = Convert.ToInt32(ReadLine());
int[,] Array = GetRandomArray(m, n, 1, 9);
WriteLine();
PrintArray(Array);
WriteLine();
// Номер строки выводим с учётом нумерации от 1 как в примере
WriteLine($"Строка с наименьшей суммой элементов: {MinElementIndex(SumRowArray(Array)) + 1}");

int MinElementIndex (int[] array) {
	int result = 0;
	for (int i = 1; i < array.Length; i ++)
		if (array[i] < array[result])		result = i;
	return result;
}

int[] SumRowArray (int[,] array) {
	int[] result = new int[array.GetLength(0)];
	for (int i = 0; i < array.GetLength(0); i ++)
		for (int j = 0; j < array.GetLength(1); j ++)
			result[i] += array[i,j];
	return result;
}

int[,] GetRandomArray (int row, int column, int minValue, int maxValue) {
	int[,] result = new int[row, column];
	for (int i = 0; i < row ; i ++) {
		for (int j = 0; j < column; j ++) {
			result[i, j] = new Random().Next(minValue, maxValue + 1);
		}
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
