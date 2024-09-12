using ManualWindow.WindowMessageEnums;
using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    /// <summary>
    /// Contains information about the size and position of a window.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowPos
    {
        /// <summary>
        /// A handle to the window.
        /// </summary>
        public WindowHandle hwnd;
        /// <summary>
        /// A handle to the window in front of this window in the Z order, or a special value (-2 - 1).
        /// </summary>
        public WindowHandle hwndInsertAfter;
        /// <summary>
        /// The position of the left edge of the window.
        /// </summary>
        public int x;
        /// <summary>
        /// The position of the top edge of the window.
        /// </summary>
        public int y;
        /// <summary>
        /// The window width, in pixels.
        /// </summary>
        public int width;
        /// <summary>
        /// The window height, in pixels.
        /// </summary>
        public int height;
        /// <summary>
        /// The window position. A combination of values from the WindowPosFlags enum.
        /// </summary>
        public uint flags;

        [Obsolete("You may not use the parameterless constructor.", error: true)]
        public WindowPos() => throw new InvalidOperationException("You may not use the parameterless constructor.");

        /// <summary>
        /// <inheritdoc cref="WindowPos" path="//summary"/>
        /// </summary>
        /// <param name="pointer">A pointer to a WINDOWPOS object.</param>
        internal WindowPos(nint pointer)
        {
            WindowPos wp;
            unsafe
            {
                wp = *(WindowPos*)&pointer;
            }

            hwnd = wp.hwnd;
            hwndInsertAfter = wp.hwndInsertAfter;
            x = wp.x;
            y = wp.y;
            width = wp.width;
            height = wp.height;
            flags = wp.flags;
        }

        public override string ToString()
        {
            var f = flags;
            return $"pos: ({x}, {y}), size: ({width}, {height}), flags: [{string.Join(", ", Enum.GetValues<WindowPosFlags>().Where(flag => ((int)flag & f) != 0))}]";
        }
    }
}
