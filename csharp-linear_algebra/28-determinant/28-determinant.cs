using System;

class MatrixMath
{
    public static double Determinant(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // Check if the matrix is either 2x2 or 3x3
        if ((rows == 2 && cols == 2) || (rows == 3 && cols == 3))
        {
            if (rows == 2 && cols == 2)
            {
                // Determinant of a 2x2 matrix
                return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
            }
            else if (rows == 3 && cols == 3)
            {
                // Determinant of a 3x3 matrix
                return (matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                      - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                      + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]));
            }
        }

        // Return -1 for matrices that are not 2x2 or 3x3
        return -1;
    }
}
