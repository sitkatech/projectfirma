using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplateOrganizationModel : ReportTemplateBaseModel
    {
        private Organization Organization { get; set; }
        private List<Person> People { get; set; }

        public string OrganizationName { get; set; }
        public string OrganizationShortName { get; set; }
        public string OrganizationTypeName { get; set; }
        public string OrganizationTypeAbbreviation { get; set; }


        public ReportTemplateOrganizationModel(Organization organization)
        {
            // Private properties
            Organization = organization;
            People = organization.People.ToList();

            // Public properties
            OrganizationName = organization.OrganizationName;
            OrganizationShortName = organization.OrganizationShortName;
            OrganizationTypeName = organization.OrganizationType.OrganizationTypeName;
            OrganizationTypeAbbreviation = organization.OrganizationType.OrganizationTypeAbbreviation;

        }

        public List<ReportTemplatePersonModel> GetPeople()
        {
            return People.Select(x => new ReportTemplatePersonModel(x)).ToList();
        }

        public ReportTemplatePersonModel GetPrimaryContactPerson()
        {
            return new ReportTemplatePersonModel(Organization.PrimaryContactPerson);
        }

    }
}