// Description: Implementation of a FriendAccessAllowedAttribute attribute that is used to mark internal metadata
//              that is allowed to be accessed from friend assemblies.

using System;

namespace CleanWpfApp
{
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Property |
        AttributeTargets.Field |
        AttributeTargets.Method |
        AttributeTargets.Struct |
        AttributeTargets.Enum |
        AttributeTargets.Interface |
        AttributeTargets.Delegate |
        AttributeTargets.Constructor,
        AllowMultiple = false,
        Inherited = true)
    ]
    internal sealed class FriendAccessAllowedAttribute : Attribute
    {
    }
}
