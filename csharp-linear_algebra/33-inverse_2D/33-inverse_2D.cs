using System;

class MatrixMath
{
    public static double[,] Inverse2D(double[,] matrix)
    {
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            return new double[,] { { -1 } };
        }

        double a = matrix[0, 0];
        double b = matrix[0, 1];
        double c = matrix[1, 0];
        double d = matrix[1, 1];

        double determinant = a * d - b * c;

        if (determinant == 0)
        {
            return new double[,] { { -1 } };
        }

        double[,] matrixInverse = new double[2, 2];
        matrixInverse[0, 0] = Math.Round(d / determinant, 2);
        matrixInverse[0, 1] = Math.Round(-b / determinant, 2);
        matrixInverse[1, 0] = Math.Round(-c / determinant, 2);
        matrixInverse[1, 1] = Math.Round(a / determinant, 2);

        return matrixInverse;
    }
}
