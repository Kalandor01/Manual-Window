using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;

namespace ManualWindow
{
    internal class Window
    {
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
                    var hdc = NativeMethods.BeginPaint(windowHandle, out var ps);
                    if (hdc == IntPtr.Zero)
                    {
                        var error = NativeMethods.GetLastError();
                    }
                    RECT rect;
                    unsafe
                    {
                        rect = *(RECT*)&ps.rcPaint;
                    }
                    var brush = NativeMethods.GetSysColorBrush(SysColorIndex.COLOR_WINDOW);
                    var res = NativeMethods.FillRect(new HDC(hdc), rect, brush);
                    var suc = NativeMethods.EndPaint(windowHandle, ps);
                    //PInvoke.UpdateWindow();
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

            var defResponse = NativeMethods.DefWindowProc(windowHandle, message, messageExtra1, messageExtra2);
            response = defResponse;
            Console.WriteLine(WindowMessageToString(windowHandle, message, messageExtra1, messageExtra2) + $"\t-> {response}");
            return response;
        }

        public bool CreateWindow()
        {
            var windowClass = new NativeMethods.WNDCLASSEX
            {
                cbSize = Marshal.SizeOf(typeof(NativeMethods.WNDCLASSEX)),
                style = (int)(CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS), //Doubleclicks are active
                hbrBackground = (nint)COLOR_BACKGROUND + 1, //Black background, +1 is necessary
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = Marshal.GetHINSTANCE(GetType().Module), // alternative: Process.GetCurrentProcess().Handle
                hIcon = nint.Zero,
                hCursor = NativeMethods.LoadCursor(nint.Zero, (int)IDC_CROSS),// Crosshair cursor
                lpszMenuName = null,
                lpszClassName = "myClass",
                lpfnWndProc = Marshal.GetFunctionPointerForDelegate(new WndProc(WindowProc)),
                hIconSm = nint.Zero
            };

            var registrationResult = NativeMethods.RegisterClassEx(ref windowClass);

            if (registrationResult == 0)
            {
                var error = NativeMethods.GetLastError();
                return false;
            }

            var windowHadle = NativeMethods.CreateWindowEx(0, registrationResult, "Hello Win32", WS_OVERLAPPEDWINDOW | WS_VISIBLE, 0, 0, 300, 400, nint.Zero, nint.Zero, windowClass.hInstance, nint.Zero);

            if (windowHadle == 0)
            {
                var error = NativeMethods.GetLastError();
                return false;
            }
            NativeMethods.ShowWindow(windowHadle, 1);
            while (true)
            {
                var res = NativeMethods.UpdateWindow(windowHadle);
                //Thread.Sleep(100);
            }
            return true;
        }
    }
}
