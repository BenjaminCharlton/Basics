using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Basics.Enumerations;
using Microsoft.Extensions.Localization;

namespace Basics.Text
{
    public static class StringExtension
    {
        public static string AppendIfRequired(this string instance, string appendation)
        {
            return instance.AppendIfRequired(String.Empty, appendation);
        }


        public static string Localize(this string instance, IStringLocalizer localizer)
        {
            return localizer == null ? instance : localizer[instance];
        }


        public static string Localize(this string instance, IStringLocalizer localizer, params object[] args)
        {
            return localizer == null ? string.Format(instance, args) : localizer[instance, args];
        }


        public static string AppendIfRequired(this string instance, string separator, string appendation)
        {
            string result = instance ?? String.Empty;
            appendation = appendation ?? String.Empty;
            separator = separator ?? String.Empty;

            if (appendation != String.Empty)
            {
                if (result.EndsWith(separator) || appendation.StartsWith(separator) || result == String.Empty)
                {
                    result += appendation;
                }
                else
                {
                    result += separator + appendation;
                }
            }

            return result;
        }

        public static string PrependIfRequired(this string instance, string prependation)
        {
            return instance.PrependIfRequired(prependation, String.Empty);
        }


        public static string PrependIfRequired(this string instance, string prependation, string separator)
        {
            string result = instance ?? String.Empty;
            prependation = prependation ?? String.Empty;
            separator = separator ?? String.Empty;

            if (prependation != String.Empty)
            {
                if (result.EndsWith(separator) || prependation.StartsWith(separator) || result == String.Empty)
                {
                    result = prependation + result;
                }
                else
                {
                    result = prependation + separator + result;
                }
            }

            return result;
        }


        public static string ToCase(this string instance, Capitalization capitalization)
        {
            if (instance.IsNullOrDefault())
                return String.Empty;

            switch (capitalization)
            {
                case Capitalization.Lowercase:
                    return instance.ToLowerInvariant();
                case Capitalization.Uppercase:
                    return instance.ToUpperInvariant();
                case Capitalization.TitleCase:
                    return instance.ToTitleCase();
                case Capitalization.TitleCaseExceptConjunctions:
                    return instance.ToTitleCase(true);
                case Capitalization.SentenceCase:
                    return instance.ToSentenceCase();
                default:
                    return instance;
            }
        }

        public static string ToTitleCase(this string instance, bool lowerCaseConjunctions = false)
        {
            if (instance.IsNullOrDefault())
                return String.Empty;

            if (instance.IsAllSameCase())
                instance = instance.ToLowerInvariant();

            var result = Regex.Replace(instance, @"\b(\w)", m => m.Value.ToUpper());

            if(lowerCaseConjunctions)
                result = Regex.Replace(result, @"(\s(of|in|by|and)|\'[st])\b",
                    m => m.Value.ToLower(), RegexOptions.IgnoreCase);

            return result;
        }

        public static bool IsAllSameCase(this string instance)
        {
            if (instance.IsNullOrDefault())
                return true;

            return (instance == instance.ToUpperInvariant() || instance == instance.ToLowerInvariant());
        }

        public static string ToSentenceCase(this string instance)
        {
            if (instance.IsNullOrDefault())
                return String.Empty;

            if (instance.IsAllSameCase())
                instance = instance.ToLowerInvariant();

            return Regex.Replace(instance, @"(?<=(^|[.;:])\s*)[a-z]",
                (match) => match.Value.ToUpper());
        }
    }
}
