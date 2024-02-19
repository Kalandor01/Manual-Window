// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/***************************************************************************\
*
* Purpose:  Class for compiling Xaml.
*
\***************************************************************************/


using System.Globalization;
using System.Windows.Markup;


namespace CleanWpfApp
{
    #region enums
    /// <summary>
    /// Parser modes. indicates if the Xaml should be parsed sync or async.
    /// currently public so test can set these values.
    /// </summary>
    internal enum XamlParseMode
    {
        /// <summary>
        /// Not initialized
        /// </summary>
        Uninitialized,

        /// <summary>
        /// Sync
        /// </summary>
        Synchronous,

        /// <summary>
        /// Async
        /// </summary>
        Asynchronous,
    }
    #endregion enums

    /// <summary>
    /// XamlParser class. This class is used internally
    /// </summary>
    internal class XamlParser
    {
        // helper method called to throw an exception.
        internal static void ThrowException(string id, int lineNumber, int linePosition)
        {
            string message = SR.GetResourceString(id);
            ThrowExceptionWithLine(message, lineNumber, linePosition);
        }

        // helper method called to throw an exception.
        internal static void ThrowException(string id, string value, int lineNumber, int linePosition)
        {
            string message = SR.Format(SR.GetResourceString(id), value);
            ThrowExceptionWithLine(message, lineNumber, linePosition);
        }

        // helper method called to throw an exception.
        internal static void ThrowException(string id, string value1, string value2, int lineNumber, int linePosition)
        {
            string message = SR.Format(SR.GetResourceString(id), value1, value2);
            ThrowExceptionWithLine(message, lineNumber, linePosition);
        }

        internal static void ThrowException(string id, string value1, string value2, string value3, int lineNumber, int linePosition)
        {
            string message = SR.Format(SR.GetResourceString(id), value1, value2, value3);
            ThrowExceptionWithLine(message, lineNumber, linePosition);
        }

        internal static void ThrowException(string id, string value1, string value2, string value3, string value4, int lineNumber, int linePosition)
        {
            string message = SR.Format(SR.GetResourceString(id), value1, value2, value3, value4);
            ThrowExceptionWithLine(message, lineNumber, linePosition);
        }

        private static void ThrowExceptionWithLine(string message, int lineNumber, int linePosition)
        {
            message += " ";
            message += SR.Format(Strings.ParserLineAndOffset,
                                    lineNumber.ToString(CultureInfo.CurrentCulture),
                                    linePosition.ToString(CultureInfo.CurrentCulture));

            var parseException = new XamlParseException(
                message,
                lineNumber,
                linePosition
            );


            throw parseException;
        }
    }
}
