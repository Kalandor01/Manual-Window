﻿using System.Runtime.InteropServices;

namespace CleanWpfApp
{
    internal class Program
    {
        // Import user32.dll (containing the function we need) and define
        // the method corresponding to the native function.
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        public static void Main()
        {
            MessageBox(0, "test", "caption", 0);
        }
    }
}
