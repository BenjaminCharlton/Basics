namespace Basics.Configuration
{
    public class OrganizationDetailsOptions
    {
        public string OrganizationOfficialName;
        public string OrganizationFullName;
        public string OrganizationNickName;
        public SitesOptions Sites;
        public EmailsOptions Emails;

        public class SitesOptions
        {
            public string Web;
            public string Support;
            public string Blog;
        }

        public class EmailsOptions
        {
            public string Default;
            public string Support;
            public string Sales;
        }
    }
}
