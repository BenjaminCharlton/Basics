using System;

namespace Basics.GrammarAndSyntax
{
    [AttributeUsage(AttributeTargets.All)]
    public class QuantifierAttribute : Attribute
    {
        public QuantifierAttribute(string singular, string plural, string dual = null)
        {
            Singular = singular;
            Plural = plural;
            Dual = dual ?? plural;
        }

        public string Singular { get;}
        public string Plural { get; }
        public string Dual { get; }
    }
}
