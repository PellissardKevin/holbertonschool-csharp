using System;

/// <summary>
/// Represents a generic queue data structure.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
class Queue<T>
{
    /// <summary>
    /// Gets or sets the node at the front of the queue.
    /// </summary>
    public Node head { get; set; } = null;

    /// <summary>
    /// Gets or sets the node at the end of the queue.
    /// </summary>
    public Node tail { get; set; } = null;

    /// <summary>
    /// Gets or sets the number of elements in the queue.
    /// </summary>
    private int count { get; set; } = 0;

    /// <summary>
    /// Returns the type of elements stored in the queue.
    /// </summary>
    /// <returns>The type of elements stored in the queue.</returns>
    public Type CheckType()
    {
        return typeof(T);
    }

    /// <summary>
    /// Represents a node in the queue.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets or sets the value stored in the node.
        /// </summary>
        public T value { get; set; }

        /// <summary>
        /// Gets or sets the next node in the queue.
        /// </summary>
        public Node next { get; set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class with the specified value.
        /// </summary>
        /// <param name="_value">The value to store in the node.</param>
        public Node(T _value)
        {
            value = _value;
        }
    }

    /// <summary>
    /// Adds an element to the end of the queue.
    /// </summary>
    /// <param name="_value">The value to add to the queue.</param>
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

    /// <summary>
    /// Removes and returns the element at the front of the queue.
    /// </summary>
    /// <returns>The value of the element at the front of the queue, or the default value of T if the queue is empty.</returns>
    public T Dequeue()
    {
        if (head != null)
        {
            T value = head.value;

            // If node being removed is the only node...
            if (head == tail)
            {
                tail = null;
            }

            // Move head forward to reference the next node.
            head = head.next;

            // Decrement count of nodes in queue.
            count--;

            return value;
        }
        else
        {
            // If the queue is empty...
            Console.WriteLine("Queue is empty");
            return default(T);
        }
    }

    /// <summary>
    /// Gets the number of elements in the queue.
    /// </summary>
    /// <returns>The number of elements in the queue.</returns>
    public int Count()
    {
        return count;
    }
}
