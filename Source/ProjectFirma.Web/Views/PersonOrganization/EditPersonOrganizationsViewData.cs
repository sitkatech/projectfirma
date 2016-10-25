using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.PersonOrganization
{
    public class EditPersonOrganizationsViewData : FirmaUserControlViewData
    {
        public readonly List<OrganizationSimple> AllOrganizations;

        public EditPersonOrganizationsViewData(List<OrganizationSimple> allOrganizations)
        {
            AllOrganizations = allOrganizations;
        }
    }
}