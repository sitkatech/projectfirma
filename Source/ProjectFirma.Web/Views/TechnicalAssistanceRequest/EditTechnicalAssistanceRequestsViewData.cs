/*-----------------------------------------------------------------------
<copyright file="EditTechnicalAssistanceRequestViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.TechnicalAssistanceRequest
{
    public class EditTechnicalAssistanceRequestsViewData : FirmaUserControlViewData
    {
        public ViewPageContentViewData TechnicalAssistanceInstructionsViewData { get; }
        public int ProjectID { get; }
        public List<TechnicalAssistanceType> TechnicalAssistanceTypes { get; }
        public List<CalendarYearString> FiscalYearStrings { get;  }
        public List<PersonSimple> PersonSimples { get; }
        public bool UserCanAllocate { get; }


        public EditTechnicalAssistanceRequestsViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, ProjectFirmaModels.Models.Project project, List<TechnicalAssistanceType> technicalAssistanceTypes, List<CalendarYearString> fiscalYearStrings, List<PersonSimple> personSimples) : base()
        {
            Check.EnsureNotNull(firmaPage, "The Firma Page for this section is not found; is one defined?");
            bool hasPermissionToManageFirmaPage = new FirmaPageManageFeature().HasPermission(currentFirmaSession, firmaPage).HasPermission;
            TechnicalAssistanceInstructionsViewData = new ViewPageContentViewData(firmaPage, hasPermissionToManageFirmaPage);
            ProjectID = project.ProjectID;
            TechnicalAssistanceTypes = technicalAssistanceTypes;
            FiscalYearStrings = fiscalYearStrings;
            PersonSimples = personSimples;
            UserCanAllocate = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(currentFirmaSession, project).HasPermission;

        }
    }
}
