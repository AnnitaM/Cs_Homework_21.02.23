/*
Задайте двумерный массив. Напишите программу, которая упорядочит 
по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

using System;
using static System.Console;

Clear();
Write("Enter the number of array rows: ");
int intRows = int.Parse(Console.ReadLine());
Write("Enter the number of array columns: ");
int intColumns = int.Parse(Console.ReadLine());

int[,] intArray = GetArray(intRows, intColumns, 0, 9);
PrintArray(intArray);
WriteLine();
PrintArray(GetSortedArray(intArray));

int[,] GetArray(int intLocalM, int intLocalN, int intLocalMin, int intLocalMax)
{
    int[,] intLocalResult = new int[intLocalM, intLocalN];
    for (int i = 0; i < intLocalM; i++)
    {
        for (int j = 0; j < intLocalN; j++)
        {
            intLocalResult[i, j] = new Random().Next(intLocalMin, intLocalMax + 1);
        }
    }
    return intLocalResult;
}


int[,] GetSortedArray(int[,] intLocalArray)
{
    int[,] intLocalSortArray = intLocalArray; // копия исходного массива
    int temp;
    for (int i = 0; i < intLocalArray.GetLength(0); i++)
    {
        for (int j = 0; j <= intLocalArray.GetLength(1) - 1; j++)
        {
            for (int k = 0; k <= intLocalArray.GetLength(1) - 2; k++)
            {
            if (intLocalSortArray[i, k] < intLocalSortArray[i, k + 1])
            {
                temp = intLocalSortArray[i, k];
                intLocalSortArray[i, k] = intLocalSortArray[i, k + 1];
                intLocalSortArray[i, k + 1] = temp;
            }
            }

        }
    }
    return intLocalSortArray;
}

void PrintArray(int[,] intLocalArray)
{
    for (int i = 0; i < intLocalArray.GetLength(0); i++)
    {
        for (int j = 0; j < intLocalArray.GetLength(1); j++)
        {
            Write($"{intLocalArray[i, j]} ");
        }
        WriteLine();
    }
}