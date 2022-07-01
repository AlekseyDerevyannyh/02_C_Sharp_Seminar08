// **Задача 54:** Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 1 2 4 7
// 2 3 5 9
// 2 4 4 8
using System;
using static System.Console;

Clear();
Write("Введите количество строк массива: ");
int m = Convert.ToInt32(ReadLine());
Write("Введите количество столбцов массива: ");
int n = Convert.ToInt32(ReadLine());
int[,] Array = GetRandomArray(m, n, 1, 9);
PrintArray(Array);
SortAllRowArray(Array);
WriteLine();
PrintArray(Array);

void SortAllRowArray (int[,] array) {
	for (int i = 0; i < array.GetLength(0); i ++)
		SortRowArray(array, i);
}

void SortRowArray (int[,] array, int row) {
	for (int i = 0; i < array.GetLength(1) - 1; i ++) {
		int indexMin = i;
		for (int j = i + 1; j < array.GetLength(1); j ++) 
			if (array[row, j] < array[row, indexMin])		indexMin = j;
		int tmp = array[row, i];
		array[row, i] = array[row, indexMin];
		array[row, indexMin] = tmp;
	}
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
