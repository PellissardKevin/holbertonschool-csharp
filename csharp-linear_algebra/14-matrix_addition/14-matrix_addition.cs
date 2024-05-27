using System;

public class MatrixMath
{
    public static double[,] Add(double[,] matrix1, double[,] matrix2)
    {
        // Get the dimensions of the matrices
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        // Check if the matrices have the same dimensions
        if ((rows1 == rows2 && cols1 == cols2) &&
            ((rows1 == 2 && cols1 == 2) || (rows1 == 3 && cols1 == 3)))
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
