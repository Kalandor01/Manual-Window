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
        [DllImport("kernel32.dll")]
        internal static extern uint GetLastError();

        /// <summary>Displays a modal dialog box that contains a system icon, a set of buttons, and a brief application-specific message, such as status or error information. The message box returns an integer value that indicates which button the user clicked. (MessageBoxW)</summary>
		/// <param name="hWnd">
		/// <para>Type: <b>HWND</b> A handle to the owner window of the message box to be created. If this parameter is <b>NULL</b>, the message box has no owner window.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-messageboxw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="lpText">
		/// <para>Type: <b>LPCTSTR</b> The message to be displayed. If the string consists of more than one line, you can separate the lines using a carriage return and/or linefeed character between each line.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-messageboxw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="lpCaption">
		/// <para>Type: <b>LPCTSTR</b> The dialog box title. If this parameter is <b>NULL</b>, the default title is <b>Error</b>.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-messageboxw#parameters">Read more on docs.microsoft.com</see>.</para>
		/// </param>
		/// <param name="uType">
		/// <para>Type: <b>UINT</b> The contents and behavior of the dialog box. This parameter can be a combination of flags from the following groups of flags.</para>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-messageboxw#parameters">Read more on docs.microsoft.com</see>.</para>
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
        [DllImport("user32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern MessageBoxResult MessageBox(HWND hWnd, string lpText, string lpCaption, MessageBoxStyle uType);

        /// <summary>The UpdateWindow function updates the client area of the specified window by sending a WM_PAINT message to the window if the window's update region is not empty.</summary>
		/// <param name="hWnd">Handle to the window to be updated.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-updatewindow">Learn more about this API from docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool UpdateWindow(HWND hWnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ShowWindow(HWND hWnd, int nCmdShow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool DestroyWindow(HWND hWnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwExStyle"></param>
        /// <param name="regResult"></param>
        /// <param name="lpWindowName"></param>
        /// <param name="dwStyle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="hWndParent"></param>
        /// <param name="hMenu"></param>
        /// <param name="hInstance"></param>
        /// <param name="lpParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern HWND CreateWindowEx(
               int dwExStyle,
               ushort regResult,
               //string lpClassName,
               string lpWindowName,
               uint dwStyle,
               int x,
               int y,
               int nWidth,
               int nHeight,
               HWND hWndParent,
               nint hMenu,
               nint hInstance,
               nint lpParam
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpWndClass"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern ushort RegisterClassEx([In] ref WNDCLASSEX lpWndClass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern nint DefWindowProc(HWND hWnd, uint uMsg, nint wParam, nint lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nExitCode"></param>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern void PostQuitMessage(int nExitCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hInstance"></param>
        /// <param name="lpCursorName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern nint LoadCursor(nint hInstance, int lpCursorName);

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
        internal static extern nint BeginPaint(HWND hWnd, out PAINTSTRUCT lpPaint);

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
        internal static extern bool EndPaint(HWND hWnd, in PAINTSTRUCT lpPaint);

        /// <summary>The FillRect function fills a rectangle by using the specified brush. This function includes the left and top borders, but excludes the right and bottom borders of the rectangle.</summary>
		/// <param name="hDC">A handle to the device context.</param>
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
        internal static extern int FillRect([In] HDC hDC, [In] RECT lprc, [In] HBRUSH hbr);

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
        internal static extern sbyte GetMessage(out MSG lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

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
		[DllImport("kernel32.dll", ExactSpelling = true, EntryPoint = "GlobalGetAtomNameW", CharSet = CharSet.Unicode, SetLastError = true)]
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
		[DllImport("user32.dll", ExactSpelling = true, EntryPoint = "GetClipboardFormatNameW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int GetClipboardFormatName(uint format, PWSTR lpszFormatName, int cchMaxCount);
        #endregion

        #region delegates
        internal delegate nint WndProc(HWND hWnd, uint msg, nint wParam, nint lParam);
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct WNDCLASSEX
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public int style;
            public WndProc lpfnWndProc;
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
        internal struct PAINTSTRUCT
        {
            /// <summary>
            /// A handle to the device context.
            /// </summary>
            public HDC hdc;
            public bool fErase;
            /// <summary>
            /// A handle to the rectangle that needs to be painted.
            /// </summary>
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(nint pointer)
            {
                var r = new RECT();
                unsafe
                {
                    r = *(RECT*)&pointer;
                }
                left = r.left;
                top = r.top;
                right = r.right;
                bottom = r.bottom;
            }

            public RECT(int left, int top, int right, int bottom)
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

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTS
        {
            public short x;
            public short y;

            public POINTS(nint pointer)
            {
                var ps = new POINTS();
                unsafe
                {
                    ps = *(POINTS*)&pointer;
                }
                x = ps.x;
                y = ps.y;
            }

            public POINTS(short x, short y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"({x}, {y})";
            }
        }

        /// <summary>
        /// Contains information about the size and position of a window.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            /// <summary>
            /// A handle to the window.
            /// </summary>
            public HWND hwnd;
            /// <summary>
            /// A handle to the window in front of this window in the Z order, or a special value (-2 - 1).
            /// </summary>
            public HWND hwndInsertAfter;
            /// <summary>
            /// The position of the left edge of the window.
            /// </summary>
            public int x;
            /// <summary>
            /// The position of the top edge of the window.
            /// </summary>
            public int y;
            /// <summary>
            /// The window width, in pixels.
            /// </summary>
            public int width;
            /// <summary>
            /// The window height, in pixels.
            /// </summary>
            public int height;
            /// <summary>
            /// The window position. A combination of values from the WindowPosFlags enum.
            /// </summary>
            public uint flags;

            /// <summary>
            /// <inheritdoc cref="WINDOWPOS" path="//summary"/>
            /// </summary>
            /// <param name="pointer">A pointer to a WINDOWPOS object.</param>
            public WINDOWPOS(nint pointer)
            {
                var wp = new WINDOWPOS();
                unsafe
                {
                    wp = *(WINDOWPOS*)&pointer;
                }

                hwnd = wp.hwnd;
                hwndInsertAfter = wp.hwndInsertAfter;
                x = wp.x;
                y = wp.y;
                width = wp.width;
                height = wp.height;
                flags = wp.flags;
            }

            public override string ToString()
            {
                var f = flags;
                return $"pos: ({x}, {y}), size: ({width}, {height}), flags: [{string.Join(", ", Enum.GetValues<WindowPosFlags>().Where(flag => ((int)flag & f) != 0))}]";
            }
        }
        #endregion
    }
}
