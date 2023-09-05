/*-----------------------------------------------------------------------
<copyright file="WebServiceProjectSimpleLocationCoordinates.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using ProjectFirmaModels.Models;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceProjectSimpleLocationCoordinates : SimpleModelObject
    {
        public WebServiceProjectSimpleLocationCoordinates(Project project)
        {
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            var projectLocationPoint = project.GetProjectLocationPoint(false);
            Latitude = projectLocationPoint?.YCoordinate;
            Longitude = projectLocationPoint?.XCoordinate;
        }

        [DataMember] public int ProjectID { get; set; }
        [DataMember] public string ProjectName { get; set; }
        [DataMember] public double? Latitude { get; set; }
        [DataMember] public double? Longitude { get; set; }

        public static List<WebServiceProjectSimpleLocationCoordinates> GetProjectSimpleLocationCoordinates()
        {
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            if (!MultiTenantHelpers.ShowProposalsToThePublic())
            {
                projects = projects.Where(x => !x.IsProposal() && !x.IsPendingProject()).ToList();
            }
            return
                projects
                    .Select(x => new WebServiceProjectSimpleLocationCoordinates(x))
                    .OrderBy(x => x.ProjectID)
                    .ToList();
        }
    }

    public class WebServiceProjectSimpleLocationCoordinatesGridSpec : GridSpec<WebServiceProjectSimpleLocationCoordinates>
    {
        public WebServiceProjectSimpleLocationCoordinatesGridSpec()
        {
            Add("ProjectID", x => x.ProjectID, 0);
            Add("ProjectName", x => x.ProjectName, 0);
            Add("Latitude", x => x.Latitude, 0);
            Add("Longitude", x => x.Longitude, 0);
        }
    }
}
