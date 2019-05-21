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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class TechnicalAssistanceRequestsViewData : ProjectUpdateViewData
    {
        public TechnicalAssistanceRequestsViewDataForAngular ViewDataForAngular { get; }
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly string RefreshUrl;

        public TechnicalAssistanceRequestsViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus, List<TechnicalAssistanceType> technicalAssistanceTypes, List<CalendarYearString> fiscalYearStrings, List<PersonSimple> personSimples) : base(currentPerson, projectUpdateBatch, projectUpdateStatus, new List<string>(), ProjectUpdateSection.TechnicalAssistanceRequests.ProjectUpdateSectionDisplayName)
        {
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

        public TechnicalAssistanceRequestsViewDataForAngular(int projectID, List<TechnicalAssistanceType> technicalAssistanceTypes, List<CalendarYearString>  fiscalYearStrings, List<PersonSimple> personSimples)
        {
            ProjectID = projectID;
            TechnicalAssistanceTypes = technicalAssistanceTypes;
            FiscalYearStrings = fiscalYearStrings;
            PersonSimples = personSimples;
        }
    }
}
