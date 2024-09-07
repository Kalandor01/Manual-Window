using ManualWindow.NativeMethodStructs;

namespace ManualWindow.WindowEventArgs
{
    /// <summary>
    /// Class for storing the arguments of the <c>PaintRequest</c> event.
    /// </summary>
    public class PaintRequestEventArgs
    {
        /// <summary>
        /// The handle to the device context.
        /// </summary>
        public readonly DeviceContextHandle deviceContextHandle;
        /// <summary>
        /// The paint struct
        /// </summary>
        public readonly PaintStruct paint;

        /// <summary>
        /// <inheritdoc cref="PaintRequestEventArgs"/>
        /// </summary>
        /// <param name="deviceContextHandle"><inheritdoc cref="deviceContextHandle" path="//summary"/></param>
        /// <param name="paint"><inheritdoc cref="paint" path="//summary"/></param>
        public PaintRequestEventArgs(
            DeviceContextHandle deviceContextHandle,
            PaintStruct paint
        )
        {
            this.deviceContextHandle = deviceContextHandle;
            this.paint = paint;
        }
    }
}
