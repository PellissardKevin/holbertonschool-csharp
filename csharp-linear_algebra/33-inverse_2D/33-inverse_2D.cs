using System;

public class MatrixMath
{
    public static double[,] Inverse2D(double[,] matrix)
    {
        // Check if the input is a 2x2 matrix
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            return new double[,] { { -1 } };
        }

        // Extract elements of the matrix
        double a = matrix[0, 0];
        double b = matrix[0, 1];
        double c = matrix[1, 0];
        double d = matrix[1, 1];

        // Calculate the determinant
        double determinant = a * d - b * c;

        // Check if the matrix is invertible (determinant should not be zero)
        if (determinant == 0)
        {
            return new double[,] { { -1 } };
        }

        // Calculate the inverse matrix elements
        double invDet = 1 / determinant;
        double[,] inverseMatrix = new double[2, 2];

        inverseMatrix[0, 0] = d * invDet;
        inverseMatrix[0, 1] = -b * invDet;
        inverseMatrix[1, 0] = -c * invDet;
        inverseMatrix[1, 1] = a * invDet;

        return inverseMatrix;
    }
}
