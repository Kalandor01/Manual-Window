// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/***************************************************************************\
*
* Purpose:  Helper functions that require elevation but are safe to use.
*
\***************************************************************************/

// The SecurityHelper class differs between assemblies and could not actually be
//  shared, so it is duplicated across namespaces to prevent name collision.
// This duplication seems hardly necessary now. We should continue
// trying to reduce it by pushing things from Framework to Core (whenever it makes sense).
namespace CleanWpfApp
{
    using System;
    using System.Globalization;     // CultureInfo
    using System.Security;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using System.Diagnostics.CodeAnalysis;
    using MS.Win32;
    using System.IO.Packaging;
    using System.Diagnostics;
    using System.Windows;
    using MS.Internal.Utility;      // BindUriHelper
    using MS.Internal.AppModel;

    internal static class SecurityHelper
    {
        internal static Exception GetExceptionForHR(int hr)
        {
            return Marshal.GetExceptionForHR(hr, new IntPtr(-1));
        }

        /// <summary>
        /// A helper method to do the necessary work to display a standard MessageBox.  This method performs
        /// and necessary elevations to make the dialog work as well.
        /// </summary>
        internal
        static
        void
        ShowMessageBoxHelper(
            System.Windows.Window parent,
            string text,
            string title,
            System.Windows.MessageBoxButton buttons,
            System.Windows.MessageBoxImage image
            )
        {
            // if we have a known parent window set, let's use it when alerting the user.
            if (parent != null)
            {
                System.Windows.MessageBox.Show(parent, text, title, buttons, image);
            }
            else
            {
                System.Windows.MessageBox.Show(text, title, buttons, image);
            }
        }
        /// <summary>
        /// A helper method to do the necessary work to display a standard MessageBox.  This method performs
        /// and necessary elevations to make the dialog work as well.
        /// </summary>
        internal
        static
        void
        ShowMessageBoxHelper(
            IntPtr parentHwnd,
            string text,
            string title,
            System.Windows.MessageBoxButton buttons,
            System.Windows.MessageBoxImage image
            )
        {
            // NOTE: the last param must always be MessageBoxOptions.None for this to be considered TreatAsSafe
            System.Windows.MessageBox.ShowCore(parentHwnd, text, title, buttons, image, MessageBoxResult.None, MessageBoxOptions.None);
        }

        internal static bool AreStringTypesEqual(string m1, string m2)
        {
            return (string.Equals(m1, m2, StringComparison.OrdinalIgnoreCase));
        }
    }
}
