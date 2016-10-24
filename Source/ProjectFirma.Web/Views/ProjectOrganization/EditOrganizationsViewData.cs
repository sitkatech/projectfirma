using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    public class EditOrganizationsViewData
    {
        public readonly List<OrganizationSimple> AllOrganizations;
        public readonly List<PersonSimple> AllPeople;

        public EditOrganizationsViewData(IEnumerable<Models.Organization> organizations, IEnumerable<Person> allPeople)
        {
            AllPeople = allPeople.Select(x => new PersonSimple(x)).ToList();
            AllOrganizations = organizations.Select(x => new OrganizationSimple(x)).ToList();
        }
    }
}