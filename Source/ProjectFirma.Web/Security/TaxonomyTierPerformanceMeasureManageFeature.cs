/*-----------------------------------------------------------------------
<copyright file="TaxonomyBranchPerformanceMeasureManageFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage {0} {1}", FieldDefinitionEnum.TaxonomyBranch, FieldDefinitionEnum.PerformanceMeasure)]
    public class TaxonomyTierPerformanceMeasureManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<PerformanceMeasure>
    {
        private readonly FirmaFeatureWithContextImpl<PerformanceMeasure> _firmaFeatureWithContextImpl;

        public TaxonomyTierPerformanceMeasureManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<PerformanceMeasure>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, PerformanceMeasure contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, PerformanceMeasure contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByFirmaSession(firmaSession);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to Edit {FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized()} for {MultiTenantHelpers.GetPerformanceMeasureName()} {contextModelObject.PerformanceMeasureDisplayName}");
            }

            return new PermissionCheckResult();
        }
    }
}
