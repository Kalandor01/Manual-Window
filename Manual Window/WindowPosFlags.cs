namespace ManualWindow
{
    public enum WindowPosFlags
    {
        /// <summary>
        /// Sends a CALCULATE_SIZE_AND_POSITION message to the window, even if the window's size is not being changed. If this flag is not specified, CALCULATE_SIZE_AND_POSITION is sent only when the window's size is being changed.
        /// </summary>
        FRAME_CHANGED = 32,
        ///// <summary>
        ///// Draws a frame (defined in the window's class description) around the window. Same as the FRAME_CHANGED flag.
        ///// </summary>
        //DRAW_FRAME = 32,
        /// <summary>
        /// Hides the window.
        /// </summary>
        HIDE_WINDOW = 128,
        /// <summary>
        /// Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hwndInsertAfter member).
        /// </summary>
        NO_ACTIVATE = 16,
        /// <summary>
        /// Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned.
        /// </summary>
        NO_COPY_BITS = 256,
        /// <summary>
        /// Retains the current position (ignores the x and y members).
        /// </summary>
        NO_MOVE = 2,
        /// <summary>
        /// Does not change the owner window's position in the Z order.
        /// </summary>
        NO_OWNER_Z_ORDER = 512,
        ///// <summary>
        ///// Does not change the owner window's position in the Z order. Same as the NO_OWNER_Z_ORDER flag.
        ///// </summary>
        //NO_REPOSITION = 512,
        /// <summary>
        /// Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the window being moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
        /// </summary>
        NO_REDRAW = 8,
        /// <summary>
        /// Prevents the window from receiving the BEFORE_WINDOW_POS_CHANGE message.
        /// </summary>
        NO_SEND_CHANGING = 1024,
        /// <summary>
        /// Retains the current size (ignores the cx and cy members).
        /// </summary>
        NO_SIZE = 1,
        /// <summary>
        /// Retains the current Z order (ignores the hwndInsertAfter member).
        /// </summary>
        NO_Z_ORDER = 4,
        /// <summary>
        /// Displays the window.
        /// </summary>
        SHOW_WINDOW = 64,
    }
}
