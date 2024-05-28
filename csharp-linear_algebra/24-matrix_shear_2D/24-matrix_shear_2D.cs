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
        // Check if the matrix is of size 2x2
        if (matrix.Length != 4 || matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            return new double[,] { { -1 } };
        }

        // Check if the direction is valid
        if (direction != 'x' && direction != 'y')
        {
            return new double[,] { { -1 } };
        }

        // Initialize the shear matrix and the result matrix
        double[,] shearMat = { { 1, 0 }, { 0, 1 } };
        double[,] shearedMat = new double[2, 2];
        int numLines = matrix.GetLength(0);

        // Set the shear factor in the shear matrix
        if (direction == 'x')
        {
            shearMat[0, 1] = factor;
        }
        else
        {
            shearMat[1, 0] = factor;
        }

        // Perform the shearing operation
        for (int i = 0; i < numLines; i++)
        {
            shearedMat[i, 0] = shearMat[0, 0] * matrix[i, 0] + shearMat[0, 1] * matrix[i, 1];
            shearedMat[i, 1] = shearMat[1, 0] * matrix[i, 0] + shearMat[1, 1] * matrix[i, 1];
        }

        return shearedMat;
    }
}

