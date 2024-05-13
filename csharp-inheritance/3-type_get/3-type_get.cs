using System;
using System.Reflection;

public class Obj
{
    public static void Print(object myObj)
    {
        Type objectType = myObj.GetType();

        // Get properties
        PropertyInfo[] properties = objectType.GetProperties();
        Console.WriteLine("Int32 Properties:");
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine(property.Name);
        }

        // Get methods
        MethodInfo[] methods = objectType.GetMethods();
        Console.WriteLine("Int32 Methods:");
        foreach (MethodInfo method in methods)
        {
            Console.WriteLine(method.Name);
        }
    }
}
