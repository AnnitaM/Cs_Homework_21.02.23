/*
Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4  
3 2 | 3 3 
Результирующая матрица будет:
18 20
15 18
*/

using System;
using static System.Console;

Clear();
Write("Enter the number of matrix A rows: ");
int intRowsA = int.Parse(Console.ReadLine());
Write("Enter the number of matrix A columns: ");
int intColumnsA = int.Parse(Console.ReadLine());

WriteLine();

Write("Enter the number of matrix B rows: ");
int intRowsB = int.Parse(Console.ReadLine());
Write("Enter the number of matrix B columns: ");
int intColumnsB = int.Parse(Console.ReadLine());


int[,] matrixA = GetMatrixA(intRowsA, intColumnsA, 1, 9);

int[,] matrixB = GetMatrixB(intRowsB, intColumnsB, 1, 9);

int[,] matrixC = ProductMatrix(matrixA, matrixB);

PrintMatrix(matrixA);
WriteLine();

PrintMatrix(matrixB);
WriteLine();

PrintMatrix(matrixC);
WriteLine();

int[,] GetMatrixA(int localRowsA, int localColumnsA, int localMin, int localMax)
{
    int[,] localMatrixA = new int[localRowsA, localColumnsA];
    for (int i = 0; i < localRowsA; i++)
    {
        for (int j = 0; j < localColumnsA; j++)
        {
            localMatrixA[i, j] = new Random().Next(localMin, localMax);
        }
    }
    return localMatrixA;
}

int[,] GetMatrixB(int localRowsB, int localColumnsB, int localMin, int localMax)
{
    int[,] localMatrixB = new int[localRowsB, localColumnsB];
    for (int i = 0; i < localRowsB; i++)
    {
        for (int j = 0; j < localColumnsB; j++)
        {
            localMatrixB[i, j] = new Random().Next(localMin, localMax);
        }
    }
    return localMatrixB;
}

int[,] ProductMatrix(int[,] localmatrixA, int[,] localmatrixB)
{
    int[,] localProductMatrix = new int[localmatrixA.GetLength(0), localmatrixB.GetLength(1)];
    if (localmatrixA.GetLength(0) == localmatrixB.GetLength(1))
    {
        for (int i = 0; i < localmatrixA.GetLength(0); i++)
        {
            for (int j = 0; j < localmatrixB.GetLength(1); j++)
            {
                for (int k = 0; k < localmatrixB.GetLength(0); k++)
                {
                    localProductMatrix[i, j] += localmatrixA[i, k] * localmatrixB[k, j];
                }
            }
        }
    }
    if (localmatrixA.GetLength(1) != localmatrixB.GetLength(0)) WriteLine("Multiplication is impossible");
    return localProductMatrix;
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

