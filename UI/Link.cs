using System;
using System.ComponentModel.DataAnnotations;

namespace Basics.UI
{
    public class Link
    {
        public Link(string text, string title, [Url]string url)
        {
            if (text.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(text));

            if (title.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(title));

            if (url.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(url));

            Text = text;
            Title = title;
            Url = url;
        }

        public string Text;
        public string Title;

        [Url]
        public string Url;
    }
}
