/*-----------------------------------------------------------------------
<copyright file="WebServiceProjectKeyPhoto.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceProjectKeyPhoto : SimpleModelObject
    {
        public WebServiceProjectKeyPhoto(Project project)
        {
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            KeyPhotoUrl = project.GetKeyPhoto() != null
                ? SitkaRoute<FileResourceController>.BuildAbsoluteUrlHttpsFromExpression(x => x.DisplayResource(project.GetKeyPhoto().FileResourceInfo.GetFileResourceGUIDAsString()))
                : ViewUtilities.NoneString;
        }

        [DataMember] public int ProjectID { get; set; }
        [DataMember] public string ProjectName { get; set; }
        [DataMember] public string KeyPhotoUrl { get; set; }

        public static List<WebServiceProjectKeyPhoto> GetProjectKeyPhoto(int projectID)
        {
            var project = HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID);
            var projectKeyPhoto = new WebServiceProjectKeyPhoto(project);
            return new List<WebServiceProjectKeyPhoto> { projectKeyPhoto };
        }
    }

    public class WebServiceProjectKeyPhotoGridSpec : GridSpec<WebServiceProjectKeyPhoto>
    {
        public WebServiceProjectKeyPhotoGridSpec()
        {
            Add("ProjectID", x => x.ProjectID, 0);
            Add("ProjectName", x => x.ProjectName, 0);
            Add("KeyPhotoUrl", x => x.KeyPhotoUrl, 0);            
        }
    }
}
