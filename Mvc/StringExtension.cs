namespace Basics.Mvc
{
    public static class StringExtension
    {
        public const string Controller = "CONTROLLER";
        public const string ViewModel = "VIEWMODEL";

        public static string ControllerName(this string instance)
        {
            if (instance.ToUpperInvariant().EndsWith(Controller))
                return instance.Substring(0, instance.Length - Controller.Length);
            return instance;
        }

        public static string ViewModelName(this string instance)
        {
            if (instance.ToUpperInvariant().EndsWith(ViewModel))
                return instance.Substring(0, instance.Length - ViewModel.Length);
            return instance;
        }
    }
}
