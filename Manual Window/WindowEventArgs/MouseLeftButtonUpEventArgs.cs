using ManualWindow.NativeMethodStructs;
using ManualWindow.WindowMessageEnums;

namespace ManualWindow.WindowEventArgs
{
    /// <summary>
    /// Class for storing the arguments of the <c>MouseLeftButtonUp</c> event.
    /// </summary>
    public class MouseLeftButtonUpEventArgs
    {
        /// <summary>
        /// The curently pressed mouse buttons.
        /// </summary>
        public readonly List<MouseVirtualKey> butonsPressed;
        /// <summary>
        /// The position of the mouse.
        /// </summary>
        public readonly Point mousePosition;

        /// <summary>
        /// <inheritdoc cref="MouseLeftButtonUpEventArgs"/>
        /// </summary>
        /// <param name="messageExtra1">The first extra parameter.</param>
        /// <param name="messageExtra2">The second extra parameter.</param>
        public MouseLeftButtonUpEventArgs(
            nint messageExtra1,
            nint messageExtra2
        )
        {
            butonsPressed = Enum.GetValues<MouseVirtualKey>().Where(key => (messageExtra1 & (int)key) != 0).ToList();
            mousePosition = Tools.PointFromLParam(messageExtra2);
        }
    }
}
