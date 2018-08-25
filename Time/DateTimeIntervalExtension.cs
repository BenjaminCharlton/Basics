using System;
using System.Collections.Generic;
using System.Text;
using Basics.GrammarAndSyntax;
using Basics.Text;
using Microsoft.Extensions.Localization;

namespace Basics.Time
{
    public static class DateTimeIntervalExtension
    {
        public static string GetSingularTerm(this DateTimeInterval instance,
            Capitalization capitalization = Capitalization.Lowercase)
        {
            return instance.GetAttribute<QuantifierAttribute, DateTimeInterval>().Singular.ToCase(capitalization);
        }

        public static string GetPluralTerm(this DateTimeInterval instance,
            Capitalization capitalization = Capitalization.Lowercase)
        {
            return instance.GetAttribute<QuantifierAttribute, DateTimeInterval>().Plural.ToCase(capitalization);
        }

        public static string GetDualTerm(this DateTimeInterval instance,
            Capitalization capitalization = Capitalization.Lowercase)
        {
            return instance.GetAttribute<QuantifierAttribute, DateTimeInterval>().Dual.ToCase(capitalization);
        }

        public static string GetAppropriateSingularOrPluralTerm(
            this DateTimeInterval instance,
            long qty, 
            IStringLocalizer localizer = null)
        {
            switch (qty)
            {
                case 1:
                    return instance.GetSingularTerm().Localize(localizer);
                case 2:
                    return instance.GetDualTerm().Localize(localizer);
                default:
                    return instance.GetPluralTerm().Localize(localizer);
            }
        }

        public static string GetAppropriateSingularOrPluralTerm(
            this DateTimeInterval instance,
            double qty,
            IStringLocalizer localizer = null)
        {
            switch (qty)
            {
                case 1:
                    return instance.GetSingularTerm().Localize(localizer);
                case 2:
                    return instance.GetDualTerm().Localize(localizer);
                default:
                    return instance.GetPluralTerm().Localize(localizer);
            }
        }
    }
}
