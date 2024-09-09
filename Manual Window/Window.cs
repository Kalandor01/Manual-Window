using ManualWindow.NativeMethodEnums;
using ManualWindow.NativeMethodStructs;
using ManualWindow.WindowEventArgs;
using ManualWindow.WindowMessageEnums;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ManualWindow
{
    public class Window
    {
        #region Constants
        const uint CS_DBLCLKS = 8;
        const uint CS_VREDRAW = 1;
        const uint CS_HREDRAW = 2;
        const uint IDC_CROSS = 32515;
        const int WHEEL_DELTA = 120;
        #endregion

        #region Private fields
        private WindowHandle _windowHandle;
        private WndProc _windowProcDelegate;
        #endregion

        #region Event delegates
        /// <summary>
        /// Called when a window paint request is sent.
        /// </summary>
        /// <param name="sender">The window that called this event.</param>
        public delegate void PaintRequestEventHandler(Window sender, PaintRequestEventArgs args);

        /// <summary>
        /// Called when the left mouse button is down.
        /// </summary>
        /// <param name="sender">The window that called this event.</param>
        /// <param name="args">The arguments for this event.</param>
        public delegate void MouseLeftButtonDownEventHandler(Window sender, MouseLeftButtonDownEventArgs args);

        /// <summary>
        /// Called when the left mouse button is released.
        /// </summary>
        /// <param name="sender">The window that called this event.</param>
        /// <param name="args">The arguments for this event.</param>
        public delegate void MouseLeftButtonUpEventHandler(Window sender, MouseLeftButtonUpEventArgs args);

        /// <summary>
        /// Called when a key is being pressed.
        /// </summary>
        /// <param name="sender">The window that called this event.</param>
        /// <param name="args">The arguments for this event.</param>
        public delegate void KeyDownEventHandler(Window sender, KeyDownEventArgs args);
        #endregion

        #region Events
        /// <summary>
        /// Called when a window paint request is sent.<br/>
        /// </summary>
        public event PaintRequestEventHandler PaintRequest;

        /// <summary>
        /// Called when the left mouse button is down.
        /// </summary>
        public event MouseLeftButtonDownEventHandler MouseLeftButtonDown;

        /// <summary>
        /// Called when the left mouse button is released.
        /// </summary>
        public event MouseLeftButtonUpEventHandler MouseLeftButtonUp;

        /// <summary>
        /// Called when a key is being pressed.<br/>
        /// </summary>
        public event KeyDownEventHandler KeyDown;
        #endregion

        #region Constructors
        public Window()
        {
            RegisterWindow();
        }
        #endregion

        #region Public fnctions
        public static CursorPosWindowPart GetWindowPartFromPos(nint lparam)
        {
            var pos = Tools.PointFromLParam(lparam);
            return CursorPosWindowPart.CLIENT;
        }

        public static string GetKeystrokeMessageFlagsStr(nint param)
        {
            Tools.GetKeystrokeMessageFlags(
                param,
                out var repeatCount,
                out var scanCode,
                out var isExtendedKey,
                out var reserved,
                out var contextCode,
                out var isPreviouslyDown,
                out var transitionState
            );
            return $"repeat count: {repeatCount}, scan code: {scanCode}, extended key: {isExtendedKey}, reserved bits: {string.Join("", reserved.Select(b => b ? 1 : 0))}, context code: {(contextCode ? 1 : 0)}, previously down: {isPreviouslyDown}, transition state: {(transitionState ? 1 : 0)}";
        }

        /// <summary>
        /// Returns a string representation of the message.
        /// </summary>
        /// <param name="windowHandle">A handle to the window.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageExtra1">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        /// <param name="messageExtra2">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        /// <param name="sendTime">The timestamp the message was sent.</param>
        public static string WindowMessageToString(
            WindowHandle windowHandle,
            uint message,
            nint messageExtra1,
            nint messageExtra2,
            DateTime? sendTime = null
        )
        {
            string ContextMenuRequestExtraPart()
            {
                var pos = new Point((short)Tools.GetLowerHalf(messageExtra2), (short)Tools.GetUpperHalf(messageExtra2));
                return pos.x == -1 && pos.x == -1 ? "[NOT RIGHT CLICK TRIGGERED]" : pos.ToString();
            }

            IEnumerable<MouseVirtualKey> GetPressedVirtualKeys(int keysPressed)
            {
                return Enum.GetValues<MouseVirtualKey>().Where(key => (keysPressed & (int)key) != 0);
            }

            var sendDt = sendTime ?? DateTime.Now;
            var messageEnum = (WindowProcessMessage)message;
            var extraText = messageEnum switch
            {
                WindowProcessMessage.PAINT_WINDOW_REQUEST or
                WindowProcessMessage.SYNC_WINDOW_PAINT or
                WindowProcessMessage.MOUSE_LEAVE_NONCLIENT_AREA or
                WindowProcessMessage.ENTER_SIZING_OR_MOVING_MODE or
                WindowProcessMessage.EXIT_SIZING_OR_MOVING_MODE or
                WindowProcessMessage.SHOULD_TERMINATE or
                WindowProcessMessage.ON_BEING_DESTROYED or
                WindowProcessMessage.ON_NONCLIENT_BEING_DESTROYED
                    => null,
                WindowProcessMessage.BEFORE_SIZE_OR_POSITION_CHANGE => $"MINMAXINFO pointer: {messageExtra2}",
                WindowProcessMessage.BEFORE_WINDOW_CREATED => $"CREATESTRUCT pointer: {messageExtra2}",
                WindowProcessMessage.CALCULATE_SIZE_AND_POSITION
                    => $"{(messageExtra1 == 1 ? "NCCALCSIZE_PARAMS" : "RECT")} pointer: {messageExtra2}{(messageExtra1 == 0 ? "" : " The application should indicate which part of the client area contains valid information.")}",
                WindowProcessMessage.ON_CREATE => $"CREATESTRUCT pointer: {messageExtra2}",
                WindowProcessMessage.WINDOW_SHOWN_OR_HIDE
                    => $"window {(messageExtra1 == 1 ? "shown" : "hidden")}, reson: {(WindowShowHideReason)messageExtra2}",
                WindowProcessMessage.BEFORE_WINDOW_POS_CHANGE => $"the WINDOWPOS object: {new WindowPos(messageExtra2)}",
                WindowProcessMessage.BEFORE_ACTIVATE_DEACTIVATE
                    => $"window {(messageExtra1 == 1 ? "activated" : "deactivated")}, other window's owner thread ID: {messageExtra2}",
                WindowProcessMessage.NONCLIENT_ACTIVATE_DEACTIVEATE
                    => $"title bar/icon {(messageExtra1 == 1 ? "activated" : "deactivated")}, other window's owner thread ID: {messageExtra2}",
                WindowProcessMessage.ACTIVATE_DEACTIVEATE
                    => $"(de)activation method: {(WindowActivatedLowerHalf)Tools.GetLowerHalf(messageExtra1)}, window {(Tools.GetUpperHalf(messageExtra1) == 0 ? "not" : "")} minimized, pointer to {((WindowActivatedLowerHalf)Tools.GetLowerHalf(messageExtra1) == WindowActivatedLowerHalf.DEACTIVATED ? "" : "de")}activating window: {messageExtra2}",
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
                WindowProcessMessage.AFTER_KEYBOARD_FOCUS_GAINED => $"keyboard focus lost window handle: {messageExtra1}",
                WindowProcessMessage.FRAME_PAINT_NEEDED => $"window update region handle: {messageExtra1}",
                WindowProcessMessage.BACKGROUND_ERASE_NEEDED => $"device context handle: {messageExtra1}",
                WindowProcessMessage.WINDOW_POS_CHANGED => $"the WINDOWPOS(pointer: {messageExtra2}) object: {new WindowPos(messageExtra2)}",
                WindowProcessMessage.CLIPBOARD_SIZE_CHANGED => $"clipboard viewer window hadle: {messageExtra1}, RECT pointer: {messageExtra2}",
                WindowProcessMessage.WINDOW_SIZE_CHANGED
                    => $"resize type: {(WindowResizeType)messageExtra1}, new size: [width: {Tools.GetLowerHalf(messageExtra2)}, height: {Tools.GetUpperHalf(messageExtra2)}]",
                WindowProcessMessage.WINDOW_MOVED => $"new position: [x: {Tools.GetLowerHalf(messageExtra2)}, y: {Tools.GetUpperHalf(messageExtra2)}]",
                WindowProcessMessage.NONCLIENT_AREA_RENDERING_POLICY_CHANGED
                    => $"DWM rendering for the non-client area of the window: {(messageExtra1 == 1 ? "enabled" : "disabled")}",
                WindowProcessMessage.BEFORE_KEYBOARD_FOCUS_LOST => $"keyboard focus gained window handle: {messageExtra1}",
                WindowProcessMessage.SCREEN_POS_TO_WINDOW_PART => $"cursor pos: {Tools.PointFromLParam(messageExtra2)}",
                WindowProcessMessage.CURSOR_MOVE
                    => $"cursor window handle: {messageExtra1}, part hit: {(CursorPosWindowPart)Tools.GetLowerHalf(messageExtra2)}, event trigger: {(WindowProcessMessage)Tools.GetUpperHalf(messageExtra2)}",
                WindowProcessMessage.NONCLIENT_MOUSE_MOVE or
                WindowProcessMessage.NONCLIENT_LEFT_BUTTON_DOWN or
                WindowProcessMessage.NONCLIENT_LEFT_BUTTON_UP or
                WindowProcessMessage.NONCLIENT_LEFT_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.NONCLIENT_RIGHT_BUTTON_DOWN or
                WindowProcessMessage.NONCLIENT_RIGHT_BUTTON_UP or
                WindowProcessMessage.NONCLIENT_RIGHT_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.NONCLIENT_MIDDLE_BUTTON_DOWN or
                WindowProcessMessage.NONCLIENT_MIDDLE_BUTTON_UP or
                WindowProcessMessage.NONCLIENT_MIDDLE_BUTTON_DOUBLE_CLICK
                    => $"part hit: {(CursorPosWindowPart)messageExtra1}, cursor pos: {new Point(messageExtra2)}",
                WindowProcessMessage.MOUSE_MOVE or
                WindowProcessMessage.MOUSE_LEFT_BUTTON_DOWN or
                WindowProcessMessage.MOUSE_LEFT_BUTTON_UP or
                WindowProcessMessage.MOUSE_LEFT_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.MOUSE_RIGHT_BUTTON_DOWN or
                WindowProcessMessage.MOUSE_RIGHT_BUTTON_UP or
                WindowProcessMessage.MOUSE_RIGHT_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.MOUSE_MIDDLE_BUTTON_DOWN or
                WindowProcessMessage.MOUSE_MIDDLE_BUTTON_UP or
                WindowProcessMessage.MOUSE_MIDDLE_BUTTON_DOUBLE_CLICK
                    => $"buttons pressed: [{string.Join(", ", GetPressedVirtualKeys((int)messageExtra1))}], cursor pos: {Tools.PointFromLParam(messageExtra2)}",
                //=> "",
                WindowProcessMessage.MOUSE_KEY_PRESSED_IN_INACTIVE_WINDOW
                    => $"activated top level window handle {messageExtra1}, part hit: {(CursorPosWindowPart)Tools.GetLowerHalf(messageExtra2)}, mouse message ID: {(WindowProcessMessage)Tools.GetUpperHalf(messageExtra2)}",
                WindowProcessMessage.CONTEXT_MENU_REQUESTED
                    => $"menu requested window handle: {messageExtra1}, trigger location: {ContextMenuRequestExtraPart()}",
                WindowProcessMessage.MOUSE_WHEEL_SCROLL
                    => $"buttons pressed: [{string.Join(", ", GetPressedVirtualKeys(Tools.GetLowerHalf(messageExtra1)))}], distance rotated: {(short)Tools.GetUpperHalf(messageExtra1)}, cursor pos: {Tools.PointFromLParam(messageExtra2)}",
                WindowProcessMessage.X_BUTTON_DOWN or
                WindowProcessMessage.X_BUTTON_UP or
                WindowProcessMessage.X_BUTTON_DOUBLE_CLICK
                    => $"buttons pressed: [{string.Join(", ", GetPressedVirtualKeys(Tools.GetLowerHalf(messageExtra1)))}], X button {Tools.GetUpperHalf(messageExtra1)} triggered this event, cursor pos: {Tools.PointFromLParam(messageExtra2)}",
                WindowProcessMessage.WINDOW_MENU_COMMAND
                    => $"command: {(SystemCommand)messageExtra1}, cursor pos: {Tools.PointFromLParam(messageExtra2)}",
                WindowProcessMessage.MOUSE_CAPTURE_LOST => $"capture gainet window handle: {messageExtra2}",
                WindowProcessMessage.WINDOW_MOVING => $"current position RECT pointer: {messageExtra2}",
                WindowProcessMessage.WINDOW_SIZING
                    => $"sized edge: {(WindowSizingEdge)messageExtra1}, current position RECT pointer: {messageExtra2}",
                WindowProcessMessage.KEY_DOWN
                    => $"virtual key code: {(VirtualKeyCode)messageExtra1}, flags: {GetKeystrokeMessageFlagsStr(messageExtra2)}",
                WindowProcessMessage.KEY_UP
                    => $"virtual key code: {(VirtualKeyCode)messageExtra1}, flags: {GetKeystrokeMessageFlagsStr(messageExtra2)}",
                _ => "[UNREGISTERED MESSAGE]",
            };

            return $"[{sendDt}] {messageEnum}{(Enum.IsDefined(messageEnum) ? "" : " [UNKNOWN MESSAGE]")}{(extraText is null ? "" : $" -> {extraText}")}";
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ThrowLastSystemError()
        {
            var errorCode = Marshal.GetLastWin32Error();
            if (errorCode == 0)
            {
                return;
            }
            var error = new Win32Exception(errorCode);
            var message =  $"ERROR({errorCode}) {error.Message}";
            Console.WriteLine(message);
            throw error;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Processes the window message.
        /// </summary>
        /// <param name="windowHandle">A handle to the window.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageExtra1">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        /// <param name="messageExtra2">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        /// <returns>The result of the message processing, and depends on the message sent.</returns>
        public nint ProcessMessage(WindowHandle windowHandle, WindowProcessMessage message, nint messageExtra1, nint messageExtra2)
        {
            switch (message)
            {
                case WindowProcessMessage.PAINT_WINDOW_REQUEST:
                    var hdc = NativeMethods.BeginPaint(windowHandle, out var paint);
                    if (hdc == nint.Zero)
                    {
                        ThrowLastSystemError();
                    }

                    PaintRequest(this, new PaintRequestEventArgs(hdc, paint));

                    var suc = NativeMethods.EndPaint(windowHandle, paint);
                    break;
                case WindowProcessMessage.KEY_DOWN:
                    KeyDown(this, new KeyDownEventArgs(messageExtra1, messageExtra2));
                    break;
                case WindowProcessMessage.MOUSE_LEFT_BUTTON_DOWN:
                    MouseLeftButtonDown(this, new MouseLeftButtonDownEventArgs(messageExtra1, messageExtra2));
                    break;
                case WindowProcessMessage.MOUSE_LEFT_BUTTON_UP:
                    MouseLeftButtonUp(this, new MouseLeftButtonUpEventArgs(messageExtra1, messageExtra2));
                    break;
            }

            return message switch
            {
                WindowProcessMessage.ON_CREATE or
                WindowProcessMessage.WINDOW_SHOWN_OR_HIDE or
                WindowProcessMessage.BEFORE_WINDOW_POS_CHANGE or
                WindowProcessMessage.BEFORE_ACTIVATE_DEACTIVATE or
                WindowProcessMessage.ACTIVATE_DEACTIVEATE or
                WindowProcessMessage.AFTER_KEYBOARD_FOCUS_GAINED or
                WindowProcessMessage.FRAME_PAINT_NEEDED or
                WindowProcessMessage.WINDOW_POS_CHANGED or
                WindowProcessMessage.CLIPBOARD_SIZE_CHANGED or
                WindowProcessMessage.WINDOW_SIZE_CHANGED or
                WindowProcessMessage.WINDOW_MOVED or
                WindowProcessMessage.PAINT_WINDOW_REQUEST or
                WindowProcessMessage.SYNC_WINDOW_PAINT or
                WindowProcessMessage.NONCLIENT_AREA_RENDERING_POLICY_CHANGED or
                WindowProcessMessage.BEFORE_KEYBOARD_FOCUS_LOST or
                WindowProcessMessage.NONCLIENT_MOUSE_MOVE or
                WindowProcessMessage.NONCLIENT_LEFT_BUTTON_DOWN or
                WindowProcessMessage.NONCLIENT_LEFT_BUTTON_UP or
                WindowProcessMessage.NONCLIENT_LEFT_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.NONCLIENT_RIGHT_BUTTON_DOWN or
                WindowProcessMessage.NONCLIENT_RIGHT_BUTTON_UP or
                WindowProcessMessage.NONCLIENT_RIGHT_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.NONCLIENT_MIDDLE_BUTTON_DOWN or
                WindowProcessMessage.NONCLIENT_MIDDLE_BUTTON_UP or
                WindowProcessMessage.NONCLIENT_MIDDLE_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.MOUSE_LEAVE_NONCLIENT_AREA or
                WindowProcessMessage.MOUSE_MOVE or
                WindowProcessMessage.MOUSE_LEFT_BUTTON_DOWN or
                WindowProcessMessage.MOUSE_LEFT_BUTTON_UP or
                WindowProcessMessage.MOUSE_LEFT_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.MOUSE_RIGHT_BUTTON_DOWN or
                WindowProcessMessage.MOUSE_RIGHT_BUTTON_UP or
                WindowProcessMessage.MOUSE_RIGHT_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.MOUSE_MIDDLE_BUTTON_DOWN or
                WindowProcessMessage.MOUSE_MIDDLE_BUTTON_UP or
                WindowProcessMessage.MOUSE_MIDDLE_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.CONTEXT_MENU_REQUESTED or
                WindowProcessMessage.MOUSE_WHEEL_SCROLL or
                WindowProcessMessage.WINDOW_MENU_COMMAND or
                WindowProcessMessage.MOUSE_CAPTURE_LOST or
                WindowProcessMessage.ENTER_SIZING_OR_MOVING_MODE or
                WindowProcessMessage.EXIT_SIZING_OR_MOVING_MODE or
                WindowProcessMessage.SHOULD_TERMINATE or
                WindowProcessMessage.ON_BEING_DESTROYED or
                WindowProcessMessage.ON_NONCLIENT_BEING_DESTROYED or
                WindowProcessMessage.KEY_DOWN or
                WindowProcessMessage.KEY_UP
                    => nint.Zero,
                WindowProcessMessage.X_BUTTON_DOWN or
                WindowProcessMessage.X_BUTTON_UP or
                WindowProcessMessage.X_BUTTON_DOUBLE_CLICK or
                WindowProcessMessage.WINDOW_MOVING or
                WindowProcessMessage.WINDOW_SIZING
                    => 1,
                WindowProcessMessage.BEFORE_SIZE_OR_POSITION_CHANGE => nint.Zero,
                WindowProcessMessage.BEFORE_WINDOW_CREATED => 1,
                WindowProcessMessage.CALCULATE_SIZE_AND_POSITION => nint.Zero,
                WindowProcessMessage.NONCLIENT_ACTIVATE_DEACTIVEATE => 1,
                WindowProcessMessage.GET_ICON => nint.Zero,
                WindowProcessMessage.IME_ACTIVATE_DEACTIVATE => nint.Zero,
                WindowProcessMessage.IME_NOTIFY => nint.Zero,
                WindowProcessMessage.BACKGROUND_ERASE_NEEDED => nint.Zero,
                WindowProcessMessage.SCREEN_POS_TO_WINDOW_PART => (int)GetWindowPartFromPos(messageExtra2),
                WindowProcessMessage.CURSOR_MOVE => nint.Zero,
                WindowProcessMessage.MOUSE_KEY_PRESSED_IN_INACTIVE_WINDOW => (int)InactiveWindowMouseActionReturnValue.ACTIVATE,
                _ => nint.Zero,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowHandle">A handle to the window.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageExtra1">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        /// <param name="messageExtra2">Additional message information. The contents of this depends on <paramref name="message"/>.</param>
        /// <returns>The result of the message processing, and depends on the message sent.</returns>
        public nint WindowProc(WindowHandle windowHandle, uint message, nint messageExtra1, nint messageExtra2)
        {
            var messageEnum = (WindowProcessMessage)message;
            var knownMessage = Enum.IsDefined(messageEnum);
            var response = nint.Zero;
            if (knownMessage)
            {
                response = ProcessMessage(windowHandle, messageEnum, messageExtra1, messageExtra2);
            }

            var defResponse = NativeMethods.DefWindowProc(windowHandle, message, messageExtra1, messageExtra2);

            if (knownMessage)
            {
                Console.WriteLine(WindowMessageToString(windowHandle, message, messageExtra1, messageExtra2) + $"\t-> {response}{(response != defResponse ? $"(def: {defResponse})" : "")}");
            }
            else
            {
                Console.WriteLine($"UNKNOWN MESSAGE: {message}\t-> (def: {defResponse})");
            }
            response = defResponse;

            return response;
        }

        public bool RegisterWindow()
        {
            _windowProcDelegate = new WndProc(WindowProc);
            var windowClass = new WindowClass
            {
                cbSize = (uint)Marshal.SizeOf(typeof(WindowClass)),
                style = WindowClassStyle.HREDRAW | WindowClassStyle.VREDRAW | WindowClassStyle.DBLCLKS,
                lpfnWndProc = _windowProcDelegate,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = Marshal.GetHINSTANCE(GetType().Module), // alternative: Process.GetCurrentProcess().Handle
                hIcon = IconHandle.Null,
                hCursor = NativeMethods.LoadCursor(CursorImage.CROSS),
                hbrBackground = NativeMethods.GetSysColorBrush(SysColorIndex.COLOR_BACKGROUND + 1),
                lpszMenuName = null,
                lpszClassName = "myClass",
                hIconSm = IconHandle.Null,
            };

            var registrationResult = NativeMethods.RegisterClassEx(ref windowClass);

            if (registrationResult == 0)
            {
                ThrowLastSystemError();
                return false;
            }

            var windowHandle = NativeMethods.CreateWindowEx(
                0,
                registrationResult,
                "Hello Win32",
                WindowStyle.OVERLAPPEDWINDOW | WindowStyle.VISIBLE,
                0,
                0,
                300,
                400,
                new WindowHandle(nint.Zero),
                nint.Zero,
                windowClass.hInstance,
                nint.Zero
            );

            if (windowHandle == WindowHandle.Null)
            {
                ThrowLastSystemError();
                return false;
            }

            _windowHandle = windowHandle;
            return true;
        }

        public bool ShowWindow()
        {
            NativeMethods.ShowWindow(_windowHandle, ShowWindowCommand.SHOWNORMAL);

            sbyte res = 0;
            do
            {
                res = NativeMethods.GetMessage(out var msg, _windowHandle, 0, 0);
                if (res == 0)
                {
                    continue;
                }

                // invalid window handle on close
                if (res == -1)
                {
                    ThrowLastSystemError();
                    return false;
                }

                //var r = NativeMethods.TranslateMessage(msg);
                NativeMethods.DispatchMessage(msg);
            }
            while (res != 0);
            return true;
        }

        public bool RepaintWindow(bool eraseBackground)
        {
            return NativeMethods.InvalidateRect(_windowHandle, eraseBackground);
        }

        public bool RepaintWindowArea(Rectangle repaintArea, bool eraseBackground)
        {
            unsafe
            {
                return NativeMethods.InvalidateRect(_windowHandle, &repaintArea, eraseBackground);
            }
        }
        #endregion
    }
}
