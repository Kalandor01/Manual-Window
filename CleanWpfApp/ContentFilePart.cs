using System.IO;
using System.IO.Packaging;

namespace CleanWpfApp
{
    /// <summary>
    /// ContentFilePart is an implementation of the abstract PackagePart class. It contains an override for GetStreamCore.
    /// </summary>
    internal class ContentFilePart : PackagePart
    {
        #region Public Constructors
        internal ContentFilePart(Package container, Uri uri) :
                base(container, uri)
        {
            Invariant.Assert(Application.ResourceAssembly != null, "If the entry assembly is null no ContentFileParts should be created");
            _fullPath = null;
        }
        #endregion

        #region Protected Methods
        protected override Stream GetStreamCore(FileMode mode, FileAccess access)
        {
            Stream stream = null;

            if (_fullPath == null)
            {
                // File name will be a path relative to the applications directory.
                // - We do not want to use SiteOfOriginContainer.SiteOfOrigin because
                //   for deployed files the <Content> files are deployed with the application.
                string location = GetEntryAssemblyLocation();

                // For now, only Application assembly supports content files, 
                // so we can simply ignore the assemblyname etc.
                // In the future, we may extend this support for regular library assembly,
                // assemblyName will be used to predict the right file path.

                BaseUriHelper.GetAssemblyNameAndPart(Uri, out var filePath, out var assemblyName, out var assemblyVersion, out var assemblyKey);

                // filePath should not have leading slash.  GetAssemblyNameAndPart( ) can guarantee it.
                _fullPath = Path.Combine(Path.GetDirectoryName(location), filePath);
            }

            stream = CriticalOpenFile(_fullPath);

            if (stream == null)
            {
                throw new IOException(SR.Format(Strings.UnableToLocateResource, Uri.ToString()));
            }

            return stream;
        }

        protected override string GetContentTypeCore()
        {
            return MimeTypeMapper.GetMimeTypeFromUri(new Uri(Uri.ToString(), UriKind.RelativeOrAbsolute)).ToString();
        }
        #endregion

        #region Private Methods
        private string GetEntryAssemblyLocation()
        {
            string entryLocation = null;

            try
            {
                entryLocation = Application.ResourceAssembly.Location;
            }
            catch (Exception ex)
            {
                if (CriticalExceptions.IsCriticalException(ex))
                {
                    throw;
                }
                // `Swallow any other exceptions to avoid disclosing the critical path.
                // 
                // Possible Exceptions: ArgumentException, ArgumentNullException, PathTooLongException
                // DirectoryNotFoundException, IOException, UnauthorizedAccessException, 
                // ArgumentOutOfRangeException, FileNotFoundException, NotSupportedException
            }

            return entryLocation;
        }

        private Stream CriticalOpenFile(string filename)
        {
            return File.Open(filename, FileMode.Open, FileAccess.Read, ResourceContainer.FileShare);
        }
        #endregion

        #region Private Members
        private string _fullPath;
        #endregion
    }
}
