using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RectangleL
    {
        public long left;
        public long top;
        public long right;
        public long bottom;

        [Obsolete("You may not use the parameterless constructor.", error: true)]
        public RectangleL() => throw new InvalidOperationException("You may not use the parameterless constructor.");

        internal RectangleL(nint pointer)
        {
            RectangleL r;
            unsafe
            {
                r = *(RectangleL*)&pointer;
            }
            left = r.left;
            top = r.top;
            right = r.right;
            bottom = r.bottom;
        }

        public RectangleL(long left, long top, long right, long bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public RectangleL(PointL topLeft, PointL bottomRight)
            : this(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y)
        {

        }

        public long Width
        {
            get
            {
                return right - left;
            }
        }

        public long Height
        {
            get
            {
                return bottom - top;
            }
        }

        public void Offset(int dx, int dy)
        {
            left += dx;
            top += dy;
            right += dx;
            bottom += dy;
        }

        public bool IsEmpty
        {
            get
            {
                return left >= right || top >= bottom;
            }
        }

        public override string ToString()
        {
            return $"t: {top}, l: {left}, r: {right}, b: {bottom}";
        }
    }
}
