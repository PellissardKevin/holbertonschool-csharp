using System;


/// <summary>
/// Provides a suite of linear algebra helper methods.
/// </summary>
class MatrixMath
{
    /// <summary>
    /// Adds two 2D or 3D matrices.
    /// </summary>
    /// <param name="matrix">the matrix.</param>
    /// <param name="scalar">scalar to multiply the matrix</param>
    /// <returns>
    /// The result of the matrix scale, or -1 if matrix is of invalid size.
    /// </returns>
    public static double[,] MultiplyScalar(double[,] matrix, double scalar)
    {
        if (((matrix.GetLength(0) == 2 && matrix.GetLength(1) == 2) ||
            (matrix.GetLength(0) == 3 && matrix.GetLength(1) == 3)))
        {
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    // Add together the corresponding values
                    matrix[y, x] *= scalar;
                }
            }
            return matrix;
        }
        return new double[,] { { -1 } };
    }
}
