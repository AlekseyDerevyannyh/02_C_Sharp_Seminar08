// **Задача 60.** Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// массив размером 2 x 2 x 2
// 12(0,0,0) 22(0,0,1)
// 45(0,1,0) 53(0,1,1)
// 32(1,0,0) 41(1,0,1)
// 66(1,1,0) 88(1,1,1)
using System;
using static System.Console;

Clear();
Write("Введите 1-ый размер трёхмерного массива: ");
int m = Convert.ToInt32(ReadLine());
Write("Введите 2-ой размер трёхмерного массива: ");
int n = Convert.ToInt32(ReadLine());
Write("Введите 3-ий размер трёхмерного массива: ");
int l = Convert.ToInt32(ReadLine());
int[,,] Array = GetRandomUnique3dArray(m, n, l);
WriteLine();
Print3DArray(Array);
WriteLine();


int[,,] GetRandomUnique3dArray (int row, int column, int depth) {
	if ( row * column * depth > 90) {
		WriteLine("ОШИБКА! Создать массив такой размерности без повторяющихся элементов не возможно!");
		return new int[,,]{{{0}}};
	}
	int[,,] result = new int[row, column, depth];
	int index = 0;
	for (int i = 0; i < row ; i ++) {
		for (int j = 0; j < column; j ++) {
			for (int k = 0; k < depth; k ++) {
				do {
					result[i, j, k] = new Random().Next(10, 100);
				} while (!UniqueCheck(Convert3dArrayTo1d(result), result[i, j, k], index));
				index ++;
			}
		}
	}
	return result;
}

bool UniqueCheck (int[] array, int value, int size) {
	for (int i = 0; i < size; i ++)
		if (array[i] == value)	return false;
	return true;
}

int[] Convert3dArrayTo1d (int[,,] array) {
	int[] result = new int[array.Length];
	int index = 0;
	for (int i = 0; i < array.GetLength(0); i ++) {
		for (int j = 0; j < array.GetLength(1); j ++) {
			for (int k = 0; k < array.GetLength(2); k ++) {
				result[index] = array[i, j, k];
				index ++;
			}
		}
	}
	return result;
}

void Print3DArray(int[,,] array) {
	for (int i = 0; i < array.GetLength(0); i ++) {
		for (int j = 0; j < array.GetLength(1); j ++) {
			for (int k = 0; k < array.GetLength(2); k ++) {
				Write($"{array[i, j, k]}({i},{j},{k}) ");
			}
			WriteLine();
		}
	}
}