using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct PaintStruct
    {
        /// <summary>
        /// A handle to the device context.
        /// </summary>
        public Windows.Win32.Graphics.Gdi.HDC hdc;
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
