using System.Resources;
using System.Runtime.CompilerServices;

namespace CleanWpfApp
{
    internal class SR
    {
        // Expose ResourceManager instance to allow PresentationBuildTask MSBuild tasks
        // that derive from Task to pass ResourceManager to their base class constructor.
        // (Generated SR.common.cs always defines ResourceManager as private. GenerateCommonSRSource
        // target should be updated to accept a parameter for ResourceManager property access 
        // modifier.)
        public static ResourceManager SharedResourceManager
        {
            get
            {
                return ResourceManager;
            }
        }

        // This method is used to decide if we need to append the exception message parameters to the message when calling SR.Format.
        // by default it returns false.
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool UsingResourceKeys()
        {
            return false;
        }

        internal static string GetResourceString(string resourceKey)
        {
            string resourceString = null;
            try
            {
                resourceString = ResourceManager.GetString(resourceKey);
            }
            catch (MissingManifestResourceException) { }

            return resourceString;
        }

        internal static string GetResourceString(string resourceKey, string defaultString)
        {
            string resourceString = GetResourceString(resourceKey);

            if (defaultString != null && resourceKey.Equals(resourceString, StringComparison.Ordinal))
            {
                return defaultString;
            }

            return resourceString;
        }

        internal static string Format(string resourceFormat, params object[] args)
        {
            if (args != null)
            {
                if (UsingResourceKeys())
                {
                    return resourceFormat + string.Join(", ", args);
                }

                return string.Format(resourceFormat, args);
            }

            return resourceFormat;
        }

        internal static string Format(string resourceFormat, object p1)
        {
            if (UsingResourceKeys())
            {
                return string.Join(", ", resourceFormat, p1);
            }

            return string.Format(resourceFormat, p1);
        }

        internal static string Format(string resourceFormat, object p1, object p2)
        {
            if (UsingResourceKeys())
            {
                return string.Join(", ", resourceFormat, p1, p2);
            }

            return string.Format(resourceFormat, p1, p2);
        }

        internal static string Format(string resourceFormat, object p1, object p2, object p3)
        {
            if (UsingResourceKeys())
            {
                return string.Join(", ", resourceFormat, p1, p2, p3);
            }

            return string.Format(resourceFormat, p1, p2, p3);
        }

        public static string Get(string name)
        {
            return GetResourceString(name, null);
        }

        public static string Get(string name, params object[] args)
        {
            return Format(GetResourceString(name, null), args);
        }
    }
}
