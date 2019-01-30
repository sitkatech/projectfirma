/*-----------------------------------------------------------------------
<copyright file="ProjectLocation.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Spatial;
using LtInfo.Common.DbSpatial;
using Microsoft.SqlServer.Types;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectLocation : IAuditableEntity, IProjectLocation, IHaveSqlGeometry
    {
        public ProjectLocation(Project project, DbGeometry projectLocationGeometry, string annotation) : this(project, projectLocationGeometry)
        {
            Annotation = annotation;
        }

        public string GetAuditDescriptionString()
        {
            return "Shape deleted";
        }

        public DbGeometry GetProjectLocationGeometry() => ProjectLocationGeometry;

        public void SetDbGeometry(DbGeometry value)
        {
            ProjectLocationGeometry = value;
        }

        public DbGeometry GetDbGeometry()
        {
            return ProjectLocationGeometry;
        }

        public SqlGeometry GetSqlGeometry()
        {
            return ProjectLocationGeometry.ToSqlGeometry();
        }
    }
}
