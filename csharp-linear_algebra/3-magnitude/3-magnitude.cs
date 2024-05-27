using System;

/// <summary>
/// Provides a suite of linear algebra helper methods.
/// </summary>
class VectorMath
{
    /// <summary>
    /// Calculate the magnitude of a 2D or 3D vector.
    /// </summary>
    /// <param name="vector">Vector for which to calculate magnitude.</param>
    /// <returns></returns>
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
