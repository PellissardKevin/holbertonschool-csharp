using System;


class VectorMath
{

    public static double[] Add(double[] vector1, double[] vector2)
    {
        if ((vector1.Length == 2 || vector1.Length == 3) && vector1.Length == vector2.Length)
        {
            double[] resultVector = new double[vector1.Length];

            for (int i = 0; i < vector1.Length; i++)
            {
                resultVector[i] = vector1[i] + vector2[i];
            }

            return vectorResult;
        }
        else
        {
            return -1;
        }
    }
}
