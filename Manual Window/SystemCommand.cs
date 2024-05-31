namespace ManualWindow
{
    public enum SystemCommand
    {
        /// <summary>
        /// Closes the window.
        /// </summary>
        CLOSE = 61536,
        /// <summary>
        /// Changes the cursor to a question mark with a pointer. If the user then clicks a control in the dialog box, the control receives a WM_HELP message.
        /// </summary>
        CONTEXT_HELP = 61824,
        /// <summary>
        /// Selects the default item; the user double-clicked the window menu.
        /// </summary>
        DEFAULT = 61792,
        /// <summary>
        /// Activates the window associated with the application-specified hot key. The lParam parameter identifies the window to activate.
        /// </summary>
        HOTKEY = 61776,
        /// <summary>
        /// Scrolls horizontally.
        /// </summary>
        HORIZONTAL_SCROLL = 61568,
        /// <summary>
        /// Indicates whether the screen saver is secure.
        /// </summary>
        SCREEN_SAVES_IS_SECURE = 1,
        /// <summary>
        /// Retrieves the window menu as a result of a keystroke. For more information, see the Remarks section.
        /// </summary>
        KEY_MENU = 61696,
        /// <summary>
        /// Maximizes the window.
        /// </summary>
        MAXIMIZE = 61488,
        /// <summary>
        /// Minimizes the window.
        /// </summary>
        MINIMIZE = 61472,
        /// <summary>
        /// Maximizes the window, when the user double clicks the nonclient area.
        /// </summary>
        MAXIMIZE_DOUBLE_CLICK = 61490,
        /// <summary>
        /// Minimizes the window, when the user double clicks the nonclient area.
        /// </summary>
        MINIMIZE_DOUBLE_CLICK = 61730,
        /// <summary>
        /// Sets the state of the display. This command supports devices that have power-saving features, such as a battery-powered personal computer.
        /// The lParam parameter can have the following values:
        ///     -1 (the display is powering on)
        ///     1 (the display is going to low power)
        ///     2 (the display is being shut off)
        /// </summary>
        MONITOR_POWER = 61808,
        /// <summary>
        /// Retrieves the window menu as a result of a mouse click.
        /// </summary>
        MOUSE_MENU = 61587,
        /// <summary>
        /// Retrieves the window menu as a result of a mouse click. Or not?
        /// </summary>
        MOUSE_MENU_2 = 61584,
        /// <summary>
        /// Moves the window.
        /// </summary>
        MOVE = 61458,
        /// <summary>
        /// Moves the window, when the user clicks the move window button in the command menu.
        /// </summary>
        MENU_MOVE = 61456,
        /// <summary>
        /// Moves to the next window.
        /// </summary>
        NEXT_WINDOW = 61504,
        /// <summary>
        /// Moves to the previous window.
        /// </summary>
        PREV_WINDOW = 61520,
        /// <summary>
        /// Restores the window to its normal position and size.
        /// </summary>
        RESTORE = 61728,
        /// <summary>
        /// Executes the screen saver application specified in the [boot] section of the System.ini file.
        /// </summary>
        SCREEN_SAVE = 61760,
        /// <summary>
        /// Sizes the window, from the top.
        /// </summary>
        SIZE_TOP = 61443,
        /// <summary>
        /// Sizes the window, from the left.
        /// </summary>
        SIZE_LEFT = 61441,
        /// <summary>
        /// Sizes the window, from the bottom.
        /// </summary>
        SIZE_BOTTOM = 61446,
        /// <summary>
        /// Sizes the window, from the right.
        /// </summary>
        SIZE_RIGHT = 61442,
        /// <summary>
        /// Sizes the window, from the top left.
        /// </summary>
        SIZE_TOP_LEFT = 61444,
        /// <summary>
        /// Sizes the window, from the top right.
        /// </summary>
        SIZE_TOP_RIGHT = 61445,
        /// <summary>
        /// Sizes the window, from the bottom right.
        /// </summary>
        SIZE_BOTTOM_RIGHT = 61448,
        /// <summary>
        /// Sizes the window, from the bottom left.
        /// </summary>
        SIZE_BOTTOM_LEFT = 61447,
        /// <summary>
        /// Sizes the window, when the user clicks the move window button in the command menu.
        /// </summary>
        MENU_SIZE = 61440,
        /// <summary>
        /// Activates the Start menu.
        /// </summary>
        TASK_LIST = 61744,
        /// <summary>
        /// Scrolls vertically.
        /// </summary>
        VERTICAL_SCROLL = 61552,
    }
}
