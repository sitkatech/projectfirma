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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.TechnicalAssistanceRequest
{
    public class TechnicalAssistanceReportViewData : FirmaViewData
    {
        public TechnicalAssistanceReportGridSpec TechnicalAssistanceReportGridSpec { get; }
        public string TechnicalAssistanceReportGridDataUrl { get; }
        public TechnicalAssistanceReportViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            TechnicalAssistanceReportGridSpec = new TechnicalAssistanceReportGridSpec(currentFirmaSession, new List<TechnicalAssistanceParameter>());
            TechnicalAssistanceReportGridDataUrl = SitkaRoute<TechnicalAssistanceRequestController>.BuildUrlFromExpression(c => c.TechnicalAssistanceReportGridJsonData());
        }
    }
}
