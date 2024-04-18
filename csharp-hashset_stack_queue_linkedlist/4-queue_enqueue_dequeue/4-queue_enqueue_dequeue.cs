using System;
using System.Collections.Generic;

class MyQueue
{
    public static Queue<string> Info(Queue<string> aQueue, string newItem, string search)
    {
        Console.WriteLine($"Number of items: {aQueue.Count}");

        if (aQueue.Count > 0)
        {
            Console.WriteLine($"Top item: {aQueue.Peek()}");
        }
        else
        {
            Console.WriteLine("Stack is empty");
        }

        bool containsSearch = aQueue.Contains(search);
        Console.WriteLine($"Stack contains \"{search}\": {containsSearch}");


        if (containsSearch)
        {
            while (true)
            {
                var item = aQueue.Peek();
                aQueue.Dequeue();
                if (item == search)
                {
                    break;
                }
            }
        }

        aQueue.Enqueue(newItem);

        return aQueue;
    }
}

