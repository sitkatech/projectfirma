/*-----------------------------------------------------------------------
<copyright file="TechnicalAssistanceRequestViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class TechnicalAssistanceRequestsViewData : ProjectUpdateViewData
    {
        public ViewPageContentViewData TechnicalAssistanceInstructionsViewData { get; }
        public TechnicalAssistanceRequestsViewDataForAngular ViewDataForAngular { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }
        public string RefreshUrl { get; }
        public bool UserCanAllocate { get; }
        
        public TechnicalAssistanceRequestsViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus, List<TechnicalAssistanceType> technicalAssistanceTypes, List<CalendarYearString> fiscalYearStrings, List<PersonSimple> personSimples) : base(currentFirmaSession, projectUpdateBatch, projectUpdateStatus, new List<string>(), ProjectUpdateSection.TechnicalAssistanceRequests.ProjectUpdateSectionDisplayName)
        {
            Check.EnsureNotNull(firmaPage, "The Firma Page for this section is not found; is one defined?");
            bool hasPermissionToManageFirmaPage = new FirmaPageManageFeature().HasPermission(currentFirmaSession, firmaPage).HasPermission;
            TechnicalAssistanceInstructionsViewData = new ViewPageContentViewData(firmaPage, hasPermissionToManageFirmaPage);
            UserCanAllocate = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(currentFirmaSession, projectUpdateBatch.Project).HasPermission;
            ViewDataForAngular = new TechnicalAssistanceRequestsViewDataForAngular(projectUpdateBatch.ProjectID, technicalAssistanceTypes, fiscalYearStrings, personSimples);
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.TechnicalAssistanceRequestsComment, projectUpdateBatch.IsReturned());
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshTechnicalAssistanceRequests(projectUpdateBatch.Project));
        }
    }

    public class TechnicalAssistanceRequestsViewDataForAngular
    {
        public int ProjectID { get; }
        public List<TechnicalAssistanceType> TechnicalAssistanceTypes { get; }
        public List<CalendarYearString> FiscalYearStrings { get; }
        public List<PersonSimple> PersonSimples { get; }


        public TechnicalAssistanceRequestsViewDataForAngular(int projectID, List<TechnicalAssistanceType> technicalAssistanceTypes, 
            List<CalendarYearString>  fiscalYearStrings, List<PersonSimple> personSimples)
        {
            ProjectID = projectID;
            TechnicalAssistanceTypes = technicalAssistanceTypes;
            FiscalYearStrings = fiscalYearStrings;
            PersonSimples = personSimples;
        }
    }
}
