/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateAdminFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// This class is meant to be used only in cases where Administrative 
    /// action is taken on a group of projects.
    /// In any case where administrative action is taken on a specific project,
    /// such as Approval or Return, the ProjectUpdateAdminFeatureWithProjectContext
    /// class should be used.
    /// </summary>
    [SecurityFeatureDescription("_Admin for {0} Updates", FieldDefinitionEnum.Project)]
    public class ProjectUpdateAdminFeature : FirmaFeature
    {
        public ProjectUpdateAdminFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
        }
    }
}
