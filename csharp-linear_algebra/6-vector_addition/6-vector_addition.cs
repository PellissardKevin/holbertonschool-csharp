using System;


class VectorMath
{

    public static double[] Add(double[] vector1, double[] vector2)
    {
        if ((vector1.Length == 2 || vector1.Length == 3) && vector1.Length == vector2.Length)
        {
            Vector vectorResult = new Vector();

            vectorResult = Vector.Add(vector1, vector2);

            return vectorResult;
        }
        else
        {
            return -1;
        }
    }
}
