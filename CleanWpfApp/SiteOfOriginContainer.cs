using System.Diagnostics;
using System.IO;
using System.IO.Packaging;

namespace CleanWpfApp
{
    /// <summary>
    /// SiteOfOriginContainer is an implementation of the abstract Package class. 
    /// It contains nontrivial overrides for GetPartCore and Exists.
    /// Many of the methods on Package are not applicable to loading files 
    /// so the SiteOfOriginContainer implementations of these methods throw 
    /// the NotSupportedException.
    /// </summary>
    internal class SiteOfOriginContainer : Package
    {
        #region Static Methods
        internal static Uri SiteOfOrigin
        {
            [FriendAccessAllowed]
            get
            {
                // Calling FixFileUri because BaseDirectory will be a c:\\ style path
                var siteOfOrigin = SiteOfOriginForClickOnceApp ?? BaseUriHelper.FixFileUri(new Uri(AppDomain.CurrentDomain.BaseDirectory));
#if DEBUG
                if (_traceSwitch.Enabled)
                    Trace.TraceInformation(
                            DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                            Environment.CurrentManagedThreadId +
                            ": SiteOfOriginContainer: returning site of origin " + siteOfOrigin);
#endif

                return siteOfOrigin;
            }
        }

        // we separated this from the rest of the code because this code is used for media permission
        // tests in partial trust but we want to do this without hitting the code path for regular exe's
        // as in the code above. This will get hit for click once apps, xbaps, xaml and xps
        internal static Uri SiteOfOriginForClickOnceApp
        {
            get
            {
                // The ClickOnce API, ApplicationDeployment.IsNetworkDeployed, determines whether the app is network-deployed
                // by getting the ApplicationDeployment.CurrentDeployment property and catch the exception it can throw.
                // The exception is a first chance exception and caught, but it often confuses developers,
                // and can also have a perf impact. So we change to cache the value of SiteofOrigin in Dev10 to avoid the 
                // exception being thrown too many times.
                // An alternative is to cache the value of ApplicationDeployment.IsNetworkDeployed.
                _siteOfOriginForClickOnceApp ??= new SecurityCriticalDataForSet<Uri>(null);

                Invariant.Assert(_siteOfOriginForClickOnceApp != null);

                return _siteOfOriginForClickOnceApp.Value.Value;
            }
        }

        internal static Uri BrowserSource
        {
            get
            {
                return _browserSource.Value;
            }
            set
            {
                _browserSource.Value = value;
            }
        }
        #endregion

        #region Public Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        internal SiteOfOriginContainer()
            : base(FileAccess.Read)
        {

        }
        #endregion

        #region Public Methods
        /// <remarks>
        /// If this were to be implemented for http site of origin, 
        /// it will require a server round trip.
        /// </remarks>
        /// <param name="uri"></param>
        /// <returns></returns>
        public override bool PartExists(Uri uri)
        {
            return true;
        }
        #endregion

        #region Internal Properties
        internal static bool TraceSwitchEnabled
        {
            get
            {
                return _traceSwitch.Enabled;
            }
            set
            {
                _traceSwitch.Enabled = value;
            }
        }

        internal static BooleanSwitch _traceSwitch =
            new("SiteOfOrigin", "SiteOfOriginContainer and SiteOfOriginPart trace messages");
        #endregion

        #region Protected Methods
        /// <summary>
        /// This method creates a SiteOfOriginPart which will create a WebRequest
        /// to access files at the site of origin.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected override PackagePart GetPartCore(Uri uri)
        {
#if DEBUG
            if (_traceSwitch.Enabled)
                Trace.TraceInformation(
                        DateTime.Now.ToLongTimeString() + " " + DateTime.Now.Millisecond + " " +
                        Environment.CurrentManagedThreadId +
                        ": SiteOfOriginContainer: Creating SiteOfOriginPart for Uri " + uri);
#endif
            return new SiteOfOriginPart(this, uri);
        }
        #endregion

        #region Private Members
        private static SecurityCriticalDataForSet<Uri> _browserSource;
        private static SecurityCriticalDataForSet<Uri>? _siteOfOriginForClickOnceApp;
        #endregion

        #region Uninteresting (but required) overrides
        protected override PackagePart CreatePartCore(Uri uri, string contentType, CompressionOption compressionOption)
        {
            return null;
        }

        protected override void DeletePartCore(Uri uri)
        {
            throw new NotSupportedException();
        }

        protected override PackagePart[] GetPartsCore()
        {
            throw new NotSupportedException();
        }

        protected override void FlushCore()
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
