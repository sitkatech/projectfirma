using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.PersonOrganization
{
    public class EditPersonOrganizationsViewModel : FormViewModel
    {
        public List<int> OrganizationIDs { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPersonOrganizationsViewModel()
        {
        }

        public EditPersonOrganizationsViewModel(List<int> organizationIDs)
        {
            OrganizationIDs = organizationIDs;
        }

        public void UpdateModel(Person person, List<Models.Organization> allOrganizations)
        {
            // Remove all existing associations
            var currentOrgsForWhichIAmPrimaryContact = allOrganizations.Where(o => o.PrimaryContactPersonID == person.PersonID).ToList();
            currentOrgsForWhichIAmPrimaryContact.ForEach(org => org.PrimaryContactPersonID = null);

            // Create all-new associations
            if (OrganizationIDs != null && OrganizationIDs.Any())
            {
                var realOrgsINeedAssociationsFor = allOrganizations.Where(org => OrganizationIDs.Contains(org.OrganizationID)).ToList();
                realOrgsINeedAssociationsFor.ForEach(org => org.PrimaryContactPersonID = person.PersonID);
            }
        }
    }
}