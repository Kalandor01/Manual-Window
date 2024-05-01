using System.IO;
using System.IO.Packaging;
using System.Net;

namespace CleanWpfApp
{
    /// <summary>
    /// SiteOfOriginPart is an implementation of the abstract PackagePart class. It contains an override for GetStreamCore.
    /// </summary>
    internal class SiteOfOriginPart : PackagePart
    {
        #region Public Constructors
        internal SiteOfOriginPart(Package container, Uri uri)
            :base(container, uri)
        {

        }
        #endregion

        #region Protected Methods
        protected override Stream GetStreamCore(FileMode mode, FileAccess access)
        {
#if DEBUG
            if (SiteOfOriginContainer._traceSwitch.Enabled)
                System.Diagnostics.Trace.TraceInformation(
                        DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                        Environment.CurrentManagedThreadId +
                        ": SiteOfOriginPart: Getting stream.");
#endif
            return GetStreamAndSetContentType(false);
        }

        protected override string GetContentTypeCore()
        {
#if DEBUG
            if (SiteOfOriginContainer._traceSwitch.Enabled)
                System.Diagnostics.Trace.TraceInformation(
                        DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                        Environment.CurrentManagedThreadId +
                        ": SiteOfOriginPart: Getting content type.");
#endif

            GetStreamAndSetContentType(true);
            return _contentType.ToString();
        }
        #endregion

        #region Private Methods
        private Stream GetStreamAndSetContentType(bool onlyNeedContentType)
        {
            lock (_globalLock)
            {
                if (onlyNeedContentType && _contentType != CleanWpfApp.ContentType.Empty)
                {
#if DEBUG
                    if (SiteOfOriginContainer._traceSwitch.Enabled)
                        System.Diagnostics.Trace.TraceInformation(
                                DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                                Environment.CurrentManagedThreadId +
                                ": SiteOfOriginPart: Getting content type and using previously determined value");
#endif
                    return null;
                }

                // If GetContentTypeCore is called before GetStream() 
                // then we need to retrieve the stream to get the mime type.
                // That stream is then stored as _cacheStream and returned
                // the next time GetStreamCore() is called.
                if (_cacheStream != null)
                {
#if DEBUG
                    if (SiteOfOriginContainer._traceSwitch.Enabled)
                        System.Diagnostics.Trace.TraceInformation(
                                DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                                Environment.CurrentManagedThreadId +
                                "SiteOfOriginPart: Using Cached stream");
#endif
                    Stream temp = _cacheStream;
                    _cacheStream = null;
                    return temp;
                }

                if (_absoluteLocation == null)
                {
#if DEBUG
                    if (SiteOfOriginContainer._traceSwitch.Enabled)
                        System.Diagnostics.Trace.TraceInformation(
                                DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                                Environment.CurrentManagedThreadId +
                                ": SiteOfOriginPart: Determining absolute uri for this resource");
#endif
                    string original = Uri.ToString();
                    Invariant.Assert(original[0] == '/');
                    string uriMinusInitialSlash = original.Substring(1); // trim leading '/'
                    _absoluteLocation = new Uri(SiteOfOriginContainer.SiteOfOrigin, uriMinusInitialSlash);
                }

#if DEBUG
                if (SiteOfOriginContainer._traceSwitch.Enabled)
                    System.Diagnostics.Trace.TraceInformation(
                            DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                            Environment.CurrentManagedThreadId +
                            ": SiteOfOriginPart: Making web request to " + _absoluteLocation);
#endif

                // For performance reasons it is better to open local files directly
                // rather than make a FileWebRequest.
                Stream responseStream;
                if (SecurityHelper.AreStringTypesEqual(_absoluteLocation.Scheme, Uri.UriSchemeFile))
                {
                    responseStream = HandleFileSource(onlyNeedContentType);
                }
                else
                {
                    responseStream = HandleWebSource(onlyNeedContentType);
                }

                return responseStream;
            }
        }

        private Stream HandleFileSource(bool onlyNeedContentType)
        {
#if DEBUG
            if (SiteOfOriginContainer._traceSwitch.Enabled)
                System.Diagnostics.Trace.TraceInformation(
                        DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                        Environment.CurrentManagedThreadId +
                        ": Opening local file " + _absoluteLocation);
#endif
            if (_contentType == CleanWpfApp.ContentType.Empty)
            {
                _contentType = MimeTypeMapper.GetMimeTypeFromUri(Uri);
            }

            if (!onlyNeedContentType)
            {
                return File.OpenRead(_absoluteLocation.LocalPath);
            }
            return null;
        }

        private Stream HandleWebSource(bool onlyNeedContentType)
        {
            WebResponse response = WpfWebRequestHelper.CreateRequestAndGetResponse(_absoluteLocation);
            Stream responseStream = response.GetResponseStream();

#if DEBUG
            if (SiteOfOriginContainer._traceSwitch.Enabled)
                System.Diagnostics.Trace.TraceInformation(
                        DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                        Environment.CurrentManagedThreadId +
                        ": Successfully retrieved stream from " + _absoluteLocation);
#endif

            if (_contentType == CleanWpfApp.ContentType.Empty)
            {
#if DEBUG
                if (SiteOfOriginContainer._traceSwitch.Enabled)
                    System.Diagnostics.Trace.TraceInformation(
                            DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                            Environment.CurrentManagedThreadId +
                            ": SiteOfOriginPart: Setting _contentType");
#endif                    

                _contentType = WpfWebRequestHelper.GetContentType(response);
            }

            if (onlyNeedContentType)
            {
                _cacheStream = responseStream;
            }

            return responseStream;
        }
        #endregion

        #region Private Members
        Uri _absoluteLocation = null;
        ContentType _contentType = CleanWpfApp.ContentType.Empty;
        Stream _cacheStream = null;
        private object _globalLock = new();
        #endregion
    }
}
