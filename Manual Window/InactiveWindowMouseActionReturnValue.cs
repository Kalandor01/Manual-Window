namespace ManualWindow
{
    /// <summary>
    /// Whether the window should be activated and whether the ID of the mouse message should be discarded.
    /// </summary>
    public enum InactiveWindowMouseActionReturnValue
    {
        /// <summary>
        /// Activates the window, and does not discard the mouse message.
        /// </summary>
        ACTIVATE = 1,
        /// <summary>
        /// Activates the window, and discards the mouse message.
        /// </summary>
        ACTIVATE_AND_DISCARD = 2,
        /// <summary>
        /// Does not activate the window, and does not discard the mouse message.
        /// </summary>
        NO_ACTIVATE = 3,
        /// <summary>
        /// Does not activate the window, but discards the mouse message.
        /// </summary>
        NO_ACTIVATE_AND_DISCARD = 4,
    }
}
