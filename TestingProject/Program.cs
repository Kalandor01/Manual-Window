using ManualWindow.NativeMethodEnums;
using ManualWindow.NativeMethodStructs;
using ManualWindow.WindowEventArgs;
using ManualWindow.WindowMessageEnums;
using ManualWindow;

namespace TestProject
{
    internal class Program
    {
        #region Fields
        private static ColorReference bgColor = new ColorReference(0, 0, 0);
        private static Point pos1;
        private static List<(Rectangle rect, ColorReference color)> rectangles = [];
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
            var bgBrush = NativeMethods.CreateSolidBrush(bgColor);
            var bgRes = NativeMethods.FillRect(args.deviceContextHandle, args.paint.paintArea, bgBrush);
            foreach (var rectangle in rectangles)
            {
                var rectBrush = NativeMethods.CreateSolidBrush(rectangle.color);
                var rectRes = NativeMethods.FillRect(args.deviceContextHandle, rectangle.rect, rectBrush);
            }

            var txt = "test text\tTAB: éűáÉŰÁÚŐÖÜÓöó";
            var paras = new DrawTextParams(4, 0, 0, (uint)txt.Length);
            var height = NativeMethods.DrawText(args.deviceContextHandle, txt, new Rectangle(0, 0, 200, 50), DrawTextFormat.NONE, paras);
        }

        private static void OnKeyDown(Window sender, KeyDownEventArgs args)
        {
            switch (args.pressedKey)
            {
                case VirtualKeyCode.B:
                    bgColor = GetRandomColor();
                    Console.WriteLine($"BG Color change: {bgColor}");
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
            var fgColor = GetRandomColor();
            Console.WriteLine($"FG Color change: {fgColor}");
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

        private static ColorReference GetRandomColor()
        {
            var rc = new Random().Next();
            return new ColorReference((byte)((rc & 0xff0000) >> 16), (byte)((rc & 0xff00) >> 8), (byte)rc);
        }
        #endregion
    }
}
