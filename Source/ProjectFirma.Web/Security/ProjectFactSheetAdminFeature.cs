/*-----------------------------------------------------------------------
<copyright file="ProjectFactSheetAdminFeature.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// This feature allows administration of the Fact Sheet configuration.
    /// </summary>
    [SecurityFeatureDescription("_Admin for {0} Updates", FieldDefinitionEnum.Project)]
    public class ProjectFactSheetAdminFeature : FirmaFeature
    {
        public ProjectFactSheetAdminFeature()
            : base(new List<Role> { Role.ESAAdmin, Role.Admin})
        {
        }
    }
}