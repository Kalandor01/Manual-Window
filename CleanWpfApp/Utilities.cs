using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CleanWpfApp
{
    /// <summary>
    /// General utility class for macro-type functions.
    /// </summary>
    internal static class Utilities
    {
        private static readonly Version _osVersion = Environment.OSVersion.Version;

        internal static bool IsOSVistaOrNewer
        {
            get { return _osVersion >= new Version(6, 0); }
        }

        internal static bool IsOSWindows7OrNewer
        {
            get { return _osVersion >= new Version(6, 1); }
        }

        internal static bool IsOSWindows8OrNewer
        {
            get { return _osVersion >= new Version(6, 2); }
        }

        internal static bool IsCompositionEnabled
        {
            get
            {
                if (!IsOSVistaOrNewer)
                {
                    return false;
                }

                UnsafeNativeMethods.HRESULT.Check(UnsafeNativeMethods.DwmIsCompositionEnabled(out var isDesktopCompositionEnabled));
                return isDesktopCompositionEnabled != 0;
            }
        }

        internal static void SafeDispose<T>(ref T disposable) where T : IDisposable
        {
            // Dispose can safely be called on an object multiple times.
            var t = disposable;
            disposable = default;
            t?.Dispose();
        }

        internal static void SafeRelease<T>(ref T comObject) where T : class
        {
            var t = comObject;
            comObject = default;
            if (null != t)
            {
                Debug.Assert(Marshal.IsComObject(t));
                Marshal.ReleaseComObject(t);
            }
        }
    }
}
