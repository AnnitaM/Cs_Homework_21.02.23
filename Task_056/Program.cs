/*
Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2 // 14
5 9 2 3 // 19
8 4 2 4 // 18
5 2 6 7 // 20
Программа считает сумму элементов в каждой строке и 
выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

using System;
using static System.Console;

Clear();
Write("Enter the number of matrix rows: ");
int intRows = int.Parse(Console.ReadLine());
Write("Enter the number of matrix columns: ");
int intColumns = int.Parse(Console.ReadLine());

int[,] matrix = GetMatrix(intRows, intColumns, 0, 9);
int[] sumLine = GetSumLine(matrix);

PrintMatrix(matrix);
WriteLine();
Write($"{String.Join(" ", sumLine)}");
WriteLine();
WriteLine($"The row with the smallest sum of elements is {SmallestSumRow(sumLine)+1}");

int[,] GetMatrix(int localRows, int localColumns, int localMin, int localMax)
{
    int[,] localMatrix = new int[localRows, localColumns];
    for (int i = 0; i < localRows; i++)
    {
        for (int j = 0; j < localColumns; j++)
        {
            localMatrix[i, j] = new Random().Next(localMin, localMax);
        }
    }
    return localMatrix;
}

int[] GetSumLine(int[,] intLocalMatrix)
{
    
    int[] localSumLine = new int[intLocalMatrix.GetLength(1)];
    for (int i = 0; i < intLocalMatrix.GetLength(1); i++)
    {
        for (int j = 0; j < intLocalMatrix.GetLength(0); j++)
        {
            localSumLine[i] += intLocalMatrix[i, j];
        }
    }
    return localSumLine;
}

int SmallestSumRow(int[] localSumLine)
{
    int min = localSumLine[0];
    int rowNum = 0;
    for (int i = 0; i < localSumLine.Length; i++)
    {
        if (localSumLine[i] < min)
        {
            min = localSumLine[i];
            rowNum = i;
        }
    }
    return rowNum;
}

void PrintMatrix(int[,] intLocalMatrix)
{
    for (int i = 0; i < intLocalMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < intLocalMatrix.GetLength(1); j++)
        {
            Write($"{intLocalMatrix[i, j]} ");
        }
        WriteLine();
    }
}