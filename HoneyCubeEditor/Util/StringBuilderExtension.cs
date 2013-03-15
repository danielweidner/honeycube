#region Using Statements

using System.Text;

#endregion

namespace HoneyCube.Editor.Util
{
    /// <summary>
    /// Extends the StringBuilder class.
    /// </summary>
    public static class StringBuilderExtension
    {
        /// <summary>
        /// Implements an IndexOf method for StringBuilder instances. Allows to search 
        /// for the position of a substring within the current string builder instance.
        /// </summary>
        /// <param name="sb">The current StringBuilder instance.</param>
        /// <param name="substr">The substring to search for.</param>
        /// <returns>The index of the string within the StringBuilder. -1 if not found.</returns>
        public static int IndexOf(this StringBuilder sb, string substr)
        {
            return sb.IndexOf(substr, 0);
        }

        /// <summary>
        ///  Implements an IndexOf method for StringBuilder instances. Allows to search 
        /// for the position of a substring within the current string builder instance.
        /// </summary>
        /// <param name="sb">The current StringBuilder instance.</param>
        /// <param name="substr">The substring to search for.</param>
        /// <param name="startIndex">The index to start searching from.</param>
        /// <returns>The index of the string within the StringBuilder. -1 if not found.</returns>
        public static int IndexOf(this StringBuilder sb, string substr, int startIndex)
        {
            char firstLetter = substr[0];
            int substrLength = substr.Length;

            for (int i = startIndex, sbLength = sb.Length; i < sbLength; i++)
            {
                if (sb[i].Equals(firstLetter))
                {
                    // Check for all other characters of the substring
                    int j = 1;
                    while(j < substrLength && sb[i + j] == substr[j])
                        j++;

                    // Check whether we were able to find all characters of the substr
                    if (j == substrLength)
                        return i;
                }
            }

            return -1;
        }
    }
}
