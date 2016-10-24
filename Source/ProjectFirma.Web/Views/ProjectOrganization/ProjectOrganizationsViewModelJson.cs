using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    [ModelBinder(typeof(ProjectOrganizationsViewModelJsonModelBinder))]
    public class ProjectOrganizationsViewModelJson
    {
        public ProjectOrganizationsViewModelJson(int? leadOrganizationID, List<ProjectOrganizationJson> projectOrganizations)
        {
            LeadOrganizationID = leadOrganizationID;
            ProjectOrganizations = projectOrganizations;
        }

        public int? LeadOrganizationID;
        public List<ProjectOrganizationJson> ProjectOrganizations;

        [Obsolete("Needed by the ModelBinder")]
        public ProjectOrganizationsViewModelJson()
        {
        }

        public class ProjectOrganizationJson
        {
            public int OrganizationID;
            public string OrganizationDisplayName;
            public bool IsFundingOrganization;
            public bool IsImplementingOrganization;

            [Obsolete("Needed by the ModelBinder")]
            public ProjectOrganizationJson()
            {
            }

            public ProjectOrganizationJson(ProjectImplementingOrganizationOrProjectFundingOrganization po)
            {
                OrganizationID = po.Organization.OrganizationID;
                OrganizationDisplayName = po.Organization.DisplayName;
                IsFundingOrganization = po.IsFundingOrganization;
                IsImplementingOrganization = po.IsImplementingOrganization;
            }

            public ProjectOrganizationJson(int organizationID, string organizationDisplayName, bool isFundingOrganization, bool isImplementingOrganization)
            {
                OrganizationID = organizationID;
                OrganizationDisplayName = organizationDisplayName;
                IsFundingOrganization = isFundingOrganization;
                IsImplementingOrganization = isImplementingOrganization;
            }

            public override string ToString()
            {
                return string.Format("OrganizationID: {0}; OrganizationDisplayName: {1}; IsFundingOrganization: {2}; IsImplementingOrganization: {3}",
                    OrganizationID,
                    OrganizationDisplayName,
                    IsFundingOrganization,
                    IsImplementingOrganization);
            }
        }
    }

    public class ProjectOrganizationsViewModelJsonModelBinder : SitkaModelBinder
    {
        public ProjectOrganizationsViewModelJsonModelBinder() : base(JsonTools.DeserializeObject<ProjectOrganizationsViewModelJson>)
        {
        }
    }
}