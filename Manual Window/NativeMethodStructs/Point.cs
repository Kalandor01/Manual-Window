using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int x;
        public int y;

        [Obsolete("You may not use the parameterless constructor.", error: true)]
        public Point() => throw new InvalidOperationException("You may not use the parameterless constructor.");
        
        internal Point(nint pointer)
        {
            Point ps;
            unsafe
            {
                ps = *(Point*)&pointer;
            }
            x = ps.x;
            y = ps.y;
        }

        public Point(int x, int y)
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
            if (obj == null || obj is not Point p)
            {
                return false;
            }
            return p.x == x && p.y == y;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }
    }
}
