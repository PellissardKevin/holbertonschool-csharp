using System;


class VectorMath
{

    public static double Magnitude(double[] vector)
    {
        if (vector.Length == 2 || vector.Length == 3)
        {
            double sumOfSquares = 0;
            foreach (double component in vector)
            {
                sumOfSquares += component * component;
            }

            double magnitude = Math.Sqrt(sumOfSquares);

            return Math.Round(magnitude, 2);
        }
        else
        {
            return -1;
        }
    }
}
