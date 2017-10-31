/*-----------------------------------------------------------------------
<copyright file="ProjectCostTypeSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
namespace ProjectFirma.Web.Models
{
    public class ProjectCostTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectCostTypeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCostTypeSimple(int ProjectCostTypeID, string ProjectCostTypeName, string ProjectCostTypeDisplayName, int sortOrder)
            : this()
        {
            this.ProjectCostTypeID = ProjectCostTypeID;
            this.ProjectCostTypeName = ProjectCostTypeName;
            this.ProjectCostTypeDisplayName = ProjectCostTypeDisplayName;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectCostTypeSimple(ProjectCostType ProjectCostType)
            : this()
        {
            this.ProjectCostTypeID = ProjectCostType.ProjectCostTypeID;
            this.ProjectCostTypeName = ProjectCostType.ProjectCostTypeName;
            this.ProjectCostTypeDisplayName = ProjectCostType.ProjectCostTypeDisplayName;
            this.SortOrder = ProjectCostType.SortOrder;
        }

        public int ProjectCostTypeID { get; set; }
        public string ProjectCostTypeName { get; set; }
        public string ProjectCostTypeDisplayName { get; set; }
        public int SortOrder { get; set; }
    }
}
