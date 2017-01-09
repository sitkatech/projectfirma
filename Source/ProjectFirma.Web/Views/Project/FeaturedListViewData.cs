using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Project
{
    public class FeaturedListViewData : FirmaViewData
    {
        public readonly FeaturesListProjectGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public FeaturedListViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {
            PageTitle = "Featured Projects";
            GridName = "featuredListGrid";
            GridSpec = new FeaturesListProjectGridSpec(currentPerson)
            {
                ObjectNameSingular = "Featured Project",
                ObjectNamePlural = "Featured Projects",
                SaveFiltersInCookie = true,
                CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.EditFeaturedProjects()), "Edit Featured Projects"),
                CreateEntityActionPhrase = "Add/Remove Featured Projects"
            };
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.FeaturedListGridJsonData());
        }
    }

    public class FeaturesListProjectGridSpec : BasicProjectInfoGridSpec
    {
        public FeaturesListProjectGridSpec(Person currentPerson)
            : base(currentPerson, true)
        {
            Add("# of Photos", x => x.ProjectImages.Count, 100);
            Add(string.Format("Reported {0}", MultiTenantHelpers.GetPerformanceMeasureNamePluralized()), x => string.Join(", ", x.PerformanceMeasureActuals.Select(pm => pm.PerformanceMeasureID).Distinct().OrderBy(pmID => pmID)), 100);
        }
    }
}