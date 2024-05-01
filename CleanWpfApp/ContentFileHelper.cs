using System.Reflection;
using System.Windows.Resources;

namespace CleanWpfApp
{
    // <summary>
    //  ContentFileHelper class provides helper method to get assembly 
    //  associated content files.
    // </summary>
    internal static class ContentFileHelper
    {
        internal static bool IsContentFile(string partName)
        {
            _contentFiles ??= GetContentFiles(BaseUriHelper.ResourceAssembly);

            if (_contentFiles != null && _contentFiles.Count > 0)
            {
                if (_contentFiles.Contains(partName))
                {
                    return true;
                }
            }

            return false;
        }

        //
        // Get a list of Content Files for a given Assembly.
        //
        static internal HashSet<string>? GetContentFiles(Assembly asm)
        {
            if (asm == null)
            {
                asm = BaseUriHelper.ResourceAssembly;
                if (asm == null)
                {
                    // If we have no entry assembly return an empty list because
                    // we can't have any content files.
                    return [];
                }
            }

            var assemblyAttributes = Attribute.GetCustomAttributes(
                                   asm,
                                   typeof(AssemblyAssociatedContentFileAttribute));

            HashSet<string>? contentFiles = null;
            if (assemblyAttributes != null && assemblyAttributes.Length > 0)
            {
                contentFiles = new HashSet<string>(assemblyAttributes.Length, StringComparer.OrdinalIgnoreCase);

                for (var i = 0; i < assemblyAttributes.Length; i++)
                {
                    AssemblyAssociatedContentFileAttribute aacf;

                    aacf = (AssemblyAssociatedContentFileAttribute)assemblyAttributes[i];
                    contentFiles.Add(aacf.RelativeContentFilePath);
                }
            }

            return contentFiles;
        }

        private static HashSet<string> _contentFiles;
    }
}
