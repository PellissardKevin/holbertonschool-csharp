using System;

public class VectorMath
{
    public static double? DotProduct(double[] vector1, double[] vector2)
    {
        if (vector1.Length == vector2.Length && (vector1.Length == 2 || vector1.Length == 3))
        {
            double dotProduct = 0;

            // Calculate the dot product
            for (int i = 0; i < vector1.Length; i++)
                vector1[i] *= vector2[i];
    
            // Return sum of products
            return vector1.Sum();
        }
        else
        {
            return -1;
        }
    }
}
