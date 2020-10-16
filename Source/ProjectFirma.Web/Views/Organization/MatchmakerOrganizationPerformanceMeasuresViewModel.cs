using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class MatchmakerOrganizationPerformanceMeasuresViewModel : FormViewModel
    {
        public SitkaLeftRightListbox PerformanceMeasureListbox { get; set; }

        public MatchmakerOrganizationPerformanceMeasuresViewModel()
        {

        }

        public MatchmakerOrganizationPerformanceMeasuresViewModel(ProjectFirmaModels.Models.Organization organization, List<ProjectFirmaModels.Models.PerformanceMeasure> allPerformanceMeasures)
        {
            
            var allSelectListItems = allPerformanceMeasures.OrderBy(x => x.GetSortOrder()).ToList();
            var selectedClassifications = organization.MatchmakerOrganizationPerformanceMeasures.Select(x => x.PerformanceMeasure).ToList();
            var selectListItems = allSelectListItems.ToSelectList(x => Convert.ToString(x.PerformanceMeasureID), x => x.GetDisplayName(),
                selectedClassifications.Select(y => Convert.ToString(y.PerformanceMeasureID)).ToList()).ToList();
            PerformanceMeasureListbox = new SitkaLeftRightListbox("PerformanceMeasure", selectListItems); ;
        }

        public void UpdateModel(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Organization organization, DatabaseEntities databaseEntities)
        {
            var allCurrentMatchmakerPerformanceMeasures =
                databaseEntities.MatchmakerOrganizationPerformanceMeasures.Where(x =>
                    x.OrganizationID == organization.OrganizationID).ToList();

            var matchmakerOrganizationPerformanceMeasureIDsSubmitted = new List<int>();
            if (PerformanceMeasureListbox != null)
            {
                matchmakerOrganizationPerformanceMeasureIDsSubmitted.AddRange(PerformanceMeasureListbox.SelectedItems.Select(y => Int32.Parse(y)).ToList());
            }
            
            var matchmakerPerformanceMeasuresToRemove = allCurrentMatchmakerPerformanceMeasures.Where(x => !matchmakerOrganizationPerformanceMeasureIDsSubmitted.Contains(x.PerformanceMeasureID));
            var matchmakerPerformanceMeasureIDsToAdd = matchmakerOrganizationPerformanceMeasureIDsSubmitted.Where(x =>
                !allCurrentMatchmakerPerformanceMeasures.Select(y => y.PerformanceMeasureID).Contains(x)).ToList();

            foreach (var matchmakerOrganizationPerformanceMeasureToRemove in matchmakerPerformanceMeasuresToRemove)
            {
                matchmakerOrganizationPerformanceMeasureToRemove.Delete(databaseEntities);
            }

            foreach (var performanceMeasureIDToAdd in matchmakerPerformanceMeasureIDsToAdd)
            {
                organization.MatchmakerOrganizationPerformanceMeasures.Add(new MatchmakerOrganizationPerformanceMeasure(organization.OrganizationID, performanceMeasureIDToAdd));
            }
        }
    }
}