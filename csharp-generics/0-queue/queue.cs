using System;


/// <summary>
/// Represents a generic queue data structure.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
class Queue<T>
{
    /// <summary>
    /// Returns the type of elements in the queue.
    /// </summary>
    /// <returns>The type of elements in the queue.</returns>
    public Type CheckType()
    {
        return typeof(T);
    }
}
