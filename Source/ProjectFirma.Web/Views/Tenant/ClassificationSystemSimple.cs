/*-----------------------------------------------------------------------
<copyright file="EditBasicsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Tenant
{
    public class ClassificationSystemSimple
    {
        public int? ClassificationSystemID { get; set; }
        public int TenantID { get; set; }
        public string ClassificationSystemName { get; set; }
        public string ClassificationSystemDescription { get; set; }
        public string ClassificationSystemPageContent { get; set; }
        public bool CanDelete { get; set; }

        public ClassificationSystemSimple(ClassificationSystem classificationSystem)
        {
            ClassificationSystemID = classificationSystem.ClassificationSystemID;
            TenantID = classificationSystem.TenantID;
            ClassificationSystemName = classificationSystem.ClassificationSystemName;
            ClassificationSystemDescription = classificationSystem.ClassificationSystemDescription;
            ClassificationSystemPageContent = classificationSystem.ClassificationSystemListPageContent;
            CanDelete = !classificationSystem.Classifications.Any();
        }

        public ClassificationSystemSimple(int tenantID)
        {
            TenantID = tenantID;
            CanDelete = true;
        }

        public ClassificationSystemSimple()
        {
        }
    }
}
