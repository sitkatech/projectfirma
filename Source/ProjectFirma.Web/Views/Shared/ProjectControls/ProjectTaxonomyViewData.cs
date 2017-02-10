using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ProjectTaxonomyViewData : FirmaUserControlViewData
    {
        public readonly Models.TaxonomyTierThree TaxonomyTierThree;
        public readonly Models.TaxonomyTierTwo TaxonomyTierTwo;
        public readonly Models.TaxonomyTierOne TaxonomyTierOne;
        public readonly Models.Project Project;

        public readonly bool IsProject;
        public readonly bool IsTaxonomyTierOne;
        public readonly bool IsTaxonomyTierTwo;
        public readonly bool IsTaxonomyTierThree;

        public ProjectTaxonomyViewData(Models.TaxonomyTierThree taxonomyTierThree) : this(taxonomyTierThree, null, null, null)
        {
        }

        public ProjectTaxonomyViewData(Models.TaxonomyTierTwo taxonomyTierTwo) : this(taxonomyTierTwo.TaxonomyTierThree, taxonomyTierTwo, null, null)
        {
        }

        public ProjectTaxonomyViewData(Models.TaxonomyTierOne taxonomyTierOne) : this(taxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree, taxonomyTierOne.TaxonomyTierTwo, taxonomyTierOne, null)
        {
        }

        public ProjectTaxonomyViewData(Models.Project project) : this(project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree, project.TaxonomyTierOne.TaxonomyTierTwo, project.TaxonomyTierOne, project)
        {
        }

        private ProjectTaxonomyViewData(Models.TaxonomyTierThree taxonomyTierThree, Models.TaxonomyTierTwo taxonomyTierTwo, Models.TaxonomyTierOne taxonomyTierOne, Models.Project project)
        {
            TaxonomyTierOne = taxonomyTierOne;
            TaxonomyTierThree = taxonomyTierThree;
            TaxonomyTierTwo = taxonomyTierTwo;
            Project = project;
            IsProject = Project != null;
            IsTaxonomyTierOne = TaxonomyTierOne != null && !IsProject;
            IsTaxonomyTierTwo = TaxonomyTierTwo != null && !IsTaxonomyTierOne && !IsProject;
            IsTaxonomyTierThree = TaxonomyTierThree != null && !IsTaxonomyTierTwo && !IsTaxonomyTierOne && !IsProject;

            if (HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.Count() <= 1 && !IsTaxonomyTierThree)
            {
                TaxonomyTierThree = null;
            }
        }
    }
}