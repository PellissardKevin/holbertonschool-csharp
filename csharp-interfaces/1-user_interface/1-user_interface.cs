using System;

public abstract class Base
{
    public string name { get; set; }

    public override string ToString()
    {
        return $"{name} is a {GetType().Name}";
    }
}

public interface IInteractive
{
    void Interact();
}

public interface IBreakable
{
    int Durability { get; set; }
    void Break();
}

public interface ICollectable
{
    bool IsCollected { get; set; }
    void Collect();
}

public class TestObject : Base, IInteractive, IBreakable, ICollectable
{
    // Implement the properties for IBreakable and ICollectable
    public int Durability { get; set; }
    public bool IsCollected { get; set; }

    // Implement the methods for IInteractive, IBreakable, and ICollectable
    public void Interact()
    {
        // Method implementation here
    }

    public void Break()
    {
        // Method implementation here
    }

    public void Collect()
    {
        // Method implementation here
    }
}
