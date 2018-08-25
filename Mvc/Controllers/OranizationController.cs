using Basics.Mvc.ViewModels;
using Basics.Configuration;
using Basics.UI;
using Microsoft.Extensions.Options;

namespace Basics.Mvc.Controllers
{
    public abstract class OrganizationController : Controller
    {
        protected OrganizationController(
            IOptions<OrganizationDetailsOptions> options)
        {
            ApplicationOptions = options.Value;
        }

        protected OrganizationDetailsOptions ApplicationOptions { get; }

        protected T GetViewModel<T>(string title, string bodyCssClass = "", Alert alert = null) 
            where T : OrganizationViewModel, new()
        {
            T result = new T
            {
                Title = title,
                OrganizationOfficialName = ApplicationOptions.OrganizationOfficialName,
                OrganizationFullName = ApplicationOptions.OrganizationFullName,
                OrganizationNickName = ApplicationOptions.OrganizationNickName,
                StatusMessage = alert,
                BodyCssClass = bodyCssClass
            };

            return result;
        }
    }
}
