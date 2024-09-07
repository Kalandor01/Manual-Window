using ManualWindow.NativeMethodEnums;

namespace ManualWindow.WindowEventArgs
{
    /// <summary>
    /// Class for storing the arguments of the <c>KeyDown</c> event.
    /// </summary>
    public class KeyDownEventArgs
    {
        /// <summary>
        /// The pressed key.
        /// </summary>
        public readonly VirtualKeyCode pressedKey;
        /// <summary>
        /// The integer representation of the key stroke flags.<br/>
        /// Use the <see cref="Tools.GetKeystrokeMessageFlags(nint, out short, out byte, out bool, out bool[], out bool, out bool, out bool)"/> function to unpack the parameters.
        /// </summary>
        public readonly nint keyStrokeFlags;

        /// <summary>
        /// <inheritdoc cref="KeyDownEventArgs"/>
        /// </summary>
        /// <param name="messageExtra1">The first extra parameter.</param>
        /// <param name="messageExtra2">The second extra parameter.</param>
        public KeyDownEventArgs(
            nint messageExtra1,
            nint messageExtra2
        )
        {
            pressedKey = (VirtualKeyCode)messageExtra1;
            keyStrokeFlags = messageExtra2;
        }
    }
}
