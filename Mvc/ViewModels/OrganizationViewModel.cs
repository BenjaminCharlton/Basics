using Basics.UI;

namespace Basics.Mvc.ViewModels
{
    public class OrganizationViewModel
    {
        public string OrganizationNickName { get; set; }
        public string OrganizationFullName { get; set; }
        public string OrganizationOfficialName { get; set; }
        public virtual string Title { get; set; }
        public virtual Alert StatusMessage { get; set; }
        public virtual string BodyCssClass { get; set; }
    }
}
