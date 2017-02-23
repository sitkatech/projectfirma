/*-----------------------------------------------------------------------
<copyright file="WebServiceProject.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceProject : SimpleModelObject
    {
        public WebServiceProject(Project project)
        {
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            TaxonomyTierThree = project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.TaxonomyTierThreeName;
            TaxonomyTierTwo = project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierTwoName;
            TaxonomyTierOne = project.TaxonomyTierOne.TaxonomyTierOneName;
            ProjectDescription = project.ProjectDescription;
            LeadImplementer = project.LeadImplementerName;

            PlanningStartDate = project.PlanningDesignStartYear;
            ImplementationStartDate = project.ImplementationStartYear;
            EndDate = project.CompletionYear;
            Stage = project.ProjectStage.ProjectStageDisplayName;

            Latitude = project.ProjectLocationPointLatitude;
            Longitude = project.ProjectLocationPointLongitude;

            Datum = "WGS84";
            
            ProjectRegion = project.ProjectLocationTypeDisplay;
            ProjectState = project.ProjectLocationStateProvince;
            ProjectWatershed = project.ProjectLocationWatershed;

            ProjectDetailUrl = project.GetDetailUrl();
            ProjectFactSheetUrl = project.GetFactSheetUrl();
        }

        [DataMember] public int ProjectID { get; set; }
        [DataMember] public string ProjectName { get; set; }
        [DataMember] public string TaxonomyTierThree { get; set; }
        [DataMember] public string TaxonomyTierTwo { get; set; }
        [DataMember] public string TaxonomyTierOne { get; set; }
        [DataMember] public string ProjectDescription { get; set; }
        [DataMember] public string LeadImplementer { get; set; }

        [DataMember] public int? PlanningStartDate { get; set; }
        [DataMember] public int? ImplementationStartDate { get; set; }
        [DataMember] public int? EndDate { get; set; }        
        [DataMember] public string Stage { get; set; }

        [DataMember] public double? Latitude { get; set; }
        [DataMember] public double? Longitude { get; set; }
        [DataMember] public string Datum { get; set; }
        [DataMember] public string ProjectRegion { get; set; }
        [DataMember] public string ProjectState { get; set; }
        [DataMember] public string ProjectWatershed { get; set; }

        [DataMember] public string ProjectDetailUrl { get; set; }
        [DataMember] public string ProjectFactSheetUrl { get; set; }

        public static List<WebServiceProject> GetProject(int projectID)
        {
            var project = HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID);
            return new List<WebServiceProject> {new WebServiceProject(project)};
        }

        public static List<WebServiceProject> GetProjects()
        {
            var projects =
                HttpRequestStorage.DatabaseEntities.Projects
                    .Where(x => x.ProjectStageID != ProjectStage.Terminated.ProjectStageID && x.ProjectStageID != ProjectStage.Deferred.ProjectStageID)
                    .ToList();                    
            return
                projects
                    .Select(x => new WebServiceProject(x))
                    .OrderBy(x => x.ProjectID)
                    .ToList();
        }

        public static List<WebServiceProject> GetProjectsByOrganization(int organizationID)
        {
            var projectsByImplementingOrganization = HttpRequestStorage.DatabaseEntities.ProjectImplementingOrganizations.Where(x => x.OrganizationID == organizationID).Select(x => x.ProjectID);
            var projectsByFundingOrganization = HttpRequestStorage.DatabaseEntities.ProjectFundingOrganizations.Where(x => x.OrganizationID == organizationID).Select(x => x.ProjectID);

            var projectIDs = projectsByImplementingOrganization.Union(projectsByFundingOrganization).ToList();
            var projects = HttpRequestStorage.DatabaseEntities.Projects.Where(x => projectIDs.Contains(x.ProjectID)).ToList();

            return projects
                .Select(x => new WebServiceProject(x))
                    .OrderBy(x => x.ProjectID)
                    .ToList();
        }
    }

    public class WebServiceProjectGridSpec : GridSpec<WebServiceProject>
    {
        public WebServiceProjectGridSpec()
        {
            Add("ProjectID", x => x.ProjectID, 0);
            Add("ProjectName", x => x.ProjectName, 0);
            Add("TaxonomyTierThree", x => x.TaxonomyTierThree, 0);
            Add("TaxonomyTierTwo", x => x.TaxonomyTierTwo, 0);
            Add("TaxonomyTierOne", x => x.TaxonomyTierOne, 0);
            Add("Stage", x => x.Stage, 0);
            Add("ProjectDescription", x => x.ProjectDescription, 0);
            Add("LeadImplementer", x => x.LeadImplementer, 0);
            Add("PlanningStartDate", x => x.PlanningStartDate, 0);
            Add("ImplementationStartDate", x => x.ImplementationStartDate, 0);
            Add("EndDate", x => x.EndDate, 0);
            Add("Latitude", x => x.Latitude, 0);
            Add("Longitude", x => x.Longitude, 0);
            Add("Datum", x => x.Datum, 0);
            Add("ProjectRegion", x => x.ProjectRegion, 0);
            Add("ProjectState", x => x.ProjectState, 0);
            Add("ProjectWatershed", x => x.ProjectWatershed, 0);
            Add("ProjectDetailUrl", x => x.ProjectDetailUrl, 0);
            Add("ProjectFactSheetUrl", x => x.ProjectFactSheetUrl, 0);
        }
    }
}
