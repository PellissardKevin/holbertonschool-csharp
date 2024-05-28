using System;


/// <summary>
/// Provides a suite of linear algebra helper methods.
/// </summary>
class MatrixMath
{
    /// <summary>
    /// Shear 2D matrix.
    /// </summary>
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // Check if the matrix is square
        if (rows != cols)
        {
            return new double[,] { { -1 } };
        }

        // Check if the direction is valid
        if (direction != 'x' && direction != 'y')
        {
            return new double[,] { { -1 } };
        }

        // Initialize the shear matrix based on the direction
        double[,] shearMatrix;
        if (direction == 'x')
        {
            shearMatrix = new double[,]
            {
                { 1, factor },
                { 0, 1 }
            };
        }
        else // direction == 'y'
        {
            shearMatrix = new double[,]
            {
                { 1, 0 },
                { factor, 1 }
            };
        }

        // Perform the matrix multiplication
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < cols; k++)
                {
                    result[i, j] += shearMatrix[i, k] * matrix[k, j];
                }
            }
        }

        return result;
    }
}

