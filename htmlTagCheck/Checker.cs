using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace htmlTagCheck
{
    internal class Checker
    {
        public static string regex = "<([A-Z])>|<(/[A-Z])>";
        public static string openTag = "<([A-Z])>";
        public static string TagChecker(string htmlTag)
        {

            List<char> OpenTags = new();
            MatchCollection matches = Regex.Matches(htmlTag, regex);
            foreach (Match item in matches)
            {
                if (Regex.Match(item.Value, openTag).Success)
                {
                    OpenTags.Add(item.Value[1]);
                }
                else
                {
                    char closedTag= item.Value[2];
                    if (!OpenTags.Any())
                    {
                        return "Expected # found " + item.Value;
                    }
                    char openTag = OpenTags[OpenTags.Count - 1];
                    if (closedTag.Equals(openTag))
                    {
                        OpenTags.RemoveAt(OpenTags.Count - 1);
                    }
                    else
                    {
                        return "Expected </" + openTag + "> found " + item.Value;
                    }
                }
            }
            if (OpenTags.Any())
            {
                return "Expected </" + OpenTags[^1] + "> found #";
            }
            else
            {
                return "Correctly tagged paragraph";
            }
        }
    }

}
