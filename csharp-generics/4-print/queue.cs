using System;

class Queue<T>
{

    public Node head { get; set; } = null;
    public Node tail { get; set; } = null;
    int count { get; set; } = 0;

    public Type CheckType()
    {
        return typeof(T);
    }

    public class Node
    {

        public T value { get; set; }
        public Node next { get; set; } = null;

        public Node(T _value)
        {
            value = _value;
        }

    }

    public void Enqueue(T _value)
    {

        Node newNode = new Node(_value);

        // If head does not exist, set new node as head and tail.
        if (head == null)
        {
            tail = head = newNode;
        }
        else
        {
            // Add new node.
            tail.next = newNode;
            tail = newNode;
        }
        // Increment count of nodes in queue.
        count++;
    }

    public T Dequeue()
    {

        if (head != null)
        {

            T value = head.value;

            // If node being removed is only node...
            if (head == tail)
            {
                tail = null;
            }

            // Move head forward to reference next node.
            head = head.next;

            // Decrement count of nodes in queue.
            count--;

            return value;

        }
        else
        {

            // If queue is empty...
            Console.WriteLine("Queue is empty");
            return default(T);

        }
    }

    public T Peek()
    {

        if (head != null)
        {
            return head.value;
        }
        else
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

    }

    public void Print()
    {

        if (head != null)
        {

            Node runner = head;

            while (runner != null)
            {
                Console.WriteLine(runner.value);
                runner = runner.next;
            }

        }
        else
        {

            Console.WriteLine("Queue is empty");

        }

    }

    public int Count()
    {
        return count;
    }
}
