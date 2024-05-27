﻿using System;

public class MatrixMath
{
    public static double[,] Add(double[,] matrix1, double[,] matrix2)
    {
        if (((matrix1.GetLength(0) == 2 && matrix1.GetLength(1) == 2) ||
         (matrix1.GetLength(0) == 3 && matrix1.GetLength(1) == 3)) &&
         matrix1.GetLength(0) == matrix2.GetLength(0))
        {
            for (int y = 0; y < matrix1.GetLength(0); y++)
            {
                for (int x = 0; x < matrix2.GetLength(1); x++)
                {
                    // Add together the corresponding values
                    matrix1[y, x] += matrix2[y, x];
                }
            }
            return matrix1;
        }
        return new double[,] { { -1 } };
    }
}
