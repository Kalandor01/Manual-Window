using System.Runtime.InteropServices;

namespace ManualWindow
{
    internal class Window
    {
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        [DllImport("user32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(nint hWnd, string lpText, string lpCaption, uint uType);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool UpdateWindow(nint hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(nint hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool DestroyWindow(nint hWnd);

        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode, SetLastError = true)]
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
               nint lpParam
            );

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern ushort RegisterClassEx([In] ref WNDCLASSEX lpWndClass);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern nint DefWindowProc(nint hWnd, uint uMsg, nint wParam, nint lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern nint LoadCursor(nint hInstance, int lpCursorName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern nint BeginPaint(nint hWnd, [In] ref PAINTSTRUCT lpPaint);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool EndPaint(nint hWnd, in PAINTSTRUCT lpPaint);

        //[DllImport("user32.dll")]
        //static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
        //   uint wMsgFilterMax);

        //[DllImport("user32.dll")]
        //static extern bool TranslateMessage([In] ref MSG lpMsg);

        //[DllImport("user32.dll")]
        //static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        delegate nint WndProc(nint hWnd, uint msg, nint wParam, nint lParam);

        const uint WS_OVERLAPPEDWINDOW = 0b1100_1111_0000_0000_0000_0000;
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

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct PAINTSTRUCT
        {
            public nint hdc;
            public bool fErase;
            public nint rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        /// <summary>
        /// Returns a string representation of the message.
        /// </summary>
        /// <param name="windowHandle">A handle to the window.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageExtra1">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        /// <param name="messageExtra2">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        public static string WindowMessageToString(nint windowHandle, uint message, nint messageExtra1, nint messageExtra2)
        {
            string ActivateDeactivateDisplay()
            {
                var activatedReason = (WindowActivatedLowerHalf)(ushort)messageExtra1;
                var upper = messageExtra1 >> 16;
                return $"(de)activation method: {activatedReason}, window {(upper == 0 ? "not" : "")} minimized, pointer to {(activatedReason == WindowActivatedLowerHalf.DEACTIVATED ? "" : "de")}activating window: {messageExtra2}";
            }

            string SizeChangedDisplay()
            {
                var resizeType = (WindowResizeType)messageExtra1;
                var lower = (ushort)messageExtra2;
                var upper = messageExtra2 >> 16;
                return $"resize type: {resizeType}, new size: [width: {lower}, height: {upper}]";
            }

            string MovedDisplay()
            {
                var lower = (ushort)messageExtra2;
                var upper = messageExtra2 >> 16;
                return $"new position: [x: {lower}, y: {upper}]";
            }

            var messageEnum = (WindowProcessMessage)message;
            var extraText = messageEnum switch
            {
                WindowProcessMessage.BEFORE_SIZE_OR_POSITION_CHANGE => $"MINMAXINFO pointer: {messageExtra2}",
                WindowProcessMessage.BEFORE_WINDOW_CREATED => $"CREATESTRUCT pointer: {messageExtra2}",
                WindowProcessMessage.CALCULATE_SIZE_AND_POSITION => $"{(messageExtra1 == 1 ? "NCCALCSIZE_PARAMS" : "RECT")} pointer: {messageExtra2}{(messageExtra1 == 0 ? "" : " The application should indicate which part of the client area contains valid information.")}",
                WindowProcessMessage.ON_CREATE => $"CREATESTRUCT pointer: {messageExtra2}",
                WindowProcessMessage.WINDOW_SHOWN_OR_HIDE => $"window {(messageExtra1 == 1 ? "shown" : "hidden")}, reson: {(WindowShowHideReason)messageExtra2}",
                WindowProcessMessage.BEFORE_WINDOW_POS_CHANGE => $"WINDOWPOS pointer: {messageExtra2}",
                WindowProcessMessage.BEFORE_ACTIVATE_DEACTIVATE => $"window {(messageExtra1 == 1 ? "activated" : "deactivated")}, other window's owner thread ID: {messageExtra2}",
                WindowProcessMessage.NONCLIENT_ACTIVATE_DEACTIVEATE => $"title bar/icon {(messageExtra1 == 1 ? "activated" : "deactivated")}, other window's owner thread ID: {messageExtra2}",
                WindowProcessMessage.ACTIVATE_DEACTIVEATE => ActivateDeactivateDisplay(),
                WindowProcessMessage.GET_ICON => $"icon type: {(WindowIconType)messageExtra1}, icon DPI: {messageExtra2}",
                WindowProcessMessage.IME_ACTIVATE_DEACTIVATE => $"window {(messageExtra1 == 1 ? "" : "in")}active, display options: [{
                    string.Join(", ",
                        Enum.GetValues<WindowActivateDeactivateDisplayOptionsPart>()
                        .Where(dispO =>
                            dispO != WindowActivateDeactivateDisplayOptionsPart.SHOW_UI_ALL_CANDIDATE_WINDOW &&
                            dispO != WindowActivateDeactivateDisplayOptionsPart.SHOW_UI_ALL &&
                            ((uint)dispO & messageExtra1) != 0)
                        )
                    }]",
                WindowProcessMessage.IME_NOTIFY => $"command type: {(IMENotifyCommand)messageExtra1}, argument: {messageExtra2}",
                WindowProcessMessage.GAINED_KEYBOARD_FOCUS => $"keyboard focus lost window handle: {messageExtra1}",
                WindowProcessMessage.FRAME_PAINT_NEEDED => $"window update region handle: {messageExtra1}",
                WindowProcessMessage.BACKGROUND_ERASE_NEEDED => $"device context handle: {messageExtra1}",
                WindowProcessMessage.WINDOW_POS_CHANGED => $"WINDOWPOS pointer: {messageExtra2}",
                WindowProcessMessage.CLIPBOARD_SIZE_CHANGED => $"clipboard viewer window hadle: {messageExtra1}, RECT pointer: {messageExtra2}",
                WindowProcessMessage.WINDOW_SIZE_CHANGED => SizeChangedDisplay(),
                WindowProcessMessage.WINDOW_MOVED => MovedDisplay(),
                WindowProcessMessage.PAINT_WINDOW_REQUEST => null,
                WindowProcessMessage.SYNC_WINDOW_PAINT => null,
                _ => "[UNREGISTERED MESSAGE]",
            };

            return $"{messageEnum}{(Enum.IsDefined(messageEnum) ? "" : " [UNKNOWN MESSAGE]")}{(extraText is null ? "" : $" -> {extraText}")}";
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

            switch (messageEnum)
            {
                case WindowProcessMessage.PAINT_WINDOW_REQUEST:
                    var ps = new PAINTSTRUCT();
                    var res = BeginPaint(windowHandle, ref ps);
                    var suc = EndPaint(windowHandle, ps);
                    break;
            }

            var response = messageEnum switch
            {
                WindowProcessMessage.BEFORE_SIZE_OR_POSITION_CHANGE => nint.Zero,
                WindowProcessMessage.BEFORE_WINDOW_CREATED => 1,
                WindowProcessMessage.CALCULATE_SIZE_AND_POSITION => nint.Zero,
                WindowProcessMessage.ON_CREATE => nint.Zero,
                WindowProcessMessage.WINDOW_SHOWN_OR_HIDE => nint.Zero,
                WindowProcessMessage.BEFORE_WINDOW_POS_CHANGE => nint.Zero,
                WindowProcessMessage.BEFORE_ACTIVATE_DEACTIVATE => nint.Zero,
                WindowProcessMessage.NONCLIENT_ACTIVATE_DEACTIVEATE => 1,
                WindowProcessMessage.ACTIVATE_DEACTIVEATE => nint.Zero,
                WindowProcessMessage.GET_ICON => nint.Zero,
                WindowProcessMessage.IME_ACTIVATE_DEACTIVATE => nint.Zero,
                WindowProcessMessage.IME_NOTIFY => nint.Zero,
                WindowProcessMessage.GAINED_KEYBOARD_FOCUS => nint.Zero,
                WindowProcessMessage.FRAME_PAINT_NEEDED => nint.Zero,
                WindowProcessMessage.BACKGROUND_ERASE_NEEDED => nint.Zero,
                WindowProcessMessage.WINDOW_POS_CHANGED => nint.Zero,
                WindowProcessMessage.CLIPBOARD_SIZE_CHANGED => nint.Zero,
                WindowProcessMessage.WINDOW_SIZE_CHANGED => nint.Zero,
                WindowProcessMessage.WINDOW_MOVED => nint.Zero,
                WindowProcessMessage.PAINT_WINDOW_REQUEST => nint.Zero,
                WindowProcessMessage.SYNC_WINDOW_PAINT => nint.Zero,
                _ => nint.Zero,
            };

            var defResponse = DefWindowProc(windowHandle, message, messageExtra1, messageExtra2);
            response = defResponse;
            Console.WriteLine(WindowMessageToString(windowHandle, message, messageExtra1, messageExtra2) + $"\t-> {response}");
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
            while (true)
            {
                var res = UpdateWindow(windowHadle);
                //Thread.Sleep(100);
            }
            return true;
        }
    }
}
