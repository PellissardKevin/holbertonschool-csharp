using System;


class Obj
{
    public static bool IsOnlyASubclass(Type derivedType, Type baseType)
    {
        if (baseType.IsAssignableFrom(derivedType) && derivedType != baseType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

