using ManualWindow.NativeMethodEnums;
using ManualWindow.NativeMethodStructs;
using ManualWindow.WindowMessageEnums;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.UI.WindowsAndMessaging;

namespace ManualWindow
{
    internal class NativeMethods
    {
        #region NativeMethods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern uint GetLastError();

        /// <summary>Displays a modal dialog box that contains a system icon, a set of buttons, and a brief application-specific message, such as status or error information. The message box returns an integer value that indicates which button the user clicked. (MessageBoxW)</summary>
		/// <param name="windowHandle">
		/// <para>Type: <b>HWND</b> A handle to the owner window of the message box to be created. If this parameter is <b>NULL</b>, the message box has no owner window.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-messageboxw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="text">
		/// <para>Type: <b>LPCTSTR</b> The message to be displayed. If the string consists of more than one line, you can separate the lines using a carriage return and/or linefeed character between each line.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-messageboxw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="caption">
		/// <para>Type: <b>LPCTSTR</b> The dialog box title. If this parameter is <b>NULL</b>, the default title is <b>Error</b>.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-messageboxw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b>UINT</b> The contents and behavior of the dialog box. This parameter can be a combination of flags from the following groups of flags.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-messageboxw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="languageId">
		/// The language for the text displayed in the message box button(s). Specifying a value of zero (0) indicates to display the button text in the default system language. If this parameter is MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL), the current language associated with the calling thread is used.
		/// </param>
		/// <returns>
		/// <para>Type: <b>int</b> If a message box has a <b>Cancel</b> button, the function returns the <b>IDCANCEL</b> value if either the ESC key is pressed or the <b>Cancel</b> button is selected. If the message box has no <b>Cancel</b> button, pressing ESC will no effect - unless an MB_OK button is present. If an MB_OK button is displayed and the user presses ESC, the return value will be <b>IDOK</b>. If the function fails, the return value is zero. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>. If the function succeeds, the return value is one of the following menu-item values. </para>
		/// <para>This doc was truncated.</para>
		/// </returns>
		/// <remarks>
		/// <para>The following system icons can be used in a message box by setting the <i>uType</i> parameter to the corresponding flag value. </para>
		/// <para>This doc was truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-messageboxw#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", EntryPoint = "MessageBoxExW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern MessageBoxResult MessageBox(WindowHandle windowHandle, string text, string caption, MessageBoxStyle type, ushort languageId = 0);

		/// <inheritdoc cref="MessageBox(WindowHandle, string, string, MessageBoxStyle, ushort)"/>
		internal static MessageBoxResult MessageBox(string text, string caption, MessageBoxStyle type, ushort languageId = 0)
		{
			return MessageBox(new WindowHandle(0), text, caption, type, languageId);
		}

        /// <summary>The UpdateWindow function updates the client area of the specified window by sending a WM_PAINT message to the window if the window's update region is not empty.</summary>
		/// <param name="hWnd">Handle to the window to be updated.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-updatewindow">Learn more about this API from docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool UpdateWindow(WindowHandle hWnd);

        /// <summary>Sets the specified window's show state.</summary>
		/// <param name="hWnd">
		/// <para>Type: <b>HWND</b> A handle to the window.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-showwindow#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="nCmdShow">Type: <b>int</b></param>
		/// <returns>
		/// <para>Type: <b>BOOL</b> If the window was previously visible, the return value is nonzero. If the window was previously hidden, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>To perform certain special effects when showing or hiding a window, use <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-animatewindow">AnimateWindow</a>. The first time an application calls <b>ShowWindow</b>, it should use the <a href="https://docs.microsoft.com/windows/desktop/api/winbase/nf-winbase-winmain">WinMain</a> function's <i>nCmdShow</i> parameter as its <i>nCmdShow</i> parameter. Subsequent calls to <b>ShowWindow</b> must use one of the values in the given list, instead of the one specified by the <b>WinMain</b> function's <i>nCmdShow</i> parameter. As noted in the discussion of the <i>nCmdShow</i> parameter, the <i>nCmdShow</i> value is ignored in the first call to <b>ShowWindow</b> if the program that launched the application specifies startup information in the  structure. In this case, <b>ShowWindow</b> uses the information specified in the <a href="https://docs.microsoft.com/windows/desktop/api/processthreadsapi/ns-processthreadsapi-startupinfoa">STARTUPINFO</a> structure to show the window. On subsequent calls, the application must call <b>ShowWindow</b> with <i>nCmdShow</i> set to <b>SW_SHOWDEFAULT</b> to use the startup information provided by the program that launched the application. This behavior is designed for the following situations: </para>
		/// <para>This doc was truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-showwindow#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ShowWindow(WindowHandle hWnd, ShowWindowCommand nCmdShow);

        /// <summary>Destroys the specified window.</summary>
		/// <param name="hWnd">
		/// <para>Type: <b>HWND</b> A handle to the window to be destroyed.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-destroywindow#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b> If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>.</para>
		/// </returns>
		/// <remarks>
		/// <para>A thread cannot use <b>DestroyWindow</b> to destroy a window created by a different thread. If the window being destroyed is a child window that does not have the <b>WS_EX_NOPARENTNOTIFY</b> style, a <a href="https://docs.microsoft.com/windows/win32/inputmsg/wm-parentnotify">WM_PARENTNOTIFY</a> message is sent to the parent.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-destroywindow#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool DestroyWindow(WindowHandle hWnd);

