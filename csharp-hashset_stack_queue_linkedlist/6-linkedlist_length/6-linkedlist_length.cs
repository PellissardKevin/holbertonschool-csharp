using System;
using System.Collections.Generic;

class LList
{
    public static int Length(LinkedList<int> myLList)
    {
        int numNode = 0;

        foreach (var node in myLList)
        {
            numNode++;
        }

        return numNode;
    }
}

