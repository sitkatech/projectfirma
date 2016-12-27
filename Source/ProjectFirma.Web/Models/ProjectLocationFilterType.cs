using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationFilterType
    {
        public abstract Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues);
    }

    public partial class ProjectLocationFilterTypeTaxonomyTierThree
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThreeID);
        }
    }

    public partial class ProjectLocationFilterTypeTaxonomyTierTwo
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.TaxonomyTierOne.TaxonomyTierTwoID);
        }
    }

    public partial class ProjectLocationFilterTypeTaxonomyTierOne
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.TaxonomyTierOneID);
        }
    }

    public partial class ProjectLocationFilterTypeClassification
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Intersect(project.ProjectClassifications.Select(x => x.ClassificationID)).Any();
        }
    }

    public partial class ProjectLocationFilterTypeProjectStage
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.ProjectStageID);
        }
    }

    public partial class ProjectLocationFilterTypeImplementingOrganization
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Intersect(project.ProjectImplementingOrganizations.Select(x => x.OrganizationID)).Any();
        }
    }

    public partial class ProjectLocationFilterTypeFundingOrganization
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Intersect(project.ProjectFundingOrganizations.Select(x => x.OrganizationID)).Any();
        }
    }
}