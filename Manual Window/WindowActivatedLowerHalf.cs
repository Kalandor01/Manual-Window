namespace ManualWindow
{
    /// <summary>
    /// The posible values for the lower 16 bits of the extra1 variable from the ACTIVATE_DEACTIVEATE window process message.
    /// </summary>
    public enum WindowActivatedLowerHalf
    {
        /// <summary>
        /// Activated by some method other than a mouse click (for example, by a call to the SetActiveWindow function or by use of the keyboard interface to select the window).
        /// </summary>
        ACTIVE = 1,
        /// <summary>
        /// Activated by a mouse click.
        /// </summary>
        CLICKED = 2,
        /// <summary>
        /// Deactivated.
        /// </summary>
        DEACTIVATED = 0,
    }
}
