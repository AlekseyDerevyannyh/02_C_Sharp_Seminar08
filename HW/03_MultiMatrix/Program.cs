// **Задача 58:** Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, заданы 2 массива:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// и
// 1 5 8 5
// 4 9 4 2
// 7 2 2 6
// 2 3 4 7
// Их произведение будет равно следующему массиву:
// 1 20 56 10
// 20 81 8 6
// 56 8 4 24
// 10 6 24 49

using System;
using static System.Console;

Clear();
Write("Введите число строк матрицы А: ");
int mA = Convert.ToInt32(ReadLine());
Write("Введите число столбцов матрицы А: ");
int nA = Convert.ToInt32(ReadLine());
Write("Введите число строк матрицы В: ");
int mB = Convert.ToInt32(ReadLine());
Write("Введите число столбцов матрицы В: ");
int nB = Convert.ToInt32(ReadLine());
int[,] matrixA = GetRandomArray(mA, nA, 1, 9);
int[,] matrixB = GetRandomArray(mB, nB, 1, 9);
WriteLine();
WriteLine("Matrix A:");
PrintArray(matrixA);
WriteLine();
WriteLine("Matrix B:");
PrintArray(matrixB);
WriteLine();
WriteLine("Matrix A * Matrix B:");
PrintArray(MultiplicationMatrix(matrixA, matrixB));


int[,] MultiplicationMatrix(int[,] matrix1, int[,] matrix2) {
	if (matrix1.GetLength(1) != matrix2.GetLength(0)) {
		WriteLine("ОШИБКА! Матрицы не согласованы!");
		return new int[,]{{0}};
	}
	int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
	for (int i = 0; i < matrix1.GetLength(0); i ++)
		for (int j = 0; j < matrix2.GetLength(1); j ++)
			for (int k = 0; k < matrix1.GetLength(1); k ++)
				result[i, j] += matrix1[i, k] * matrix2[k, j];
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