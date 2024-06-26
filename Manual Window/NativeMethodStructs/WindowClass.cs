﻿using ManualWindow.NativeMethodEnums;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace ManualWindow.NativeMethodStructs
{
    #region delegates
    internal delegate nint WndProc(WindowHandle hWnd, uint msg, nint wParam, nint lParam);
    #endregion

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct WindowClass
    {
        /// <summary>
        /// <para>Type: <b>UINT</b> The size, in bytes, of this structure. Set this member to <c>sizeof(WNDCLASSEX)</c>. Be sure to set this member before calling the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-getclassinfoexa">GetClassInfoEx</a> function.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// <para>Type: <b>UINT</b> The class style(s). This member can be any combination of the <a href="https://docs.microsoft.com/windows/win32/winmsg/window-class-styles">Class Styles</a>.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public WindowClassStyle style;

        /// <summary>
        /// <para>Type: <b>WNDPROC</b> A pointer to the window procedure. You must use the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-callwindowproca">CallWindowProc</a> function to call the window procedure. For more information, see <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms633573(v=vs.85)">WindowProc</a>.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public WndProc lpfnWndProc;

        /// <summary>
        /// <para>Type: <b>int</b> The number of extra bytes to allocate following the window-class structure. The system initializes the bytes to zero.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public int cbClsExtra;

        /// <summary>
        /// <para>Type: <b>int</b> The number of extra bytes to allocate following the window instance. The system initializes the bytes to zero. If an application uses <b>WNDCLASSEX</b> to register a dialog box created by using the <b>CLASS</b> directive in the resource file, it must set this member to <b>DLGWINDOWEXTRA</b>.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public int cbWndExtra;

        /// <summary>
        /// <para>Type: <b>HINSTANCE</b> A handle to the instance that contains the window procedure for the class.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public nint hInstance;

        /// <summary>
        /// <para>Type: <b>HICON</b> A handle to the class icon. This member must be a handle to an icon resource. If this member is <b>NULL</b>, the system provides a default icon.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public IconHandle hIcon;

        /// <summary>
        /// <para>Type: <b>HCURSOR</b> A handle to the class cursor. This member must be a handle to a cursor resource. If this member is <b>NULL</b>, an application must explicitly set the cursor shape whenever the mouse moves into the application's window.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public nint hCursor;

        /// <summary>
        /// <para>Type: <b>HBRUSH</b> A handle to the class background brush. This member can be a handle to the brush to be used for painting the background, or it can be a color value. A color value must be one of the following standard system colors (the value 1 must be added to the chosen color). If a color value is given, you must convert it to one of the following <b>HBRUSH</b> types: </para>
        /// <para>This doc was truncated.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public HBRUSH hbrBackground;

        /// <summary>
        /// <para>Type: <b>LPCTSTR</b> Pointer to a null-terminated character string that specifies the resource name of the class menu, as the name appears in the resource file. If you use an integer to identify the menu, use the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-makeintresourcea">MAKEINTRESOURCE</a> macro. If this member is <b>NULL</b>, windows belonging to this class have no default menu.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public string? lpszMenuName;

        /// <summary>
        /// <para>Type: <b>LPCTSTR</b> A pointer to a null-terminated string or is an atom. If this parameter is an atom, it must be a class atom created by a previous call to the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-registerclassa">RegisterClass</a> or <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-registerclassexa">RegisterClassEx</a> function. The atom must be in the low-order word of <b>lpszClassName</b>; the high-order word must be zero.</para>
        /// <para>If <b>lpszClassName</b> is a string, it specifies the window class name. The class name can be any name registered with <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-registerclassa">RegisterClass</a> or <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-registerclassexa">RegisterClassEx</a>, or any of the predefined control-class names. The maximum length for <b>lpszClassName</b> is 256. If <b>lpszClassName</b> is greater than the maximum length, the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-registerclassexa">RegisterClassEx</a> function will fail.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public string lpszClassName;

        /// <summary>
        /// <para>Type: <b>HICON</b> A handle to a small icon that is associated with the window class. If this member is <b>NULL</b>, the system searches the icon resource specified by the <b>hIcon</b> member for an icon of the appropriate size to use as the small icon.</para>
        /// <para><see href="https://learn.microsoft.com/windows/win32/api/winuser/ns-winuser-wndclassexw#members">Read more on docs.microsoft.com</see>.</para>
        /// </summary>
        public IconHandle hIconSm;

    }
}
