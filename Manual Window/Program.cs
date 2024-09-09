using ManualWindow.NativeMethodEnums;
using ManualWindow.NativeMethodStructs;
using ManualWindow.WindowEventArgs;
using ManualWindow.WindowMessageEnums;

namespace ManualWindow
{
    internal class Program
    {
        #region Fields
        private static int bgColorIndex = 0;
        private static SysColorIndex bgColor = SysColorIndex.COLOR_SCROLLBAR;
        private static SysColorIndex fgColor = SysColorIndex.COLOR_SCROLLBAR;
        private static Point pos1;
        private static List<(Rectangle rect, SysColorIndex color)> rectangles = [];
        #endregion

        #region Contructors
        private static void Main(string[] args)
        {
            var window = new Window();

            window.PaintRequest += OnPaintRequest;
            window.KeyDown += OnKeyDown;
            window.MouseLeftButtonDown += OnMouseLeftButtonDown;
            window.MouseLeftButtonUp += OnMouseLeftButtonUp;

            window.ShowWindow();
        }
        #endregion

        #region Event methods

        private static void OnPaintRequest(Window sender, PaintRequestEventArgs args)
        {
            var bgBrush = NativeMethods.GetSysColorBrush(bgColor);
            var bgRes = NativeMethods.FillRect(args.deviceContextHandle, args.paint.rcPaint, bgBrush);
            foreach (var rectangle in rectangles)
            {
                var rectBrush = NativeMethods.GetSysColorBrush(rectangle.color);
                var rectRes = NativeMethods.FillRect(args.deviceContextHandle, rectangle.rect, rectBrush);
            }

            var txt = "test text\tTAB: éűáÉŰÁÚŐÖÜÓöó";
            var paras = new DrawTextParams(4, 0, 0, (uint)txt.Length);
            var height = NativeMethods.DrawText(args.deviceContextHandle, txt, txt.Length, new Rectangle(0, 0, 200, 50), DrawTextFormat.NONE, paras);
        }

        private static void OnKeyDown(Window sender, KeyDownEventArgs args)
        {
            switch (args.pressedKey)
            {
                case VirtualKeyCode.B:
                    CycleBgColor();
                    sender.RepaintWindow(true);
                    break;
                case VirtualKeyCode.C:
                    rectangles.Clear();
                    sender.RepaintWindow(true);
                    break;
            }
        }

        private static void OnMouseLeftButtonDown(Window sender, MouseLeftButtonDownEventArgs args)
        {
            pos1 = args.mousePosition;
        }

        private static void OnMouseLeftButtonUp(Window sender, MouseLeftButtonUpEventArgs args)
        {
            CycleFgColor();
            var rect = new Rectangle(pos1, args.mousePosition);
            rectangles.Add((rect, fgColor));
            Console.WriteLine($"Recolored: {rect}");
            var ress = sender.RepaintWindow(true);
        }
        #endregion

        #region Methods
        private static SysColorIndex CycleColor(SysColorIndex currentColor)
        {
            var bgs = Enum.GetValues<SysColorIndex>();
            var nextColorIndex = Array.IndexOf(bgs, currentColor) + 1;
            if (nextColorIndex >= bgs.Length)
            {
                nextColorIndex = 0;
            }
            var nextColor = bgs[nextColorIndex];
            while ((int)nextColor == (int)currentColor)
            {
                nextColorIndex++;
                if (nextColorIndex >= bgs.Length)
                {
                    nextColorIndex = 0;
                }
                nextColor = bgs[nextColorIndex];
            }
            return nextColor;
        }

        private static void CycleBgColor()
        {
            bgColor = CycleColor(bgColor);
            Console.WriteLine($"BG Color change: {bgColor}");
        }

        private static void CycleFgColor()
        {
            fgColor = CycleColor(fgColor);
            Console.WriteLine($"FG Color change: {fgColor}");
        }
        #endregion
    }
}
