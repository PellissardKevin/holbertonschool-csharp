using System;

public class MatrixMath
{
    public static double[,] Add(double[,] matrix1, double[,] matrix2)
    {
        if ((matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1)) &&
            ((matrix1.GetLength(0) == 2 && matrix1.GetLength(1) == 2) || (matrix1.GetLength(0) == 3 && matrix1.GetLength(1) == 3)))
        {
            // Create a new matrix to store the result
            double[,] resultMatrix = new double[matrix1.GetLength(0), matrix1.GetLength(1)];

            // Add corresponding elements of the two matrices
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return resultMatrix;
        }
        else
        {
            return new double[,] { { -1 } };
        }
    }
}
