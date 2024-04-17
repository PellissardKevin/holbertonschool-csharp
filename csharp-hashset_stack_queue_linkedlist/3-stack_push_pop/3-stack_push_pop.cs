using System;
using System.Collections.Generic;

class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        Console.WriteLine($"Number of items: {aStack.Count}");

        if (aStack.Count > 0)
        {
            Console.WriteLine($"Top item: {aStack.Peek()}");
        }
        else
        {
            Console.WriteLine("Stack is empty");
        }

        bool containsSearch = aStack.Contains(search);
        Console.WriteLine($"Stack contains {search}: {containsSearch}");

        Stack<string> tempStack = new Stack<string>();
        bool found = false;
        while (aStack.Count > 0)
        {
            string item = aStack.Pop();
            if (item == search)
            {
                found = true;
                break;
            }
            tempStack.Push(item);
        }
        
        if (!found)
        {
            while (tempStack.Count > 0)
            {
                aStack.Push(tempStack.Pop());
            }
        }

        aStack.Push(newItem);

        return aStack;
    }
}
