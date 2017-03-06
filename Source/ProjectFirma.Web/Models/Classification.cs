/*-----------------------------------------------------------------------
<copyright file="Classification.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class Classification : IAuditableEntity
    {
        public List<Project> AssociatedProjects
        {
            get { return ProjectClassifications.Select(ptc => ptc.Project).Distinct(new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList(); }
        }

        public string KeyImageUrlLarge
        {
            get
            {
                return this.KeyImageFileResource != null ? KeyImageFileResource.FileResourceUrlScaledForPrint : "http://placehold.it/280x210";
            }
        }

        public string GetDeleteUrl()
        {
            return SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.DeleteClassification(ClassificationID));
        }

        public string KeyImageScaledForThumbnail
        {
            get { return SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.GetFileResourceResized(KeyImageFileResource.FileResourceGUIDAsString, 287, 180)); }
        }



        public string AuditDescriptionString
        {
            get { return ClassificationName; }
        }
    }
}
