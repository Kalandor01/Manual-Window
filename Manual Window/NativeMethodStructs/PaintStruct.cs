using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PaintStruct
    {
        /// <summary>
        /// A handle to the device context.
        /// </summary>
        public DeviceContextHandle deviceContextHandle;
        public bool fErase;
        /// <summary>
        /// A handle to the rectangle that needs to be painted.
        /// </summary>
        public Rectangle rcPaint;
        public bool fRestore;
        public bool fIncUpdate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] rgbReserved;
    }
}
