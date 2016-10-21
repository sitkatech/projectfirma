using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFundingOrganization : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.Find(OrganizationID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var organizationName = organization != null ? organization.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, Organization: {1}", projectName, organizationName);
            }
        }

        public static void SyncProjectFundingOrganizationsWithProjectFundingSourceExpenditures(IEnumerable<int> distinctProjectIDs,
            IEnumerable<IFundingSourceExpenditure> currentProjectFundingSourceExpenditures,
            List<ProjectFundingOrganization> currentProjectFundingOrganizations)
        {
            var distinctFundingSourceIDs = currentProjectFundingSourceExpenditures.Select(x => x.FundingSourceID).Distinct().ToList();
            var distinctOrganizationIDs =
                HttpRequestStorage.DatabaseEntities.FundingSources.Where(x => distinctFundingSourceIDs.Contains(x.FundingSourceID)).Select(x => x.OrganizationID).Distinct().ToList();
            var currentProjectFundingOrganizationsDerivedFromExpenditures = distinctProjectIDs.SelectMany(x => distinctOrganizationIDs.Select(y => new ProjectFundingOrganization(x, y))).ToList();
            var allProjectFundingOrganizations = HttpRequestStorage.DatabaseEntities.ProjectFundingOrganizations.Local;
            HttpRequestStorage.DatabaseEntities.ProjectFundingOrganizations.Load();
            currentProjectFundingOrganizations.MergeNew(currentProjectFundingOrganizationsDerivedFromExpenditures,
                (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID,
                allProjectFundingOrganizations);
        }
    }
}