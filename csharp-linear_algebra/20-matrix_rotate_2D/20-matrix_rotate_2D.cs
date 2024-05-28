using System;


/// <summary>
/// Provides a suite of linear algebra helper methods.
/// </summary>
class MatrixMath
{
    /// <summary>
    /// Rotate 2D matrix.
    /// </summary>
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        //Check if matrices can be multiplied
        if ((matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2))
            return new double[,] { { -1 } };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        double[,] rotatedMatrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            rotatedMatrix[i, 0] = Math.Round(matrix[i, 0] * Math.Cos(angle) - matrix[i, 1] * Math.Sin(angle), 2);
            rotatedMatrix[i, 1] = Math.Round(matrix[i, 0] * Math.Sin(angle) + matrix[i, 1] * Math.Cos(angle), 2);
        }

        return rotatedMatrix;
    }
}
