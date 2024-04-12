﻿/*-----------------------------------------------------------------------
<copyright file="EditBasicsViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Linq;
using System.Web;

namespace ProjectFirmaModels.Models
{
    public class ClassificationSystemSimple
    {
        public int? ClassificationSystemID { get; set; }
        public int TenantID { get; set; }
        public string ClassificationSystemName { get; set; }
        public string ClassificationSystemNamePlural { get; set; }
        public HtmlString ClassificationSystemDefinition { get; set; }
        public string ClassificationSystemPageContent { get; set; }
        public bool CanDelete { get; set; }
        public bool IsRequired { get; set; }

        public ClassificationSystemSimple(Models.ClassificationSystem classificationSystem)
        {
            ClassificationSystemID = classificationSystem.ClassificationSystemID;
            TenantID = classificationSystem.TenantID;
            ClassificationSystemName = classificationSystem.ClassificationSystemName;
            ClassificationSystemNamePlural = classificationSystem.ClassificationSystemNamePlural;
            ClassificationSystemDefinition = classificationSystem.ClassificationSystemDefinitionHtmlString;
            ClassificationSystemPageContent = classificationSystem.ClassificationSystemListPageContent;
            CanDelete = !classificationSystem.Classifications.Any();
            IsRequired = classificationSystem.IsRequired;
        }

        public ClassificationSystemSimple(int tenantID)
        {
            TenantID = tenantID;
            CanDelete = true;
            IsRequired = true;
        }

        public ClassificationSystemSimple()
        {
        }
    }
}
