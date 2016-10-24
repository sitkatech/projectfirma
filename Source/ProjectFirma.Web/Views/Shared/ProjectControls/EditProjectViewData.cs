using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> ActionPriorities;
        public readonly IEnumerable<SelectListItem> StartYearRange;
        public readonly IEnumerable<SelectListItem> CompletionYearRange;
        public readonly IEnumerable<SelectListItem> ProjectStages;
        public readonly IEnumerable<SelectListItem> FundingTypes;
        public readonly IEnumerable<SelectListItem> Organizations;
        public readonly List<Models.TransportationObjective> TransportationObjectives;
        public readonly EditProjectType EditProjectType;
        public readonly string ActionPriorityDisplayName;
        public readonly string ProjectNumberString;
        public readonly decimal? TotalExpenditures;
        public readonly bool HasExistingTransportationProjectBudgetUpdates;

        public EditProjectViewData(IEnumerable<Models.ActionPriority> actionPriorities,
            EditProjectType editProjectType,
            string actionPriorityDisplayName,
            string projectNumberString,
            IEnumerable<ProjectStage> projectStages,
            IEnumerable<FundingType> fundingTypes,
            IEnumerable<Models.Organization> organizations,
            decimal? totalExpenditures,
            List<Models.TransportationObjective> transportationObjectives,
            bool hasExistingTransportationProjectBudgetUpdates)
        {
            EditProjectType = editProjectType;
            ActionPriorityDisplayName = actionPriorityDisplayName;
            ProjectNumberString = projectNumberString;
            TotalExpenditures = totalExpenditures;
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);
            FundingTypes = fundingTypes.OrderBy(x => x.SortOrder).ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            Organizations = organizations.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), y => y.DisplayName);
            ActionPriorities = HttpRequestStorage.DatabaseEntities.ActionPriorities.ToList().OrderBy(ap => ap.DisplayName).ToList().ToGroupedSelectList();
            //ActionPriorities = actionPriorities.ToList().OrderBy(ap => ap.DisplayName).ToList().ToGroupedSelectList();
            StartYearRange = ProjectFirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = ProjectFirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            TransportationObjectives = transportationObjectives;
            HasExistingTransportationProjectBudgetUpdates = hasExistingTransportationProjectBudgetUpdates;
        }
    }
}