﻿using System;


class VectorMath
{
    public static double Magnitude(double[] vector)
    {
        Double dimensions = vector.Length;

        if (dimensions != 2 || dimensions != 3)
        {
            return (-1);
        }

        return dimensions;
    }
}

