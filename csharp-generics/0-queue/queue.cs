using System;


public class Queue<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int count;

    private class Node<U>
    {
        public U Data { get; set; }
        public Node<U> Next { get; set; }

        public Node(U data)
        {
            Data = data;
            Next = null;
        }
    }

    public Queue()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void Enqueue(T item)
    {
        Node<T> newNode = new Node<T>(item);

        if (tail != null)
        {
            tail.Next = newNode;
        }

        tail = newNode;

        if (head == null)
        {
            head = newNode;
        }

        count++;
    }

    public T Dequeue()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        T value = head.Data;
        head = head.Next;

        if (head == null)
        {
            tail = null;
        }

        count--;

        return value;
    }

    public T Peek()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return head.Data;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public int Count()
    {
        return count;
    }

    public Type CheckType()
    {
        return typeof(T);
    }
}

