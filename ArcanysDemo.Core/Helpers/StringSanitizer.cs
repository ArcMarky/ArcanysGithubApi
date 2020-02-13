using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ArcanysDemo.Core.Helpers
{
    public class StringSanitizer
    {
        /// <summary>
        /// Lowers and trims the string, null value safe.
        /// </summary>
        /// <param name="model">string model to be trimmed</param>
        /// <returns>lowered and trimmed string</returns>
        public static string ToLowerAndTrim(string model)
        {
            if (!string.IsNullOrEmpty(model))
            {
                return model.Trim().ToLower();
            }
            return "";
        }

        /// <summary>
        ///  Sanitizes the input string based on githubs policy.
        ///  Github username may only contain alphanumeric characters or hyphens.
        ///  Github username cannot have multiple consecutive hyphens.
        ///  Github username cannot begin or end with a hyphen.
        ///  Maximum is 39 characters.
        /// </summary>
        /// <param name="model">List of strings to be sanitized</param>
        /// <returns>sanitized strings</returns>
        public static List<string> SanitizeStringListByGitHubPolicy(List<string> model)
        {
            Regex regex = new Regex(@"^[a-z\d](?:[a-z\d]|-(?=[a-z\d])){0,38}$");
            return model.Where(x => !string.IsNullOrEmpty(x) && regex.IsMatch(x)).ToList();
        }
    }
}
