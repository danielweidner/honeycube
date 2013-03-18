#region Using Statements

using System.Globalization;
using System.IO;
using System.Reflection;

#endregion

namespace HoneyCube.Editor.Util
{
    /// <summary>
    /// Extends the Assembly class of the mscorlib Assembly.
    /// </summary>
    public static class AssemblyExtension
    {
        /// <summary>
        /// GetSatelliteAssembly throws a FileNotFoundException if an 
        /// assembly for the specified culture does not exist. This 
        /// method tries to bypass this limitation. It returns true if
        /// an assembly exists and returns the satellite assembly via
        /// the output parameter.
        /// </summary>
        /// <param name="assembly">The assembly instance to extend.</param>
        /// <param name="culture">The culture to retrieve the sateliite assembly for.</param>
        /// <param name="satelliteAssembly">The satellite assembly for the given culture. Null if not found.</param>
        /// <returns></returns>
        public static bool TryGetSatelliteAssembly(this Assembly assembly, CultureInfo culture, out Assembly satelliteAssembly)
        {
            try
            {
                satelliteAssembly = assembly.GetSatelliteAssembly(culture);
                return true;
            }
            catch (FileNotFoundException)
            {
                satelliteAssembly = null;
                return false;
            }
        }

        /// <summary>
        /// Checks whether the current assembly contains the specified 
        /// resource file.
        /// </summary>
        /// <param name="assembly">The assembly instance to extend.</param>
        /// <param name="resource">The full qualified name of the resource file to check for.</param>
        /// <returns>Returns true if the assembly has embedded the specified resource file.</returns>
        public static bool ContainsResource(this Assembly assembly, string resource)
        {
            return assembly.ContainsResource(resource, null);
        }

        /// <summary>
        /// Checks whether the current assembly contains a localized resource 
        /// file for the specified culture.
        /// </summary>
        /// <param name="assembly">The assembly instance to extend.</param>
        /// <param name="resource">The full qualified name of resource file to check.</param>
        /// <param name="culture">The culture information to use.</param>
        /// <returns>Returns true if the assembly has embedded a localized version of the specified resource file.</returns>
        public static bool ContainsResource(this Assembly assembly, string resource, CultureInfo culture)
        {
            // Convert the full resource path to its the binary name
            resource = resource + (culture != null ? "." + culture.Name : "") + ".resources";

            foreach (string r in assembly.GetManifestResourceNames())
                if (r == resource)
                    return true;

            return false;
        }
    }
}
