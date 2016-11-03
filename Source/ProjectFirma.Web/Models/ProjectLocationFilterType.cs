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

    public partial class ProjectLocationFilterTypeFocusArea
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.ActionPriority.Program.FocusAreaID);
        }
    }

    public partial class ProjectLocationFilterTypeProgram
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.ActionPriority.ProgramID);
        }
    }

    public partial class ProjectLocationFilterTypeActionPriority
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.ActionPriorityID);
        }
    }

    public partial class ProjectLocationFilterTypeThresholdCategory
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Intersect(project.ProjectThresholdCategories.Select(x => x.ThresholdCategoryID)).Any();
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