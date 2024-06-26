using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Points
    {
        public short x;
        public short y;

        public Points(nint pointer)
        {
            var ps = new Points();
            unsafe
            {
                ps = *(Points*)&pointer;
            }
            x = ps.x;
            y = ps.y;
        }

        public Points(short x, short y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
