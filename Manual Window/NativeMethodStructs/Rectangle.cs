using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public Rectangle(nint pointer)
        {
            var r = new Rectangle();
            unsafe
            {
                r = *(Rectangle*)&pointer;
            }
            left = r.left;
            top = r.top;
            right = r.right;
            bottom = r.bottom;
        }

        public Rectangle(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public int Width
        {
            get
            {
                return right - left;
            }
        }

        public int Height
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
            //return $"pos: ({right}, {bottom}), size: ({Width}, {Height})";
            return $"t: {top}, l: {left}, r: {right}, b: {bottom}";
        }
    }
}
