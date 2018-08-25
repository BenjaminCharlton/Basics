using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Basics.Text
{
    public enum Capitalization
    {
        [Display(Description = "All letters lowercase.")]
        Lowercase = 1,

        [Display(Description = "All letters uppercase.")]
        Uppercase = 2,

        [Display(Description = "The first letter of every word uppercase; all other letters lowercase.")]
        TitleCase = 3,

        [Display(Description = "The first letter of every word uppercase, except for conjunctions," +
                               "which will remain lowercase; all other letters lowercase.")]
        TitleCaseExceptConjunctions = 4,

        [Display(Description = "The first letter of every sentence uppercase. All other letters lowercase.")]
        SentenceCase = 5
    }
}
