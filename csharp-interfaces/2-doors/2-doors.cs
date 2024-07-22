using System;

/// <summary>
/// Represents a base class with a name property and a custom ToString method.
/// </summary>
public abstract class Base
{
    /// <summary>
    /// Gets or sets the name of the object.
    /// </summary>
    /// <value>The name of the object.</value>
    public string name { get; set; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string representing the current object.</returns>
    public override string ToString()
    {
        return $"{name} is a {this.GetType()}";
    }
}

/// <summary>
/// Represents an interactive object that can respond to interactions.
/// </summary>
public interface IInteractive
{
    /// <summary>
    /// Performs an interaction with the object.
    /// </summary>
    void Interact();
}

/// <summary>
/// Represents an object that can be broken and has durability.
/// </summary>
public interface IBreakable
{
    /// <summary>
    /// Gets or sets the durability of the object.
    /// </summary>
    /// <value>The durability value, which should be an integer.</value>
    int durability { get; set; }

    /// <summary>
    /// Breaks the object, reducing its durability.
    /// </summary>
    void Break();
}

/// <summary>
/// Represents an object that can be collected.
/// </summary>
public interface ICollectable
{
    /// <summary>
    /// Gets or sets a value indicating whether the object has been collected.
    /// </summary>
    /// <value><c>true</c> if the object is collected; otherwise, <c>false</c>.</value>
    bool isCollected { get; set; }

    /// <summary>
    /// Collects the object.
    /// </summary>
    void Collect();
}

/// <summary>
/// Door class
/// </summary>
public class Door : Base, IInteractive
{
    /// <summary>
    /// Door default constructor
    /// </summary>
    /// <param name="Name">Default name Door, value constructor</param>
    public Door(string Name = "Door")
    {
        this.name = Name;
    }
    /// <summary>
    /// Used for interactions.
    /// </summary>
    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}
