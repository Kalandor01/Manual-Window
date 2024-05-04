namespace CleanWpfApp
{
    [FriendAccessAllowed] // Built into Base, also used by Core and Framework.
    internal static class BooleanBoxes
    {
        internal static readonly object TrueBox = true;
        internal static readonly object FalseBox = false;

        internal static object Box(bool value) =>
            value ? TrueBox : FalseBox;

        internal static object? Box(bool? value)
        {
            return value switch
            {
                true => TrueBox,
                false => FalseBox,
                null => null,
            };
        }
    }
}
