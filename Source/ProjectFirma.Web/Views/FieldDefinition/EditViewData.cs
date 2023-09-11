﻿/*-----------------------------------------------------------------------
<copyright file="EditViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.FieldDefinition
{
    public class EditViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinition { get; }
        public string CancelUrl { get; }
        public bool IsSitkaAdministrator { get; }

        public EditViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FieldDefinition fieldDefinition) : base(currentFirmaSession)
        {
            FieldDefinition = fieldDefinition;
            CancelUrl = SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x => x.Index());
            IsSitkaAdministrator = currentFirmaSession.IsSitkaAdministrator();
        }
    }
}
