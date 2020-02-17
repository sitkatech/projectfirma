using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplatePersonModel : ReportTemplateBaseModel
    {

        private Person Person { get; set; }
        private Organization Organization { get; set; }

        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public ReportTemplatePersonModel(Person person)
        {
            // Private properties
            Person = person;
            Organization = Person.Organization;

            // Public properties
            FullName = Person.GetFullNameFirstLast();
            FirstName = Person.FirstName;
            LastName = Person.LastName;
            Email = Person.Email;
            Phone = Person.Phone;
        }

        public ReportTemplateOrganizationModel GetOrganization()
        {
            return new ReportTemplateOrganizationModel(Organization);
        }

    }
}