        /// <summary>Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the CreateWindow function. (Unicode)</summary>
		/// <param name="dwExStyle">
		/// <para>Type: <b>DWORD</b> The extended window style of the window being created. For a list of possible values, see  <a href="https://docs.microsoft.com/windows/desktop/winmsg/extended-window-styles">Extended Window Styles</a>.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="lpWindowName">
		/// <para>Type: <b>LPCTSTR</b> The window name. If the window style specifies a title bar, the window title pointed to by <i>lpWindowName</i> is displayed in the title bar. When using <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-createwindowa">CreateWindow</a> to create controls, such as buttons, check boxes, and static controls, use <i>lpWindowName</i> to specify the text of the control. When creating a static control with the <b>SS_ICON</b> style, use <i>lpWindowName</i> to specify the icon name or identifier. To specify an identifier, use the syntax "#<i>num</i>".</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="dwStyle">
		/// <para>Type: <b>DWORD</b> The style of the window being created. This parameter can be a combination of the <a href="https://docs.microsoft.com/windows/desktop/winmsg/window-styles">window style values</a>, plus the control styles indicated in the Remarks section.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="x">
		/// <para>Type: <b>int</b> The initial horizontal position of the window. For an overlapped or pop-up window, the <i>x</i> parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates. For a child window, <i>x</i> is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent window's client area. If <i>x</i> is set to <b>CW_USEDEFAULT</b>, the system selects the default position for the window's upper-left corner and ignores the <i>y</i> parameter. <b>CW_USEDEFAULT</b> is valid only for overlapped windows; if it is specified for a pop-up or child window, the <i>x</i> and <i>y</i> parameters are set to zero.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <b>int</b> The initial vertical position of the window. For an overlapped or pop-up window, the <i>y</i> parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates. For a child window, <i>y</i> is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left corner of the parent window's client area. For a list box <i>y</i> is the initial y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's client area.</para>
		/// <para>If an overlapped window is created with the <b>WS_VISIBLE</b> style bit set and the <i>x</i> parameter is set to <b>CW_USEDEFAULT</b>, then the <i>y</i> parameter determines how the window is shown. If the <i>y</i> parameter is <b>CW_USEDEFAULT</b>, then the window manager calls <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-showwindow">ShowWindow</a> with the <b>SW_SHOW</b> flag after the window has been created. If the <i>y</i> parameter is some other value, then the window manager calls <b>ShowWindow</b> with that value as the <i>nCmdShow</i> parameter.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="nWidth">
		/// <para>Type: <b>int</b> The width, in device units, of the window. For overlapped windows, <i>nWidth</i> is the window's width, in screen coordinates, or <b>CW_USEDEFAULT</b>. If <i>nWidth</i> is <b>CW_USEDEFAULT</b>, the system selects a default width and height for the window; the default width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial y-coordinate to the top of the icon area. <b>CW_USEDEFAULT</b> is valid only for overlapped windows; if <b>CW_USEDEFAULT</b> is specified for a pop-up or child window, the <i>nWidth</i> and <i>nHeight</i> parameter are set to zero.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="nHeight">
		/// <para>Type: <b>int</b> The height, in device units, of the window. For overlapped windows, <i>nHeight</i> is the window's height, in screen coordinates. If the <i>nWidth</i> parameter is set to <b>CW_USEDEFAULT</b>, the system ignores <i>nHeight</i>.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="hWndParent">
		/// <para>Type: <b>HWND</b> A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid window handle. This parameter is optional for pop-up windows. To create a <a href="https://docs.microsoft.com/windows/desktop/winmsg/window-features">message-only window</a>, supply <b>HWND_MESSAGE</b> or a handle to an existing message-only window.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="hMenu">
		/// <para>Type: <b>HMENU</b> A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, <i>hMenu</i> identifies the menu to be used with the window; it can be <b>NULL</b> if the class menu is to be used. For a child window, <i>hMenu</i> specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The application determines the child-window identifier; it must be unique for all child windows with the same parent window.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="hInstance">
		/// <para>Type: <b>HINSTANCE</b> A handle to the instance of the module to be associated with the window.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="lpParam">
		/// <para>Type: <b>LPVOID</b> Pointer to a value to be passed to the window through the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-createstructa">CREATESTRUCT</a> structure (<b>lpCreateParams</b> member) pointed to by the <i>lParam</i> param of the <b>WM_CREATE</b> message.  This message is sent to the created window by this function before it returns. If an application calls <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-createwindowa">CreateWindow</a> to create a MDI client window, <i>lpParam</i> should point to a <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-clientcreatestruct">CLIENTCREATESTRUCT</a> structure. If an MDI client window calls <b>CreateWindow</b> to create an MDI child window, <i>lpParam</i> should point to a <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-mdicreatestructa">MDICREATESTRUCT</a> structure. <i>lpParam</i> may be <b>NULL</b> if no additional data is needed.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HWND</b> If the function succeeds, the return value is a handle to the new window. If the function fails, the return value is <b>NULL</b>. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>. This function typically fails for one of the following reasons: </para>
		/// <para>This doc was truncated.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <b>CreateWindowEx</b> function sends <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-nccreate">WM_NCCREATE</a>, <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-nccalcsize">WM_NCCALCSIZE</a>, and <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-create">WM_CREATE</a> messages to the window being created. If the created window is a child window, its default position is at the bottom of the Z-order. If the created window is a top-level window, its default position is at the top of the Z-order (but beneath all topmost windows unless the created window is itself topmost). For information on controlling whether the Taskbar displays a button for the created window, see <a href="https://docs.microsoft.com/windows/desktop/shell/taskbar">Managing Taskbar Buttons</a>. For information on removing a window, see the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-destroywindow">DestroyWindow</a> function. The following predefined control classes can be specified in the <i>lpClassName</i> parameter. Note the corresponding control styles you can use in the <i>dwStyle</i> parameter. </para>
		/// <para>This doc was truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexw#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", EntryPoint = "CreateWindowExW", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern WindowHandle CreateWindowEx(
               WindowExStyle dwExStyle,
               ushort regResult,
			   string? lpWindowName,
               WindowStyle dwStyle,
               int x,
               int y,
               int nWidth,
               int nHeight,
               WindowHandle hWndParent,
               nint hMenu,
               nint hInstance,
               nint lpParam
            );

