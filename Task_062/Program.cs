/*
Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/


using System;
using static System.Console;

Clear();
/*
Write("Enter the number of matrix rows: ");
int intRows = int.Parse(Console.ReadLine());
Write("Enter the number of matrix columns: ");
int intColumns = int.Parse(Console.ReadLine());
*/
int intRows = 4;
int intColumns = 4;
int elem = 1; // первое число в массиве

int[,] intSpiralArray = GetSpiralArray(intRows, intColumns);
PrintArray(intSpiralArray);
WriteLine();



int[,] GetSpiralArray(int intLocalRows, int intLocalColumns)
{

    int[,] result = new int[intLocalRows, intLocalColumns];
    for (int j = 0; j < intLocalColumns; j++)   // идем слева направо
    {
        result[0, j] = elem;
        elem++;
    }
    for (int i = 1; i < intLocalRows; i++)      // идем вниз
    {
        result[i, intLocalColumns - 1] = elem;
        elem++;
    }
    for (int j = intLocalColumns - 2; j >= 0; j--) // идем справа налево
    {
        result[intLocalRows - 1, j] = elem;
        elem++;
    }
    for (int i = intLocalRows - 2; i > 0; i--)      // идем наверх
    {
        result[i, 0] = elem;
        elem++;
    }
    /* 
                [x, y+1]
        [x-1, y] [x, y]  [x+1, y]
                [x-1, y]
    */
    int x = 1, y = 1;   // индекс следущей ячейки массива
    while (elem < intLocalRows * intLocalColumns)
    {
        while (result[x, y + 1] == 0) // идем направо
        {
            result[x, y] = elem;
            elem++;
            y++;
        }
        while (result[x + 1, y] == 0) // идем вниз
        {
            result[x, y] = elem;
            elem++;
            x++;
        }
        while (result[x, y - 1] == 0) // идем налево
        {
            result[x, y] = elem;
            elem++;
            y--;
        }
        while (result[x - 1, y] == 0) // идем вверх
        {
            result[x, y] = elem;
            elem++;
            x--;
        }
        for (int i = 0; i < intLocalRows; i++)
        {
            for (int j = 0; j < intLocalColumns; j++)
            {
                if (result[i, j] == 0) result[i, j] = elem;
            }
        }

    }
    return result;
}

void PrintArray(int[,] intLocalArray)
{
    for (int i = 0; i < intLocalArray.GetLength(0); i++)
    {
        for (int j = 0; j < intLocalArray.GetLength(1); j++)
        {
            if (intLocalArray[i, j] < 10) Write($"{intLocalArray[i, j]}  ");
            else Write($"{intLocalArray[i, j]} ");
        }
          WriteLine();
    }
}