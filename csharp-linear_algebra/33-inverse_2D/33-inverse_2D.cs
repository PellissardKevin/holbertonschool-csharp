using System;

public class MatrixMath
{
    public static double[,] Inverse2D(double[,] matrix)
    {
        // Check if the matrix is a 2D matrix
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            return new double[,] { { -1 } }; // Return [-1] for non-2D matrices
        }

        // Calculate the determinant of the 2x2 matrix
        double determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        // Check if the matrix is non-invertible
        if (determinant == 0)
        {
            return new double[,] { { -1 } }; // Return [-1] for non-invertible matrices
        }

        // Calculate the inverse of the 2x2 matrix
        double[,] inverse = new double[2, 2];
        inverse[0, 0] = matrix[1, 1] / determinant;
        inverse[0, 1] = -matrix[0, 1] / determinant;
        inverse[1, 0] = -matrix[1, 0] / determinant;
        inverse[1, 1] = matrix[0, 0] / determinant;

        return inverse;
    }
}

