// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


//
//  Description:    BindUriHelper class. Allows bindToObject, bindToStream
//

using System;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using MS.Win32;

using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using MS.Internal.PresentationFramework;
using MS.Internal.AppModel;
using System.Windows.Controls;
using MS.Internal ; 
using System.Security; 
using System.IO.Packaging; 
using System.Reflection;
using MS.Internal.Utility;
using System.Net;
using System;
using System.Net.Cache; // HttpRequestCachePolicy
using MS.Win32;
using MS.Internal.PresentationBuildTasks; // SecurityHelper
using MS.Internal.ReachFramework; // SecurityHelper
using MS.Internal.PresentationCore;

// In order to avoid generating warnings about unknown message numbers and 
// unknown pragmas when compiling your C# source code with the actual C# compiler, 
// you need to disable warnings 1634 and 1691. (Presharp Documentation)


namespace CleanWpfApp
{
    // A BindUriHelper class
    // See also WpfWebRequestHelper.
    internal  static partial  class BindUriHelper
    {
        private const string PLACEBOURI = "http://microsoft.com/";
        static private Uri placeboBase = new Uri(PLACEBOURI);
        private const string FRAGMENTMARKER = "#";

        private const int MAX_PATH_LENGTH = 2048;
        private const int MAX_SCHEME_LENGTH = 32;
        public const int MAX_URL_LENGTH = MAX_PATH_LENGTH + MAX_SCHEME_LENGTH + 3; /*=sizeof("://")*/

        static internal Uri GetResolvedUri(Uri originalUri)
        {
            return GetResolvedUri(null, originalUri);
        }                
       
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///     Relative Uri resolution logic
        ///     
        ///     if baseUriString != ""
        ///     {
        ///         if (baseUriString is absolute uri)
        ///         {
        ///             determine uriToNavigate as baseUriString + inputUri
        ///         }
        ///         else
        ///         {
        ///             determine uri to navigate wrt application's base uri + baseUriString + inputUri
        ///         }
        ///     }
        ///     else
        ///     {
        ///         Get the element's NavigationService 
        ///         if(NavigationService.CurrentSource is absolute uri)
        ///         {
        ///             determine uriToNavigate as NavigationService.CurrentSource + inputUri
        ///         }
        ///         else // this will be more common
        ///         {
        ///             determine uriToNavigate wrt application's base uri (pack://application,,,/) + NavigationService.CurrentSource + inputUri
        ///         }
        ///             
        ///         
        ///         If no ns in tree, resolve against the application's base
        ///     }
        /// </remarks>
        /// <param name="element"></param>
        /// <param name="baseUri"></param>
        /// <param name="inputUri"></param>
        /// <returns></returns>
        static internal Uri GetUriToNavigate(DependencyObject element, Uri baseUri, Uri inputUri)
        {
            Uri uriToNavigate = inputUri;

            if ((inputUri == null) || (inputUri.IsAbsoluteUri == true))
            {
                return uriToNavigate;
            }

            // BaseUri doesn't contain the last part of the path: filename,
            // so when the inputUri is fragment we cannot resolve with BaseUri, instead 
            // we should resolve with the element's NavigationService's CurrentSource.            
            if (StartWithFragment(inputUri))
            {
                baseUri = null;
            }

            if (baseUri != null)
            {
                if (baseUri.IsAbsoluteUri == false)
                {
                    uriToNavigate = GetResolvedUri(BindUriHelper.GetResolvedUri(null, baseUri), inputUri);
                }
                else
                {
                    uriToNavigate = GetResolvedUri(baseUri, inputUri);
                }
            }
            else // we're in here when baseUri is not set i.e. it's null 
            {
                Uri currentSource = null;                                               

                // if the it is an INavigator (Frame, NavWin), we should use its CurrentSource property.
                // Otherwise we need to get NavigationService of the container that this element is hosted in,
                // and use its CurrentSource.
                if (element != null)
                {
                    INavigator navigator = element as INavigator;
                    if (navigator != null)
                    {
                        currentSource = navigator.CurrentSource;
                    }
                    else
                    {
                        NavigationService ns = null;
                        ns = element.GetValue(NavigationService.NavigationServiceProperty) as NavigationService;
                        currentSource = (ns == null) ? null : ns.CurrentSource;
                    }
                }

                if (currentSource != null)
                {
                    if (currentSource.IsAbsoluteUri)
                    {
                        uriToNavigate = GetResolvedUri(currentSource, inputUri);
                    }
                    else
                    {
                        uriToNavigate = GetResolvedUri(GetResolvedUri(null, currentSource), inputUri);
                    }
                }
                else
                {
                    // For now we resolve to Application's base
                    uriToNavigate = BindUriHelper.GetResolvedUri(null, inputUri);
                }
            }
            return uriToNavigate;
        }

        static internal bool StartWithFragment(Uri uri)
        {
            return uri.OriginalString.StartsWith(FRAGMENTMARKER, StringComparison.Ordinal);
        }

