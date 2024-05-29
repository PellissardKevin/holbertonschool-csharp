using System;


public class VectorMath
{
    public static double[] CrossProduct(double[] vector1, double[] vector2)
    {
        // Check if both vectors are 3D vectors
        if (vector1.Length != 3 || vector2.Length != 3)
        {
            return new double[] { -1 };
        }

        // Calculate the components of the cross product
        double x = vector1[1] * vector2[2] - vector1[2] * vector2[1];
        double y = vector1[2] * vector2[0] - vector1[0] * vector2[2];
        double z = vector1[0] * vector2[1] - vector1[1] * vector2[0];

        // Return the resulting vector
        return new double[] { x, y, z };
    }
}
