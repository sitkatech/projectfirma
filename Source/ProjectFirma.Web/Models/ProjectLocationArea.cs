/*-----------------------------------------------------------------------
<copyright file="ProjectLocationArea.cs" company="Tahoe Regional Planning Agency">
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
using System.Data.Entity.Spatial;
using System.Linq;
using ProjectFirma.Web.Views.Map;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationArea : IAuditableEntity
    {
        public string ProjectLocationAreaName
        {
            get { return ProjectLocationAreaGroup.ProjectLocationAreaGroupType.GetProjectLocationAreaName(this); }
        }

        public string ProjectLocationAreaDisplayName
        {
            get { return ProjectLocationAreaGroup.ProjectLocationAreaGroupType.GetProjectLocationAreaDisplayName(this); }
        }

        public LayerGeoJson GetLayerGeoJson()
        {
            return ProjectLocationAreaGroup.ProjectLocationAreaGroupType.GetLayerGeoJson(this);
        }

        public DbGeometry GetGeometry()
        {
            return ProjectLocationAreaGroup.ProjectLocationAreaGroupType.GetGeometry(this);
        }

        public string AuditDescriptionString
        {
            get
            {
                return "Project location named area deleted";
            }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(ProjectLocationAreaDisplayName, ProjectLocationAreaDisplayName, false)
            {
                MapUrl = null,
                Children = Projects.OrderBy(x => x.DisplayName).Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}
