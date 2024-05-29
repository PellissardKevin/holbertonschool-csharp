using System;

class MatrixMath
{
    public static double Determinant(double[,] matrix)
    {
        if (matrix.Length != 4 && matrix.Length != 9)
            return -1;

        //Checks if matrix is 2D or 3D
        if (matrix.GetLength(0) != 2 && matrix.GetLength(1) != 2 && matrix.GetLength(0) != 3 && matrix.GetLength(1) != 3)
            return -1;

        if (matrix.Length == 4)
            return Math.Round(matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0], 2);
        else
            return Math.Round(matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
           matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
           matrix[0, 2] * matrix[1, 0] * matrix[2, 1] -
           matrix[0, 2] * matrix[1, 1] * matrix[2, 0] -
           matrix[0, 1] * matrix[1, 0] * matrix[2, 2] -
           matrix[0, 0] * matrix[1, 2] * matrix[2, 1], 2);
    }
}
