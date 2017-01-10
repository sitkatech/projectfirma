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
            get { return MultiTenantHelpers.GetTaxonomyTierThreeDisplayName(); }
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
            get { return MultiTenantHelpers.GetTaxonomyTierTwoDisplayName(); }
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
            get { return MultiTenantHelpers.GetTaxonomyTierOneDisplayName(); }
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

    public partial class ProjectLocationFilterTypeImplementingOrganization
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Intersect(project.ProjectImplementingOrganizations.Select(x => x.OrganizationID)).Any();
        }

        public override string DisplayName
        {
            get { return ProjectLocationFilterTypeDisplayName; }
        }
    }

    public partial class ProjectLocationFilterTypeFundingOrganization
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Intersect(project.ProjectFundingOrganizations.Select(x => x.OrganizationID)).Any();
        }

        public override string DisplayName
        {
            get { return ProjectLocationFilterTypeDisplayName; }
        }
    }
}