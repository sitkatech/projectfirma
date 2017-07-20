/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierTwoPerformanceMeasureManageFeature.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage {0} {1}", FieldDefinitionEnum.TaxonomyTierTwo, FieldDefinitionEnum.PerformanceMeasure)]
    public class TaxonomyTierTwoPerformanceMeasureManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<PerformanceMeasure>
    {
        private readonly FirmaFeatureWithContextImpl<PerformanceMeasure> _firmaFeatureWithContextImpl;

        public TaxonomyTierTwoPerformanceMeasureManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<PerformanceMeasure>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, PerformanceMeasure contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, PerformanceMeasure contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(String.Format("You don't have permission to Edit {0} for {1} {2}", FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized(), MultiTenantHelpers.GetPerformanceMeasureName(), contextModelObject.PerformanceMeasureDisplayName));
            }

            return new PermissionCheckResult();
        }
    }
}