        // Return Fragment string for a given uri without the leading #
        static internal string GetFragment(Uri uri)
        {
            Uri workuri = uri;
            string fragment = String.Empty;
            string frag;

            if (uri.IsAbsoluteUri == false)
            {
                // this is a relative uri, and Fragement() doesn't work with relative uris.  The base uri is completley irrelevant 
                // here and will never affect the returned fragment, but the method requires something to be there.  Therefore, 
                // we will use "http://microsoft.com" as a convenient substitute.
                workuri = new Uri(placeboBase, uri);
            }

            frag = workuri.Fragment;
            if (frag != null && frag.Length > 0)
            {
                // take off the pound
                fragment = frag.Substring(1);
            }

            return fragment;
        }
        
        // In NavigationService we do not want to show users pack://application,,,/ with the
        // Source property or any event arguments.
        static internal Uri GetUriRelativeToPackAppBase(Uri original)
        {
            if (original == null)
            {
                return null;
            }

            Uri resolved = GetResolvedUri(original);
            Uri packUri = BaseUriHelper.PackAppBaseUri;
            Uri relative = packUri.MakeRelativeUri(resolved);
            
            return relative;
        }

        static internal bool IsXamlMimeType(ContentType mimeType)
        {
            if (MimeTypeMapper.XamlMime.AreTypeAndSubTypeEqual(mimeType)
                || MimeTypeMapper.FixedDocumentSequenceMime.AreTypeAndSubTypeEqual(mimeType) 
                || MimeTypeMapper.FixedDocumentMime.AreTypeAndSubTypeEqual(mimeType)
                || MimeTypeMapper.FixedPageMime.AreTypeAndSubTypeEqual(mimeType))
            {
                return true;
            }

            return false;
        }

        //
        // Uri-toString does 3 things over the standard .toString()
        //
        //  1) We don't unescape special control characters. The default Uri.ToString() 
        //     will unescape a character like ctrl-g, or ctrl-h so the actual char is emitted. 
        //     However it's considered safer to emit the escaped version. 
        //
        //  2) We truncate urls so that they are always <= MAX_URL_LENGTH
        // 
        // This method should be called whenever you are taking a Uri
        // and performing a p-invoke on it. 
        //
        internal static string UriToString(Uri uri)
        {
            ArgumentNullException.ThrowIfNull(uri);

            return new StringBuilder(
                uri.GetComponents(
                    uri.IsAbsoluteUri ? UriComponents.AbsoluteUri : UriComponents.SerializationInfoString,
                    UriFormat.SafeUnescaped),
                MAX_URL_LENGTH).ToString();
        }

        // Base Uri.
        static internal Uri BaseUri
        {
            get
            {
                return BaseUriHelper.BaseUri;
            }
            set
            {
                BaseUriHelper.BaseUri = BaseUriHelper.FixFileUri(value);
            }
        }

        static internal bool DoSchemeAndHostMatch(Uri first, Uri second)
        {
            // Check that both the scheme and the host match. 
            return (SecurityHelper.AreStringTypesEqual(first.Scheme, second.Scheme) && first.Host.Equals(second.Host) == true);
        }

        static internal Uri GetResolvedUri(Uri baseUri, Uri orgUri)
        {
            Uri newUri;

            if (orgUri == null)
            {
                newUri = null;
            }
            else if (orgUri.IsAbsoluteUri == false)
            {
                // if the orgUri is an absolute Uri, don't need to resolve it again.

                Uri baseuri = (baseUri == null) ? BindUriHelper.BaseUri : baseUri;

                newUri = new Uri(baseuri, orgUri);
            }
            else
            {
                newUri = BaseUriHelper.FixFileUri(orgUri);
            }

            return newUri;
        }

        /// <summary>
        /// Gets the referer to set as a header on the HTTP request.
        /// We do not set the referer if we are navigating to a 
        /// differnet security zone or to a different Uri scheme.
        /// </summary>
        internal static string GetReferer(Uri destinationUri)
        {
            string referer = null;

            Uri sourceUri = MS.Internal.AppModel.SiteOfOriginContainer.BrowserSource;
            if (sourceUri != null)
            {
                int sourceZone = MS.Internal.AppModel.CustomCredentialPolicy.MapUrlToZone(sourceUri);
                int targetZone = MS.Internal.AppModel.CustomCredentialPolicy.MapUrlToZone(destinationUri);

                // We don't send any referer when crossing zone
                if (sourceZone == targetZone)
                {
                    // We don't send any referer when going cross-scheme
                    if (SecurityHelper.AreStringTypesEqual(sourceUri.Scheme, destinationUri.Scheme))
                    {
                        // HTTPHeader requires the referer uri to be escaped. 
                        referer = sourceUri.GetComponents(UriComponents.AbsoluteUri, UriFormat.UriEscaped);
                    }
                }
            }

            return referer;
        }
    }
}
