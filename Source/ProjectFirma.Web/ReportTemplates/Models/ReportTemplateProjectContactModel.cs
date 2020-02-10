using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplateProjectContactModel : ReportTemplateBaseModel
    {
        private ProjectContact ProjectContact { get; set; }
        private Organization Organization { get; set; }

        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactType { get; set; }

        public ReportTemplateProjectContactModel(ProjectContact projectContact)
        {
            // Private properties
            ProjectContact = projectContact;
            Organization = ProjectContact.Contact.Organization;

            // Public properties
            FullName = ProjectContact.Contact.GetFullNameFirstLast();
            FirstName = ProjectContact.Contact.FirstName;
            LastName = ProjectContact.Contact.LastName;
            Email = ProjectContact.Contact.Email;
            Phone = ProjectContact.Contact.Phone;
            ContactType = ProjectContact.ContactRelationshipType.ContactRelationshipTypeName;
        }

        public ReportTemplateOrganizationModel GetOrganization()
        {
            return new ReportTemplateOrganizationModel(Organization);
        }

    }
}