using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class BasicsViewData : ProposedProjectViewData
    {
        public IEnumerable<SelectListItem> ActionPriorities;
        public IEnumerable<SelectListItem> Organizations;
        public IEnumerable<SelectListItem> FundingTypes;
        public IEnumerable<SelectListItem> StartYearRange;
        public IEnumerable<SelectListItem> CompletionYearRange;

        public BasicsViewData(Person currentPerson, IEnumerable<Models.Organization> organizations, IEnumerable<FundingType> fundingTypes, IEnumerable<Models.ActionPriority> actionPriorities)
            : base(currentPerson, ProposedProjectSectionEnum.Basics)
        {
            AssignParameters(actionPriorities, organizations, fundingTypes);
        }

        public BasicsViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProposalSectionsStatus proposalSectionsStatus,
            IEnumerable<Models.Organization> organizations,
            IEnumerable<FundingType> fundingTypes, IEnumerable<Models.ActionPriority> actionPriorities)
            : base(currentPerson, proposedProject, ProposedProjectSectionEnum.Basics, proposalSectionsStatus)
        {
            AssignParameters(actionPriorities, organizations, fundingTypes);
        }

        private void AssignParameters(IEnumerable<Models.ActionPriority> actionPriorities, IEnumerable<Models.Organization> organizations, IEnumerable<FundingType> fundingTypes)
        {
            ActionPriorities = actionPriorities.ToList().OrderBy(ap => ap.DisplayName).ToList().ToGroupedSelectList();
            Organizations = organizations.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), y => y.DisplayName);

            FundingTypes = fundingTypes.ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            StartYearRange =
                FirmaDateUtilities.GetRangeOfYears(FirmaDateUtilities.MinimumYearForReporting, DateTime.Now.Year + FirmaDateUtilities.YearsBeyondPresentForMaximumYearForUserInput)
                    .ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = FirmaDateUtilities.FutureYearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
        }
    }
}