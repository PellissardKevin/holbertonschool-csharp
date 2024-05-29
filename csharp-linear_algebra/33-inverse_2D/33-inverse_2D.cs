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
        double[,] inverse = new double[,] { { matrix[1, 1] / determinant, -matrix[0, 1] / determinant }, { -matrix[1, 0] / determinant, matrix[0, 0] / determinant } };

        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                inverse[i, j] = Math.Round(inverse[i, j], 2);

        return inverse;
    }
}

