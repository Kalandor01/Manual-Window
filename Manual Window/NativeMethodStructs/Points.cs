﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PointS
    {
        public short x;
        public short y;

        public PointS(nint pointer)
        {
            var ps = new PointS();
            unsafe
            {
                ps = *(PointS*)&pointer;
            }
            x = ps.x;
            y = ps.y;
        }

        public PointS(short x, short y)
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
            if (obj == null || obj is not PointS p)
            {
                return false;
            }
            return p.x == x && p.y == y;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static bool operator ==(PointS left, PointS right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointS left, PointS right)
        {
            return !(left == right);
        }
    }
}
