using System;
using System.Reflection;

public class Obj
{
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
