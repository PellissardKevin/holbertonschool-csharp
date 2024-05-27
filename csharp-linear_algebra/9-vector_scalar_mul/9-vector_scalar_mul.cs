using System;


class VectorMath
{
    public static double[] Multiply(double[] vector, double scalar)
    {
        if (vector.Length == 2 || vector.Length == 3)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] *= scalar;
            }

            return vector;
        }
        else
        {
            return new double[] {-1};
        }
    }
}

