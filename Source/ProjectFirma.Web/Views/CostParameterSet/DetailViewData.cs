/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.CostParameterSet
{
    public class DetailViewData : FirmaViewData
    {
        public readonly string EditCostParameterSet;
        public readonly ProjectFirmaModels.Models.CostParameterSet CostParameterSet;
        public readonly bool HasEditPermissions;

        public DetailViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage, ProjectFirmaModels.Models.CostParameterSet costParameterSet)
            : base(currentPerson, firmaPage)
        {
            PageTitle = " Cost Parameters";
            CostParameterSet = costParameterSet;            
            HasEditPermissions = new AssessmentManageFeature().HasPermissionByPerson(CurrentPerson);
            EditCostParameterSet = SitkaRoute<CostParameterSetController>.BuildUrlFromExpression(c => c.New());
        }        
    }
}
