// Description: P/Invokes for methods that need to call SetLastError(0)

// The NativeMethodsSetLastError class differs between assemblies and could not actually be
//  shared, so it is duplicated across namespaces to prevent name collision.

using System.Runtime.InteropServices;
using System.Text;

namespace CleanWpfApp
{
    internal static class NativeMethodsSetLastError
    {
        private const string PresentationNativeDll = "PresentationNative_cor3.dll";

        [DllImport(PresentationNativeDll, EntryPoint = "EnableWindowWrapper", SetLastError = true, ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool EnableWindow(HandleRef hWnd, bool enable);

        [DllImport(PresentationNativeDll, EntryPoint = "GetAncestorWrapper", CharSet = CharSet.Auto)]
        public static extern IntPtr GetAncestor(IntPtr hwnd, int gaFlags);

        [DllImport(PresentationNativeDll, EntryPoint = "GetKeyboardLayoutListWrapper", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetKeyboardLayoutList(int size, [Out, MarshalAs(UnmanagedType.LPArray)] IntPtr[] hkls);

        [DllImport(PresentationNativeDll, EntryPoint = "GetParentWrapper", SetLastError = true)]
        public static extern IntPtr GetParent(HandleRef hWnd);

        [DllImport(PresentationNativeDll, EntryPoint = "GetWindowWrapper", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);

        [DllImport(PresentationNativeDll, EntryPoint = "GetWindowLongWrapper", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        [DllImport(PresentationNativeDll, EntryPoint = "GetWindowLongWrapper", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport(PresentationNativeDll, EntryPoint = "GetWindowLongWrapper", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern NativeMethods.WndProc GetWindowLongWndProc(HandleRef hWnd, int nIndex);

        [DllImport(PresentationNativeDll, EntryPoint = "GetWindowLongPtrWrapper", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport(PresentationNativeDll, EntryPoint = "GetWindowLongPtrWrapper", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetWindowLongPtr(HandleRef hWnd, int nIndex);

        [DllImport(PresentationNativeDll, EntryPoint = "GetWindowLongPtrWrapper", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern NativeMethods.WndProc GetWindowLongPtrWndProc(HandleRef hWnd, int nIndex);

        [DllImport(PresentationNativeDll, EntryPoint = "GetWindowTextWrapper", CharSet = CharSet.Auto, BestFitMapping = false, SetLastError = true)]
        public static extern int GetWindowText(HandleRef hWnd, [Out] StringBuilder lpString, int nMaxCount);

        [DllImport(PresentationNativeDll, EntryPoint = "GetWindowTextLengthWrapper", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowTextLength(HandleRef hWnd);

        [DllImport(PresentationNativeDll, EntryPoint = "MapWindowPointsWrapper", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] ref NativeMethods.RECT rect, int cPoints);

        [DllImport(PresentationNativeDll, EntryPoint = "SetFocusWrapper", SetLastError = true)]
        public static extern IntPtr SetFocus(HandleRef hWnd);

        [DllImport(PresentationNativeDll, EntryPoint = "SetWindowLongWrapper", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport(PresentationNativeDll, EntryPoint = "SetWindowLongWrapper", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport(PresentationNativeDll, EntryPoint = "SetWindowLongWrapper", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetWindowLongWndProc(HandleRef hWnd, int nIndex, NativeMethods.WndProc dwNewLong);

        [DllImport(PresentationNativeDll, EntryPoint = "SetWindowLongPtrWrapper", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport(PresentationNativeDll, EntryPoint = "SetWindowLongPtrWrapper", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport(PresentationNativeDll, EntryPoint = "SetWindowLongPtrWrapper", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowLongPtrWndProc(HandleRef hWnd, int nIndex, NativeMethods.WndProc dwNewLong);
    }
}
