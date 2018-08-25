using System;

namespace Basics.UI
{
    public class Alert
    {
        private AlertType _type;
        private Link _link;

        public Alert(string text, AlertType type, AlertBehaviour behaviour, Link link = null)
        {
            Text = text;
            _type = type;
            Behaviour = behaviour;
            _link = link;
        }

        public string Text;
        public string Type
        {
            get
            {
                return Enum.GetName(typeof(AlertType), _type).ToLowerInvariant();
            }
        }

        public AlertBehaviour Behaviour;

        public string LinkUrl
        {
            get
            {
                return _link.IsNullOrDefault() ? string.Empty : _link.Url;
            }
        }

        public string LinkText
        {
            get
            {
                return _link.IsNullOrDefault() ? string.Empty : _link.Text;
            }
        }

        public string LinkTitle
        {
            get
            {
                return _link.IsNullOrDefault() ? string.Empty : _link.Title;
            }
        }
    }
}
