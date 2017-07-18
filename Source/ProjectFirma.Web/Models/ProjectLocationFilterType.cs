/*-----------------------------------------------------------------------
<copyright file="ProjectLocationFilterType.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;
using System.Linq.Expressions;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationFilterType
    {
        public abstract Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues);
        public abstract string DisplayName { get; }
    }

    public partial class ProjectLocationFilterTypeTaxonomyTierThree
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThreeID);
        }

        public override string DisplayName
        {
            get { return FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabel(); }
        }
    }

    public partial class ProjectLocationFilterTypeTaxonomyTierTwo
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.TaxonomyTierOne.TaxonomyTierTwoID);
        }

        public override string DisplayName
        {
            get { return FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel(); }
        }
    }

    public partial class ProjectLocationFilterTypeTaxonomyTierOne
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.TaxonomyTierOneID);
        }

        public override string DisplayName
        {
            get { return FieldDefinition.TaxonomyTierOne.GetFieldDefinitionLabel(); }
        }
    }

    public partial class ProjectLocationFilterTypeClassification
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Intersect(project.ProjectClassifications.Select(x => x.ClassificationID)).Any();
        }

        public override string DisplayName
        {
            get { return ProjectLocationFilterTypeDisplayName; }
        }
    }

    public partial class ProjectLocationFilterTypeProjectStage
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.ProjectStageID);
        }

        public override string DisplayName
        {
            get { return ProjectLocationFilterTypeDisplayName; }
        }
    }
  
}
