namespace ManualWindow
{
    /// <summary>
    /// The posible reasons for a WINDOW_SHOWN_OR_HIDE window process message firing.
    /// </summary>
    public enum WindowShowHideReason
    {
        /// <summary>
        /// The message was sent because of a call to the ShowWindow function.
        /// </summary>
        SHOW_WINDOW_FUNCTION = 0,
        /// <summary>
        /// The window is being uncovered because a maximize window was restored or minimized.
        /// </summary>
        WINDOW_UNCOVERED = 4,
        /// <summary>
        /// The window is being covered by another window that has been maximized.
        /// </summary>
        WINDOW_COVERED = 2,
        /// <summary>
        /// The window's owner window is being minimized.
        /// </summary>
        PARRENT_HIDDEN = 1,
        /// <summary>
        /// The window's owner window is being restored.
        /// </summary>
        PARRENT_SHOWN = 3,
    }
}
