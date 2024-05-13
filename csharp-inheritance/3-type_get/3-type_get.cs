using System;
using System.Reflection;

/// <summary>
/// Represents a class with utility methods for object inspection.
/// </summary>
public class Obj
{
    /// <summary>
    /// Prints the names of the available properties and methods of an object.
    /// </summary>
    /// <param name="myObj">The object to inspect.</param>
    public static void Print(object myObj)
    {
        Type objectType = myObj.GetType();

        Console.WriteLine($"{objectType.Name} Properties:");
        PropertyInfo[] properties = objectType.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine(property.Name);
        }

        Console.WriteLine($"{objectType.Name} Methods:");
        MethodInfo[] methods = objectType.GetMethods();
        foreach (MethodInfo method in methods)
        {
            Console.WriteLine(method.Name);
        }
    }
}
