using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PointL
    {
        public long x;
        public long y;

        [Obsolete("You may not use the parameterless constructor.", error: true)]
        public PointL() => throw new InvalidOperationException("You may not use the parameterless constructor.");
        
        internal PointL(nint pointer)
        {
            PointL ps;
            unsafe
            {
                ps = *(PointL*)&pointer;
            }
            x = ps.x;
            y = ps.y;
        }

        public PointL(short x, short y)
        {
            this.x = x;
            this.y = y;
        }

        public override readonly string ToString()
        {
            return $"({x}, {y})";
        }

        public override readonly bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null || obj is not PointL p)
            {
                return false;
            }
            return p.x == x && p.y == y;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static bool operator ==(PointL left, PointL right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointL left, PointL right)
        {
            return !(left == right);
        }
    }
}
