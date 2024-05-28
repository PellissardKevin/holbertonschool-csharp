using System;


/// <summary>
/// Provides a suite of linear algebra helper methods.
/// </summary>
class MatrixMath
{
    /// <summary>
    /// Adds two 2D or 3D matrices.
    /// </summary>
    /// <param name="matrix1">the first matrix.</param>
    /// <param name="matrix2">yhe second matrix</param>
    /// <returns>
    /// The result of two matrix multiply, or -1 if matrix is of invalid size.
    /// </returns>
    public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
    {
        //Check if matrices can be multiplied
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
            return new double[,] { { -1 } };

        double[,] resultMatrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];

        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                resultMatrix[i, j] = 0;

                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return resultMatrix;
    }
}
