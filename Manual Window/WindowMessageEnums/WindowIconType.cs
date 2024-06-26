namespace ManualWindow.WindowMessageEnums
{
    /// <summary>
    /// The posible values for the extra1 variable from the GET_ICON window process message.
    /// </summary>
    public enum WindowIconType
    {
        /// <summary>
        /// The large icon for the window.
        /// </summary>
        BIG = 1,
        /// <summary>
        /// The small icon for the window.
        /// </summary>
        SMALL = 0,
        /// <summary>
        /// The small icon provided by the application.
        /// </summary>
        SMALL2 = 2,
    }
}
