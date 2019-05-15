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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.TechnicalAssistanceRequest
{
    public class EditTechnicalAssistanceRequestsViewData : FirmaUserControlViewData
    {
        public int ProjectID { get; }
        public List<TechnicalAssistanceType> TechnicalAssistanceTypes { get; }
        public List<CalendarYearString> FiscalYearStrings { get;  }
        public List<PersonSimple> PersonSimples { get; } 

        public EditTechnicalAssistanceRequestsViewData(int projectID, List<TechnicalAssistanceType> technicalAssistanceTypes, List<CalendarYearString> fiscalYearStrings, List<PersonSimple> personSimples) : base()
        {
            ProjectID = projectID;
            TechnicalAssistanceTypes = technicalAssistanceTypes;
            FiscalYearStrings = fiscalYearStrings;
            PersonSimples = personSimples;
        }
    }
}
