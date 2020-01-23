/*-----------------------------------------------------------------------
<copyright file="EditProjectProjectStatusViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectProjectStatus
{
    public class EditProjectProjectStatusViewData : FirmaViewData
    {

        public IEnumerable<SelectListItem> ProjectStatuses { get; }
        public ProjectStatusJsonList ProjectStatusJsonList { get; }

        public bool AllowEditUpdateDate { get; }
        public bool AllowEditFinal { get; }
        public string CreatedByPerson { get; }
        public HtmlString DeleteButton { get; }
        public ViewPageContentViewData ProjectStatusFirmaPage { get; }
        public ProjectStatusLegendDisplayViewData ProjectStatusLegendDisplayViewData { get; }
        

        public EditProjectProjectStatusViewData(
             ProjectFirmaModels.Models.Project project
            , bool allowEditUpdateDate
            , string createdByPerson
            , string deleteUrl
            , ProjectFirmaModels.Models.FirmaPage projectStatusFirmaPage
            , FirmaSession currentFirmaSession
            , List<ProjectFirmaModels.Models.ProjectStatus> allProjectStatuses
            , ProjectStatusLegendDisplayViewData projectStatusLegendDisplayViewData
            , bool isFinalStatusReport) : base(currentFirmaSession)
        {
            ProjectStatuses = allProjectStatuses.OrderBy(x => x.ProjectStatusSortOrder)
                                                .ToSelectListWithEmptyFirstRow(x => x.ProjectStatusID.ToString(), 
                                                                                x => !string.IsNullOrEmpty(x.ProjectStatusDescription) 
                                                                                         ? $"{x.ProjectStatusDisplayName} - {x.ProjectStatusDescription}" 
                                                                                         : $"{x.ProjectStatusDisplayName}");
            ProjectStatusJsonList = new ProjectStatusJsonList(allProjectStatuses.Select(x => new ProjectStatusJson(x)).ToList());
            AllowEditUpdateDate = allowEditUpdateDate;
            CreatedByPerson = !string.IsNullOrEmpty(createdByPerson)
                ? createdByPerson
                : currentFirmaSession.UserDisplayName;
            DeleteButton = string.IsNullOrEmpty(deleteUrl) ? new HtmlString(string.Empty) : ModalDialogFormHelper.MakeDeleteIconButton(deleteUrl, $"Delete {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()} Update", true);
            ProjectStatusFirmaPage = new ViewPageContentViewData(projectStatusFirmaPage, currentFirmaSession);
            ProjectStatusLegendDisplayViewData = projectStatusLegendDisplayViewData;
            AllowEditFinal = isFinalStatusReport || ProjectProjectStatusController.AllowUserToSetNewStatusReportToFinal(project, currentFirmaSession);
        }
    }

    public class ProjectStatusJsonList
    {
        public Dictionary<int,ProjectStatusJson> ProjectStatusJsons { get; set; }

        public ProjectStatusJsonList(List<ProjectStatusJson> projectStatusJsons)
        {
            ProjectStatusJsons = projectStatusJsons.ToDictionary(x => x.ProjectStatusID, x=> x);
        }
    }

    public class ProjectStatusJson
    {
        public string Color { get; set; }
        public int ProjectStatusID { get; set; }
        public string ProjectStatusDisplayName { get; set; }

        public ProjectStatusJson(ProjectFirmaModels.Models.ProjectStatus projectStatus)
        {
            Color = projectStatus.ProjectStatusColor;
            ProjectStatusID = projectStatus.ProjectStatusID;
            ProjectStatusDisplayName = projectStatus.ProjectStatusDisplayName;
        }
    }
}
