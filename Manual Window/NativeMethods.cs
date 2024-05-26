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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpText"></param>
        /// <param name="lpCaption"></param>
        /// <param name="uType"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int MessageBox(nint hWnd, string lpText, string lpCaption, uint uType);

        /// <summary>The UpdateWindow function updates the client area of the specified window by sending a WM_PAINT message to the window if the window's update region is not empty.</summary>
		/// <param name="hWnd">Handle to the window to be updated.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-updatewindow">Learn more about this API from docs.microsoft.com</see>.</para>
		/// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool UpdateWindow(nint hWnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ShowWindow(nint hWnd, int nCmdShow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool DestroyWindow(nint hWnd);

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
        internal static extern nint DefWindowProc(nint hWnd, uint uMsg, nint wParam, nint lParam);

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
        internal static extern nint BeginPaint(nint hWnd, out PAINTSTRUCT lpPaint);

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
        internal static extern bool EndPaint(nint hWnd, in PAINTSTRUCT lpPaint);

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
        [DllImport("user32.dll")]
        internal static extern sbyte GetMessage(out MSG lpMsg, nint hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

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
        [DllImport("user32.dll")]
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
        [DllImport("user32.dll")]
        internal static extern LRESULT DispatchMessage(in MSG lpMsg);
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct WNDCLASSEX
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
        internal struct PAINTSTRUCT
        {
            /// <summary>
            /// A handle to the device context.
            /// </summary>
            public nint hdc;
            public bool fErase;
            /// <summary>
            /// A handle to the rectangle that needs to be painted.
            /// </summary>
            public nint rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }
        #endregion
    }
}
