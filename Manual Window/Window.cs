using System.Runtime.InteropServices;

namespace ManualWindow
{
    internal class Window
    {
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        [DllImport("user32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(nint hWnd, string lpText, string lpCaption, uint uType);

        [DllImport("user32.dll")]
        static extern bool UpdateWindow(nint hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(nint hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyWindow(nint hWnd);

        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", SetLastError = true)]
        public static extern nint CreateWindowEx(
               int dwExStyle,
               ushort regResult,
               //string lpClassName,
               string lpWindowName,
               uint dwStyle,
               int x,
               int y,
               int nWidth,
               int nHeight,
               nint hWndParent,
               nint hMenu,
               nint hInstance,
               nint lpParam);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "RegisterClassEx")]
        static extern ushort RegisterClassEx([In] ref WNDCLASSEX lpWndClass);

        [DllImport("user32.dll")]
        static extern nint DefWindowProc(nint hWnd, uint uMsg, nint wParam, nint lParam);

        [DllImport("user32.dll")]
        static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll")]
        static extern nint LoadCursor(nint hInstance, int lpCursorName);

        //[DllImport("user32.dll")]
        //static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
        //   uint wMsgFilterMax);

        //[DllImport("user32.dll")]
        //static extern bool TranslateMessage([In] ref MSG lpMsg);

        //[DllImport("user32.dll")]
        //static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        delegate nint WndProc(nint hWnd, uint msg, nint wParam, nint lParam);

        const uint WS_OVERLAPPEDWINDOW = 0b110011110000000000000000;
        const uint WS_VISIBLE = 0x10000000;
        const uint CS_USEDEFAULT = 0x80000000;
        const uint CS_DBLCLKS = 8;
        const uint CS_VREDRAW = 1;
        const uint CS_HREDRAW = 2;
        const uint COLOR_WINDOW = 5;
        const uint COLOR_BACKGROUND = 1;
        const uint IDC_CROSS = 32515;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct WNDCLASSEX
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public int style;
            public nint lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public nint hInstance;
            public nint hIcon;
            public nint hCursor;
            public nint hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public nint hIconSm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowHandle">A handle to the window.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageExtra1">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        /// <param name="messageExtra2">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        /// <returns>The result of the message processing, and depends on the message sent.</returns>
        public nint WindowProc(nint windowHandle, uint message, nint messageExtra1, nint messageExtra2)
        {
            var messageEnum = (WindowProcessMessage)message;
            var response = messageEnum switch
            {
                WindowProcessMessage.BEFORE_SIZE_OR_POSITION_CHANGE => nint.Zero,
                WindowProcessMessage.BEFORE_WINDOW_CREATED => 1,
                WindowProcessMessage.CALCULATE_SIZE_AND_POSITION => nint.Zero,
                WindowProcessMessage.ON_CREATE => nint.Zero,
                WindowProcessMessage.WINDOW_SHOWN_OR_HIDE => nint.Zero,
                WindowProcessMessage.BEFORE_POS_CHANGE => nint.Zero,
                WindowProcessMessage.BEFORE_ACTIVATE_DEACTIVATE => nint.Zero,
                WindowProcessMessage.NONCLIENT_ACTIVATE_DEACTIVEATE => 1,
                _ => nint.Zero,
            };
            Console.WriteLine($"{messageEnum}: {response}");
            return response;
        }

        public bool CreateWindow()
        {
            var windowClass = new WNDCLASSEX
            {
                cbSize = Marshal.SizeOf(typeof(WNDCLASSEX)),
                style = (int)(CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS), //Doubleclicks are active
                hbrBackground = (nint)COLOR_BACKGROUND + 1, //Black background, +1 is necessary
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = Marshal.GetHINSTANCE(GetType().Module), // alternative: Process.GetCurrentProcess().Handle
                hIcon = nint.Zero,
                hCursor = LoadCursor(nint.Zero, (int)IDC_CROSS),// Crosshair cursor
                lpszMenuName = null,
                lpszClassName = "myClass",
                lpfnWndProc = Marshal.GetFunctionPointerForDelegate(new WndProc(WindowProc)),
                hIconSm = nint.Zero
            };

            var registrationResult = RegisterClassEx(ref windowClass);

            if (registrationResult == 0)
            {
                var error = GetLastError();
                return false;
            }

            var windowHadle = CreateWindowEx(0, registrationResult, "Hello Win32", WS_OVERLAPPEDWINDOW | WS_VISIBLE, 0, 0, 300, 400, nint.Zero, nint.Zero, windowClass.hInstance, nint.Zero);

            if (windowHadle == 0)
            {
                var error = GetLastError();
                return false;
            }
            ShowWindow(windowHadle, 1);
            UpdateWindow(windowHadle);
            return true;
        }
    }
}
