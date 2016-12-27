using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> TaxonomyTierOnes;
        public readonly IEnumerable<SelectListItem> StartYearRange;
        public readonly IEnumerable<SelectListItem> CompletionYearRange;
        public readonly IEnumerable<SelectListItem> ProjectStages;
        public readonly IEnumerable<SelectListItem> FundingTypes;
        public readonly IEnumerable<SelectListItem> Organizations;
        public readonly EditProjectType EditProjectType;
        public readonly string TaxonomyTierOneDisplayName;
        public readonly decimal? TotalExpenditures;
        public readonly bool HasExistingProjectBudgetUpdates;

        public EditProjectViewData(EditProjectType editProjectType,
            string taxonomyTierOneDisplayName,
            IEnumerable<ProjectStage> projectStages,
            IEnumerable<FundingType> fundingTypes,
            IEnumerable<Models.Organization> organizations,
            decimal? totalExpenditures,
            bool hasExistingProjectBudgetUpdates)
        {
            EditProjectType = editProjectType;
            TaxonomyTierOneDisplayName = taxonomyTierOneDisplayName;
            TotalExpenditures = totalExpenditures;
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);
            FundingTypes = fundingTypes.OrderBy(x => x.SortOrder).ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            Organizations = organizations.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), y => y.DisplayName);
            TaxonomyTierOnes = HttpRequestStorage.DatabaseEntities.TaxonomyTierOnes.ToList().OrderBy(ap => ap.DisplayName).ToList().ToGroupedSelectList();
            StartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            HasExistingProjectBudgetUpdates = hasExistingProjectBudgetUpdates;
        }
    }
}