        /// <summary>Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function. (RegisterClassExW)</summary>
        /// <returns>
        /// <para>Type: <b>ATOM</b> If the function succeeds, the return value is a class atom that uniquely identifies the class being registered. This atom can only be used by the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-createwindowa">CreateWindow</a>, <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-createwindowexa">CreateWindowEx</a>, <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getclassinfoa">GetClassInfo</a>, <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getclassinfoexa">GetClassInfoEx</a>, <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-findwindowa">FindWindow</a>, <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-findwindowexa">FindWindowEx</a>, and <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-unregisterclassa">UnregisterClass</a> functions and the <b>IActiveIMMap::FilterClientWindows</b> method. If the function fails, the return value is zero. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>.</para>
        /// </returns>
        /// <remarks>
        /// <para>If you register the window class by using <b>RegisterClassExA</b>, the application tells the system that the windows of the created class expect messages with text or character parameters to use the ANSI character set; if you register it by using <b>RegisterClassExW</b>, the application requests that the system pass text parameters of messages as Unicode. The <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-iswindowunicode">IsWindowUnicode</a> function enables applications to query the nature of each window. For more information on ANSI and Unicode functions, see <a href="https://docs.microsoft.com/windows/desktop/Intl/conventions-for-function-prototypes">Conventions for Function Prototypes</a>. All window classes that an application registers are unregistered when it terminates. No window classes registered by a DLL are unregistered when the DLL is unloaded. A DLL must explicitly unregister its classes when it is unloaded.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-registerclassexw#">Read more on docs.microsoft.com</see>.</para>
        /// </remarks>
        [DllImport("user32.dll", EntryPoint = "RegisterClassExW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern ushort RegisterClassEx([In] ref WindowClass lpWndClass);

        /// <summary>Calls the default window procedure to provide default processing for any window messages that an application does not process. (Unicode)</summary>
		/// <param name="hWnd">
		/// <para>Type: <b>HWND</b> A handle to the window procedure that received the message.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-defwindowprocw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="Msg">
		/// <para>Type: <b>UINT</b> The message.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-defwindowprocw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <b>WPARAM</b> Additional message information. The content of this parameter depends on the value of the <i>Msg</i> parameter.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-defwindowprocw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <b>LPARAM</b> Additional message information. The content of this parameter depends on the value of the <i>Msg</i> parameter.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-defwindowprocw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>LRESULT</b> The return value is the result of the message processing and depends on the message.</para>
		/// </returns>
		/// <remarks>
		/// <para>> [!NOTE] > The winuser.h header defines DefWindowProc as an alias which automatically selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see [Conventions for Function Prototypes](/windows/win32/intl/conventions-for-function-prototypes).</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-defwindowprocw#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", EntryPoint = "DefWindowProcW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern nint DefWindowProc(WindowHandle hWnd, uint uMsg, nint wParam, nint lParam);

        /// <summary>Indicates to the system that a thread has made a request to terminate (quit). It is typically used in response to a WM_DESTROY message.</summary>
		/// <param name="nExitCode">
		/// <para>Type: <b>int</b> The application exit code. This value is used as the <i>wParam</i> parameter of the <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-quit">WM_QUIT</a> message.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-postquitmessage#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <remarks>
		/// <para>The <b>PostQuitMessage</b> function posts a <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-quit">WM_QUIT</a> message to the thread's message queue and returns immediately; the function simply indicates to the system that the thread is requesting to quit at some time in the future. When the thread retrieves the <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-quit">WM_QUIT</a> message from its message queue, it should exit its message loop and return control to the system. The exit value returned to the system must be the <i>wParam</i> parameter of the <b>WM_QUIT</b> message.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-postquitmessage#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern void PostQuitMessage(int nExitCode);

        /// <summary>Loads the specified cursor resource from the executable (.EXE) file associated with an application instance. (Unicode)</summary>
		/// <param name="hInstance">
		/// <para>Type: <b>HINSTANCE</b> A handle to an instance of the module whose executable file contains the cursor to be loaded.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-loadcursorw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="cursor">
		/// <para>Type: <b>LPCTSTR</b> The name of the cursor resource to be loaded. Alternatively, this parameter can consist of the resource identifier in the low-order word and zero in the high-order word. The <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-makeintresourcea">MAKEINTRESOURCE</a> macro can also be used to create this value. To use one of the predefined cursors, the application must set the <i>hInstance</i> parameter to <b>NULL</b> and the <i>lpCursorName</i> parameter to one the following values. </para>
		/// <para>This doc was truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-loadcursorw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HCURSOR</b> If the function succeeds, the return value is the handle to the newly loaded cursor. If the function fails, the return value is <b>NULL</b>. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <b>LoadCursor</b> function loads the cursor resource only if it has not been loaded; otherwise, it retrieves the handle to the existing resource. This function returns a valid cursor handle only if the <i>lpCursorName</i> parameter is a pointer to a cursor resource. If <i>lpCursorName</i> is a pointer to any type of resource other than a cursor (such as an icon), the return value is not <b>NULL</b>, even though it is not a valid cursor handle. The <b>LoadCursor</b> function searches the cursor resource most appropriate for the cursor for the current display device. The cursor resource can be a color or monochrome bitmap. <h3><a id="DPI_Virtualization"></a><a id="dpi_virtualization"></a><a id="DPI_VIRTUALIZATION"></a>DPI Virtualization</h3> This API does not participate in DPI virtualization. The output returned is not affected by the DPI of the calling thread.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-loadcursorw#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", EntryPoint = "LoadCursorW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern nint LoadCursor(nint hInstance, int cursor);

		/// <inheritdoc cref="LoadCursor(nint, int)"/>
        internal static nint LoadCursor(CursorImage cursor)
		{
			return LoadCursor(IntPtr.Zero, (int)cursor);
		}

        /// <summary>The BeginPaint function prepares the specified window for painting and fills a PAINTSTRUCT structure with information about the painting.</summary>
		/// <param name="hWnd">Handle to the window to be repainted.</param>
		/// <param name="lpPaint">Pointer to the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-paintstruct">PAINTSTRUCT</a> structure that will receive painting information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to a display device context for the specified window. If the function fails, the return value is <b>NULL</b>, indicating that no display device context is available.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <b>BeginPaint</b> function automatically sets the clipping region of the device context to exclude any area outside the update region. The update region is set by the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-invalidaterect">InvalidateRect</a> or <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-invalidatergn">InvalidateRgn</a> function and by the system after sizing, moving, creating, scrolling, or any other operation that affects the client area. If the update region is marked for erasing, <b>BeginPaint</b> sends a <b>WM_ERASEBKGND</b> message to the window. An application should not call <b>BeginPaint</b> except in response to a <b>WM_PAINT</b> message. Each call to <b>BeginPaint</b> must have a corresponding call to the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-endpaint">EndPaint</a> function. If the caret is in the area to be painted, <b>BeginPaint</b> automatically hides the caret to prevent it from being erased. If the window's class has a background brush, <b>BeginPaint</b> uses that brush to erase the background of the update region before returning. <h3><a id="DPI_Virtualization"></a><a id="dpi_virtualization"></a><a id="DPI_VIRTUALIZATION"></a>DPI Virtualization</h3> This API does not participate in DPI virtualization. The output returned is always in terms of physical pixels.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-beginpaint#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern DeviceContextHandle BeginPaint(WindowHandle hWnd, out PaintStruct lpPaint);

        /// <summary>The BeginPaint function prepares the specified window for painting and fills a PAINTSTRUCT structure with information about the painting.</summary>
		/// <param name="hWnd">Handle to the window to be repainted.</param>
		/// <param name="lpPaint">Pointer to the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-paintstruct">PAINTSTRUCT</a> structure that will receive painting information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to a display device context for the specified window. If the function fails, the return value is <b>NULL</b>, indicating that no display device context is available.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <b>BeginPaint</b> function automatically sets the clipping region of the device context to exclude any area outside the update region. The update region is set by the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-invalidaterect">InvalidateRect</a> or <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-invalidatergn">InvalidateRgn</a> function and by the system after sizing, moving, creating, scrolling, or any other operation that affects the client area. If the update region is marked for erasing, <b>BeginPaint</b> sends a <b>WM_ERASEBKGND</b> message to the window. An application should not call <b>BeginPaint</b> except in response to a <b>WM_PAINT</b> message. Each call to <b>BeginPaint</b> must have a corresponding call to the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-endpaint">EndPaint</a> function. If the caret is in the area to be painted, <b>BeginPaint</b> automatically hides the caret to prevent it from being erased. If the window's class has a background brush, <b>BeginPaint</b> uses that brush to erase the background of the update region before returning. <h3><a id="DPI_Virtualization"></a><a id="dpi_virtualization"></a><a id="DPI_VIRTUALIZATION"></a>DPI Virtualization</h3> This API does not participate in DPI virtualization. The output returned is always in terms of physical pixels.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-beginpaint#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool EndPaint(WindowHandle hWnd, in PaintStruct lpPaint);

        /// <summary>The FillRect function fills a rectangle by using the specified brush. This function includes the left and top borders, but excludes the right and bottom borders of the rectangle.</summary>
		/// <param name="deviceContextHandle">A handle to the device context.</param>
		/// <param name="lprc">A pointer to a <a href="https://docs.microsoft.com/windows/desktop/api/windef/ns-windef-rect">RECT</a> structure that contains the logical coordinates of the rectangle to be filled.</param>
		/// <param name="hbr">A handle to the brush used to fill the rectangle.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>The brush identified by the <i>hbr</i> parameter may be either a handle to a logical brush or a color value. If specifying a handle to a logical brush, call one of the following functions to obtain the handle: <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-createhatchbrush">CreateHatchBrush</a>, <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-createpatternbrush">CreatePatternBrush</a>, or <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-createsolidbrush">CreateSolidBrush</a>. Additionally, you may retrieve a handle to one of the stock brushes by using the <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-getstockobject">GetStockObject</a> function. If specifying a color value for the <i>hbr</i> parameter, it must be one of the standard system colors (the value 1 must be added to the chosen color). For example:</para>
		/// <para></para>
		/// <para>This doc was truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-fillrect#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int FillRect([In] DeviceContextHandle deviceContextHandle, [In] Rectangle lprc, [In] HBRUSH hbr);

        /// <summary>Retrieves the current color of the specified display element.</summary>
		/// <param name="index">Type: <b>int</b></param>
		/// <returns>
		/// <para>Type: <b>DWORD</b> The function returns the red, green, blue (RGB) color value of the given element. If the <i>nIndex</i> parameter is out of range, the return value is zero. Because zero is also a valid RGB value, you cannot use <b>GetSysColor</b> to determine whether a system color is supported by the current platform. Instead, use the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getsyscolorbrush">GetSysColorBrush</a> function, which returns <b>NULL</b> if the color is not supported.</para>
		/// </returns>
		/// <remarks>
		/// <para>To display the component of the RGB  value, use the <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-getrvalue">GetRValue</a>, <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-getgvalue">GetGValue</a>, and <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-getbvalue">GetBValue</a> macros. System colors for monochrome displays are usually interpreted as shades of gray. To paint with a system color brush, an application should use <c>GetSysColorBrush(nIndex)</code>, instead of <code>CreateSolidBrush(GetSysColor(nIndex))</c>, because <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getsyscolorbrush">GetSysColorBrush</a> returns a cached brush, instead of allocating a new one. Color is an important visual element of most user interfaces. For guidelines about using color in your applications, see <a href="https://docs.microsoft.com/windows/win32/uxguide/vis-color">Color - Win32</a> and <a href="https://docs.microsoft.com/windows/apps/design/signature-experiences/color">Color in Windows 11</a>.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getsyscolor#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern uint GetSysColor(SysColorIndex index);

        /// <summary>The CreateSolidBrush function creates a logical brush that has the specified solid color.</summary>
		/// <param name="color">The color of the brush. To create a <a href="https://docs.microsoft.com/windows/desktop/gdi/colorref">COLORREF</a> color value, use the <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-rgb">RGB</a> macro.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value identifies a logical brush. If the function fails, the return value is <b>NULL</b>.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you no longer need the <b>HBRUSH</b> object, call the <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-deleteobject">DeleteObject</a> function to delete it. A solid brush is a bitmap that the system uses to paint the interiors of filled shapes. After an application creates a brush by calling <b>CreateSolidBrush</b>, it can select that brush into any device context by calling the <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-selectobject">SelectObject</a> function. To paint with a system color brush, an application should use <c>GetSysColorBrush (nIndex)</code> instead of <code>CreateSolidBrush(GetSysColor(nIndex))</c>, because <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getsyscolorbrush">GetSysColorBrush</a> returns a cached brush instead of allocating a new one. <b>ICM:</b> No color management is done at brush creation. However, color management is performed when the brush is selected into an ICM-enabled device context.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/wingdi/nf-wingdi-createsolidbrush#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern HBRUSH CreateSolidBrush(COLORREF color);

        /// <summary>The GetSysColorBrush function retrieves a handle identifying a logical brush that corresponds to the specified color index.</summary>
		/// <param name="nIndex">A color index. This value corresponds to the color used to paint one of the window elements. See <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getsyscolor">GetSysColor</a> for system color index values.</param>
		/// <returns>The return value identifies a logical brush if the <i>nIndex</i> parameter is supported by the current platform. Otherwise, it returns <b>NULL</b>.</returns>
		/// <remarks>
		/// <para>A brush is a bitmap that the system uses to paint the interiors of filled shapes. An application can retrieve the current system colors by calling the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getsyscolor">GetSysColor</a> function. An application can set the current system colors by calling the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setsyscolors">SetSysColors</a> function. An application must not register a window class for a window using a system brush. To register a window class with a system color, see the documentation of the <b>hbrBackground</b> member of the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-wndclassa">WNDCLASS</a> or <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-wndclassexa">WNDCLASSEX</a> structures. System color brushes track changes in system colors. In other words, when the user changes a system color, the associated system color brush automatically changes to the new color. To paint with a system color brush, an application should use <b>GetSysColorBrush</b> (nIndex) instead of <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-createsolidbrush">CreateSolidBrush</a> ( <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getsyscolor">GetSysColor</a> (nIndex)), because <b>GetSysColorBrush</b> returns a cached brush instead of allocating a new one. System color brushes are owned by the system so you don't need to destroy them. Although you don't need to delete the logical brush that <b>GetSysColorBrush</b> returns, no harm occurs by calling <a href="https://docs.microsoft.com/windows/desktop/api/wingdi/nf-wingdi-deleteobject">DeleteObject</a>.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getsyscolorbrush#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern HBRUSH GetSysColorBrush(SysColorIndex nIndex);

        /// <summary>Retrieves a message from the calling thread's message queue. The function dispatches incoming sent messages until a posted message is available for retrieval. (GetMessageW)</summary>
		/// <param name="lpMsg">
		/// <para>Type: <b>LPMSG</b> A pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-msg">MSG</a> structure that receives message information from the thread's message queue.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="hWnd">
		/// <para>Type: <b>HWND</b> A handle to the window whose messages are to be retrieved. The window must belong to the current thread.</para>
		/// <para>If <i>hWnd</i> is <b>NULL</b>, <b>GetMessage</b> retrieves messages for any window that belongs to the current thread, and any messages on the current thread's message queue whose <b>hwnd</b> value is <b>NULL</b> (see the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-msg">MSG</a> structure). Therefore if hWnd is <b>NULL</b>, both window messages and thread messages are processed. If <i>hWnd</i> is -1, <b>GetMessage</b> retrieves only messages on the current thread's message queue whose <b>hwnd</b> value is <b>NULL</b>,  that is, thread messages as posted by  <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-postmessagea">PostMessage</a> (when the <i>hWnd</i> parameter is <b>NULL</b>) or <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-postthreadmessagea">PostThreadMessage</a>.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="wMsgFilterMin">
		/// <para>Type: <b>UINT</b> The integer value of the lowest message value to be retrieved. Use <b>WM_KEYFIRST</b> (0x0100) to specify the first keyboard message or <b>WM_MOUSEFIRST</b> (0x0200) to specify the first mouse message. Use <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-input">WM_INPUT</a> here and in <i>wMsgFilterMax</i> to specify only the <b>WM_INPUT</b> messages. If <i>wMsgFilterMin</i> and <i>wMsgFilterMax</i> are both zero, <b>GetMessage</b> returns all available messages (that is, no range filtering is performed).</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="wMsgFilterMax">
		/// <para>Type: <b>UINT</b> The integer value of the highest message value to be retrieved. Use <b>WM_KEYLAST</b> to specify the last keyboard message or <b>WM_MOUSELAST</b> to specify the last mouse message.</para>
		/// <para>Use <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-input">WM_INPUT</a> here and in <i>wMsgFilterMin</i> to specify only the <b>WM_INPUT</b> messages. If <i>wMsgFilterMin</i> and <i>wMsgFilterMax</i> are both zero, <b>GetMessage</b> returns all available messages (that is, no range filtering is performed).</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b> If the function retrieves a message other than <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-quit">WM_QUIT</a>, the return value is nonzero. If the function retrieves the <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-quit">WM_QUIT</a> message, the return value is zero. If there is an error, the return value is -1. For example, the function fails if <i>hWnd</i> is an invalid window handle or <i>lpMsg</i> is an invalid pointer. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>. Because the return value can be nonzero, zero, or -1, avoid code like this:</para>
		/// <para></para>
		/// <para>This doc was truncated.</para>
		/// </returns>
		/// <remarks>
		/// <para>An application typically uses the return value to determine whether to end the main message loop and exit the program. The <b>GetMessage</b> function retrieves messages associated with the window identified by the <i>hWnd</i> parameter or any of its children, as specified by the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-ischild">IsChild</a> function, and within the range of message values given by the <i>wMsgFilterMin</i> and <i>wMsgFilterMax</i> parameters. Note that an application can only use the low word in the <i>wMsgFilterMin</i> and <i>wMsgFilterMax</i> parameters; the high word is reserved for the system. Note that <b>GetMessage</b> always retrieves <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-quit">WM_QUIT</a> messages, no matter which values you specify for <i>wMsgFilterMin</i> and <i>wMsgFilterMax</i>. During this call, the system delivers pending, nonqueued messages, that is, messages sent to windows owned by the calling thread using the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-sendmessage">SendMessage</a>, <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-sendmessagecallbacka">SendMessageCallback</a>, <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-sendmessagetimeouta">SendMessageTimeout</a>, or <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-sendnotifymessagea">SendNotifyMessage</a> function. Then the first queued message that matches the specified filter is retrieved. The system may also process internal events. If no filter is specified, messages are processed in the following order:</para>
		/// <para></para>
		/// <para>This doc was truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getmessagew#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern sbyte GetMessage(out MSG lpMsg, WindowHandle hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        /// <summary>Translates virtual-key messages into character messages. The character messages are posted to the calling thread's message queue, to be read the next time the thread calls the GetMessage or PeekMessage function.</summary>
        /// <param name="lpMsg">
        /// <para>Type: <b>const <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-msg">MSG</a>*</b> A pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-msg">MSG</a> structure that contains message information retrieved from the calling thread's message queue by using the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getmessage">GetMessage</a> or <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-peekmessagea">PeekMessage</a> function.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-translatemessage#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <b>BOOL</b> If the message is translated (that is, a character message is posted to the thread's message queue), the return value is nonzero. If the message is <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-keydown">WM_KEYDOWN</a>, <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-keyup">WM_KEYUP</a>, <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-syskeydown">WM_SYSKEYDOWN</a>, or <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-syskeyup">WM_SYSKEYUP</a>, the return value is nonzero, regardless of the translation. If the message is not translated (that is, a character message is not posted to the thread's message queue), the return value is zero.</para>
        /// </returns>
        /// <remarks>
        /// <para>The <b>TranslateMessage</b> function does not modify the message pointed to by the <i>lpMsg</i> parameter.</para>
        /// <para><a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-keydown">WM_KEYDOWN</a> and <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-keyup">WM_KEYUP</a> combinations produce a <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-char">WM_CHAR</a> or <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-deadchar">WM_DEADCHAR</a> message. <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-syskeydown">WM_SYSKEYDOWN</a> and <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-syskeyup">WM_SYSKEYUP</a> combinations produce a <a href="https://docs.microsoft.com/windows/desktop/menurc/wm-syschar">WM_SYSCHAR</a> or <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-sysdeadchar">WM_SYSDEADCHAR</a> message. <b>TranslateMessage</b> produces <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-char">WM_CHAR</a> messages only for keys that are mapped to ASCII characters by the keyboard driver. If applications process virtual-key messages for some other purpose, they should not call <b>TranslateMessage</b>. For instance, an application should not call <b>TranslateMessage</b> if the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-translateacceleratora">TranslateAccelerator</a> function returns a nonzero value. Note that the application is responsible for retrieving and dispatching input messages to the dialog box. Most applications use the main message loop for this. However, to permit the user to move to and to select controls by using the keyboard, the application must call <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-isdialogmessagea">IsDialogMessage</a>. For more information, see  <a href="https://docs.microsoft.com/windows/desktop/dlgbox/dlgbox-programming-considerations">Dialog Box Keyboard Interface</a>.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-translatemessage#">Read more on docs.microsoft.com</see>.</para>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool TranslateMessage(in MSG lpMsg);

        /// <summary>Dispatches a message to a window procedure. It is typically used to dispatch a message retrieved by the GetMessage function. (DispatchMessageW)</summary>
        /// <param name="lpMsg">
        /// <para>Type: <b>const <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-msg">MSG</a>*</b> A pointer to a structure that contains the message.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-dispatchmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <b>LRESULT</b> The return value specifies the value returned by the window procedure. Although its meaning depends on the message being dispatched, the return value generally is ignored.</para>
        /// </returns>
        /// <remarks>
        /// <para>The <a href="https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-msg">MSG</a> structure must contain valid message values. If the <i>lpmsg</i> parameter points to a <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-timer">WM_TIMER</a> message and the <i>lParam</i> parameter of the <b>WM_TIMER</b> message is not <b>NULL</b>, <i>lParam</i> points to a function that is called instead of the window procedure. Note that the application is responsible for retrieving and dispatching input messages to the dialog box. Most applications use the main message loop for this. However, to permit the user to move to and to select controls by using the keyboard, the application must call <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-isdialogmessagea">IsDialogMessage</a>. For more information, see <a href="https://docs.microsoft.com/windows/desktop/dlgbox/dlgbox-programming-considerations">Dialog Box Keyboard Interface</a>.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-dispatchmessagew#">Read more on docs.microsoft.com</see>.</para>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern LRESULT DispatchMessage(in MSG lpMsg);

        /// <summary>The FormatMessageW (Unicode) function (winbase.h) formats a message string.</summary>
		/// <param name="dwFlags">
		/// <para>The formatting options, and how to interpret the <i>lpSource</i> parameter. The low-order byte of <i>dwFlags</i> specifies how the function handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-formatmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="lpSource">
		/// <para>The location of the message definition. The type of this parameter depends upon the settings in the <i>dwFlags</i> parameter. </para>
		/// <para>This doc was truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-formatmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="dwMessageId">
		/// <para>The message identifier for the requested message. This parameter is ignored if <i>dwFlags</i> includes <b>FORMAT_MESSAGE_FROM_STRING</b>.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-formatmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="dwLanguageId">
		/// <para>The <a href="https://docs.microsoft.com/windows/desktop/Intl/language-identifiers">language identifier</a> for the requested message. This parameter is ignored if <i>dwFlags</i> includes <b>FORMAT_MESSAGE_FROM_STRING</b>. If you pass a specific <b>LANGID</b> in this parameter, <b>FormatMessage</b> will return a message for that <b>LANGID</b> only. If the function cannot find a message for that <b>LANGID</b>, it sets Last-Error to <b>ERROR_RESOURCE_LANG_NOT_FOUND</b>. If you pass in zero, <b>FormatMessage</b> looks for a message for <b>LANGIDs</b> in the following order: </para>
		/// <para>This doc was truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-formatmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If <i>dwFlags</i> includes <b>FORMAT_MESSAGE_ALLOCATE_BUFFER</b>, the function allocates a buffer using the <a href="https://docs.microsoft.com/windows/desktop/api/winbase/nf-winbase-localalloc">LocalAlloc</a> function, and places the pointer to the buffer at the address specified in <i>lpBuffer</i>. This buffer cannot be larger than 64K bytes.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-formatmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>If the <b>FORMAT_MESSAGE_ALLOCATE_BUFFER</b> flag is not set, this parameter specifies the size of the output buffer, in <b>TCHARs</b>. If <b>FORMAT_MESSAGE_ALLOCATE_BUFFER</b> is set, this parameter specifies the minimum number of <b>TCHARs</b> to allocate for an output buffer. The output buffer cannot be larger than 64K bytes.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-formatmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="Arguments">
		/// <para>An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the <i>Arguments</i> array; a %2 indicates the second argument; and so on. The interpretation of each value depends on the formatting information associated with the insert in the message definition. The default is to treat each value as a pointer to a null-terminated string. By default, the <i>Arguments</i> parameter is of type <b>va_list*</b>, which is a language- and implementation-specific data type for describing a variable number of arguments. The state of the <b>va_list</b> argument is undefined upon return from the function. To use the <b>va_list</b> again, destroy the variable argument list pointer using <b>va_end</b> and reinitialize it with <b>va_start</b>. If you do not have a pointer of type <b>va_list*</b>, then specify the <b>FORMAT_MESSAGE_ARGUMENT_ARRAY</b> flag and pass a pointer to an array of <b>DWORD_PTR</b> values; those values are input to the message formatted as the insert values. Each insert must have a corresponding element in the array.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-formatmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the number of <b>TCHARs</b> stored in the output buffer, excluding the terminating null character. If the function fails, the return value is zero. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>.</para>
		/// </returns>
		/// <remarks>
		/// <para>Within the message text, several escape sequences are supported for dynamically formatting the message. These escape sequences and their meanings are shown in the following tables. All escape sequences start with the percent character (%). </para>
		/// <para>This doc was truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-formatmessagew#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern uint FormatMessageW(FormatMessageOptions dwFlags, nint lpSource, uint dwMessageId, uint dwLanguageId, ref nint lpBuffer, uint nSize, nint Arguments);

        /// <summary>Frees the specified local memory object and invalidates its handle.</summary>
		/// <param name="hMem">
		/// <para>A handle to the local memory object. This handle is returned by either the <a href="https://docs.microsoft.com/windows/desktop/api/winbase/nf-winbase-localalloc">LocalAlloc</a> or <a href="https://docs.microsoft.com/windows/desktop/api/winbase/nf-winbase-localrealloc">LocalReAlloc</a> function. It is not safe to free memory allocated with <a href="https://docs.microsoft.com/windows/desktop/api/winbase/nf-winbase-globalalloc">GlobalAlloc</a>.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-localfree#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <b>NULL</b>. If the function fails, the return value is equal to a handle to the local memory object. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>.</para>
		/// </returns>
		/// <remarks>
		/// <para>If the process tries to examine or modify the memory after it has been freed, heap corruption may occur or an access violation exception (EXCEPTION_ACCESS_VIOLATION) may be generated. If the <i>hMem</i> parameter is <b>NULL</b>, <b>LocalFree</b> ignores the parameter and returns <b>NULL</b>. The <b>LocalFree</b> function will free a locked memory object. A locked memory object has a lock count greater than zero. The <a href="https://docs.microsoft.com/windows/desktop/api/winbase/nf-winbase-locallock">LocalLock</a> function locks a local memory object and increments the lock count by one. The <a href="https://docs.microsoft.com/windows/desktop/api/winbase/nf-winbase-localunlock">LocalUnlock</a> function unlocks it and decrements the lock count by one. To get the lock count of a local memory object, use the <a href="https://docs.microsoft.com/windows/desktop/api/winbase/nf-winbase-localflags">LocalFlags</a> function. If an application is running under a debug version of the system, <b>LocalFree</b> will issue a message that tells you that a locked object is being freed. If you are debugging the application, <b>LocalFree</b> will enter a breakpoint just before freeing a locked object. This allows you to verify the intended behavior, then continue execution.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-localfree#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern nint LocalFree(nint hMem);

        /// <summary>Retrieves a copy of the character string associated with the specified global atom. (Unicode)</summary>
		/// <param name="nAtom">
		/// <para>Type: <b>ATOM</b> The global atom associated with the character string to be retrieved.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-globalgetatomnamew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>Type: <b>LPTSTR</b> The buffer for the character string.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-globalgetatomnamew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>Type: <b>int</b> The size, in characters, of the buffer.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-globalgetatomnamew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>UINT</b> If the function succeeds, the return value is the length of the string copied to the buffer, in characters, not including the terminating null character. If the function fails, the return value is zero. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The string returned for an integer atom (an atom whose value is in the range 0x0001 to 0xBFFF) is a null-terminated string in which the first character is a pound sign (#) and the remaining characters represent the unsigned integer atom value. <h3><a id="Security_Considerations"></a><a id="security_considerations"></a><a id="SECURITY_CONSIDERATIONS"></a>Security Considerations</h3> Using this function incorrectly might compromise the security of your program. Incorrect use of this function includes not correctly specifying the size of the <i>lpBuffer</i> parameter. Also, note that a global atom is accessible by anyone; thus, privacy and the integrity of its contents is not assured.</para>
		/// <para>> [!NOTE] > The winbase.h header defines GlobalGetAtomName as an alias which automatically selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see [Conventions for Function Prototypes](/windows/win32/intl/conventions-for-function-prototypes).</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-globalgetatomnamew#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
		[DllImport("kernel32.dll", EntryPoint = "GlobalGetAtomNameW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern uint GlobalGetAtomName(ushort nAtom, PWSTR lpBuffer, int nSize);

        /// <summary>Retrieves from the clipboard the name of the specified registered format. The function copies the name to the specified buffer. (Unicode)</summary>
		/// <param name="format">
		/// <para>Type: <b>UINT</b> The type of format to be retrieved. This parameter must not specify any of the predefined clipboard formats.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getclipboardformatnamew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="lpszFormatName">
		/// <para>Type: <b>LPTSTR</b> The buffer that is to receive the format name.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getclipboardformatnamew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="cchMaxCount">
		/// <para>Type: <b>int</b> The maximum length, in characters, of the string to be copied to the buffer. If the name exceeds this limit, it is truncated.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getclipboardformatnamew#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>int</b> If the function succeeds, the return value is the length, in characters, of the string copied to the buffer. If the function fails, the return value is zero, indicating that the requested format does not exist or is predefined. To get extended error information, call <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>.</para>
		/// </returns>
		/// <remarks>
		/// <para><h3><a id="Security_Considerations"></a><a id="security_considerations"></a><a id="SECURITY_CONSIDERATIONS"></a>Security Considerations</h3> Using this function incorrectly might compromise the security of your program. For example, miscalculating the proper size of the <i>lpszFormatName</i> buffer, especially when the application is used in both ANSI and Unicode versions, can cause a buffer overflow. Also, note that the string is truncated if it is longer than the <i>cchMaxCount</i> parameter, which can lead to loss of information.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-getclipboardformatnamew#">Read more on docs.microsoft.com</see>.</para>
		/// </remarks>
		[DllImport("user32.dll", EntryPoint = "GetClipboardFormatNameW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int GetClipboardFormatName(uint format, PWSTR lpszFormatName, int cchMaxCount);

        /// <summary>Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message. (SendMessageW)</summary>
        /// <param name="hWnd">
        /// <para>Type: <b>HWND</b> A handle to the window whose window procedure will receive the message. If this parameter is <b>HWND_BROADCAST</b> ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows. Message sending is subject to UIPI. The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <param name="msg">
        /// <para>Type: <b>UINT</b> The message to be sent. For lists of the system-provided messages, see <a href="https://docs.microsoft.com/windows/desktop/winmsg/about-messages-and-message-queues">System-Defined Messages</a>.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <param name="wParam">
        /// <para>Type: <b>WPARAM</b> Additional message-specific information.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <param name="lParam">
        /// <para>Type: <b>LPARAM</b> Additional message-specific information.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendmessagew#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <b>LRESULT</b> The return value specifies the result of the message processing; it depends on the message sent.</para>
        /// </returns>
        /// <remarks>
        /// <para>When a message is blocked by UIPI the last error, retrieved with <a href="https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>, is set to 5 (access denied). Applications that need to communicate using <b>HWND_BROADCAST</b> should use the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-registerwindowmessagea">RegisterWindowMessage</a> function to obtain a unique message for inter-application communication. The system only does marshalling for system messages (those in the range 0 to (<a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-user">WM_USER</a>-1)). To send other messages (those &gt;= <b>WM_USER</b>) to another process, you must do custom marshalling. If the specified window was created by the calling thread, the window procedure is called immediately as a subroutine. If the specified window was created by a different thread, the system switches to that thread and calls the appropriate window procedure. Messages sent between threads are processed only when the receiving thread executes message retrieval code. The sending thread is blocked until the receiving thread processes the message. However, the sending thread will process incoming nonqueued messages while waiting for its message to be processed. To prevent this, use <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-sendmessagetimeouta">SendMessageTimeout</a> with SMTO_BLOCK set. For more information on nonqueued messages, see <a href="https://docs.microsoft.com/windows/desktop/winmsg/about-messages-and-message-queues">Nonqueued Messages</a>. An accessibility application can use <b>SendMessage</b> to send <a href="https://docs.microsoft.com/windows/desktop/inputdev/wm-appcommand">WM_APPCOMMAND</a> messages  to the shell to launch applications. This  functionality is not guaranteed to work for other types of applications.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendmessagew#">Read more on docs.microsoft.com</see>.</para>
        /// </remarks>
        [DllImport("user32.dll", EntryPoint = "SendMessageW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern nint SendMessage(WindowHandle hWnd, uint msg, nint wParam, nint lParam);

        /// <summary>The InvalidateRect function adds a rectangle to the specified window's update region. The update region represents the portion of the window's client area that must be redrawn.</summary>
        /// <param name="windowHandle">A handle to the window whose update region has changed. If this parameter is <b>NULL</b>, the system invalidates and redraws all windows, not just the windows for this application, and sends the <a href="https://docs.microsoft.com/windows/desktop/winmsg/wm-erasebkgnd">WM_ERASEBKGND</a> and <a href="https://docs.microsoft.com/windows/desktop/gdi/wm-ncpaint">WM_NCPAINT</a> messages before the function returns. Setting this parameter to <b>NULL</b> is not recommended.</param>
        /// <param name="rectanglePointer">A pointer to a <a href="https://docs.microsoft.com/windows/desktop/api/windef/ns-windef-rect">RECT</a> structure that contains the client coordinates of the rectangle to be added to the update region. If this parameter is <b>NULL</b>, the entire client area is added to the update region.</param>
        /// <param name="erase">Specifies whether the background within the update region is to be erased when the update region is processed. If this parameter is <b>TRUE</b>, the background is erased when the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-beginpaint">BeginPaint</a> function is called. If this parameter is <b>FALSE</b>, the background remains unchanged.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</para>
        /// </returns>
        /// <remarks>
        /// <para>The invalidated areas accumulate in the update region until the region is processed when the next <a href="https://docs.microsoft.com/windows/desktop/gdi/wm-paint">WM_PAINT</a> message occurs or until the region is validated by using the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-validaterect">ValidateRect</a> or <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-validatergn">ValidateRgn</a> function. The system sends a <a href="https://docs.microsoft.com/windows/desktop/gdi/wm-paint">WM_PAINT</a> message to a window whenever its update region is not empty and there are no other messages in the application queue for that window. If the <i>bErase</i> parameter is <b>TRUE</b> for any part of the update region, the background is erased in the entire region, not just in the specified part.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-invalidaterect#">Read more on docs.microsoft.com</see>.</para>
        /// </remarks>
		[DllImport("user32.dll", EntryPoint = "InvalidateRect", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern unsafe bool InvalidateRect(WindowHandle windowHandle, [Optional] Rectangle* rectanglePointer, bool erase);

		/// <inheritdoc cref="InvalidateRect(WindowHandle, Rectangle*, bool)"/>
        internal static bool InvalidateRect(WindowHandle windowHandle, bool erase)
		{
			unsafe
			{
                return InvalidateRect(windowHandle, null, erase);
            }
		}

        /// <summary>
        /// The DrawTextEx function draws formatted text in the specified rectangle.
        /// </summary>
        /// <param name="deviceContext">A handle to the device context in which to draw.</param>
        /// <param name="text">A pointer to the string that contains the text to draw. If the cchText parameter is -1, the string must be null-terminated.<br/>
        /// If dwDTFormat includes DT_MODIFYSTRING, the function could add up to four additional characters to this string. The buffer containing the string should be large enough to accommodate these extra characters.</param>
        /// <param name="textLength">The length of the string pointed to by lpchText. If cchText is -1, then the lpchText parameter is assumed to be a pointer to a null-terminated string and DrawTextEx computes the character count automatically.</param>
        /// <param name="area">A pointer to a RECT structure that contains the rectangle, in logical coordinates, in which the text is to be formatted.</param>
        /// <param name="format">The formatting options. This parameter can be one or more of TextDrawingFormat enum values.</param>
        /// <param name="drawTextParams">A pointer to a DRAWTEXTPARAMS structure that specifies additional formatting options. This parameter can be NULL.</param>
        /// <returns>If the function succeeds, the return value is the text height in logical units.<br/>
		/// If DT_VCENTER or DT_BOTTOM is specified, the return value is the offset from lprc->top to the bottom of the drawn text.<br/>
		/// If the function fails, the return value is zero.</returns>
        [DllImport("user32.dll", EntryPoint = "DrawTextExW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int DrawText(
			DeviceContextHandle deviceContext,
			string text,
			int textLength,
			Rectangle area,
			DrawTextFormat format,
			DrawTextParams drawTextParams
		);


        #endregion
    }
}
