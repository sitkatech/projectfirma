/*-----------------------------------------------------------------------
<copyright file="TechnicalAssistanceRequestDetailViewData.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.TechnicalAssistanceRequest
{
    public class TechnicalAssistanceRequestsDetailViewData : FirmaViewData
    {
        public List<ProjectFirmaModels.Models.TechnicalAssistanceRequest> TechnicalAssistanceRequests { get; }
        public bool CanViewNotes { get; }
        public List<TechnicalAssistanceParameter> TechnicalAssistanceParameters { get; }


        public TechnicalAssistanceRequestsDetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project, bool canViewNotes, List<TechnicalAssistanceParameter> technicalAssistanceParameters) : base(currentFirmaSession)
        {
            var technicalAssistanceRequests = new List<ProjectFirmaModels.Models.TechnicalAssistanceRequest>();
            if (project.TechnicalAssistanceRequests != null)
            {
                technicalAssistanceRequests.AddRange(project.TechnicalAssistanceRequests.OrderByDescending(x => x.FiscalYear).ThenBy(x => x.TechnicalAssistanceType.TechnicalAssistanceTypeDisplayName).Select(x => x).ToList());
            }
            TechnicalAssistanceRequests = technicalAssistanceRequests;
            CanViewNotes = canViewNotes;
            TechnicalAssistanceParameters = technicalAssistanceParameters;
        }
    }
}
