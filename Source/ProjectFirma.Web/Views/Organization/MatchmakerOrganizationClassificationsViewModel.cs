using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class MatchmakerOrganizationClassificationsViewModel : FormViewModel
    {
        public List<SitkaLeftRightListbox> ClassificationSystemListboxes { get; set; }

        public MatchmakerOrganizationClassificationsViewModel()
        {

        }

        public MatchmakerOrganizationClassificationsViewModel(ProjectFirmaModels.Models.Organization organization, List<ProjectFirmaModels.Models.ClassificationSystem> allClassificationSystems)
        {
            ClassificationSystemListboxes = new List<SitkaLeftRightListbox>();
            foreach (var classificationSystem in allClassificationSystems)
            {
                var allSelectListItems = classificationSystem.Classifications.OrderBy(x => x.ClassificationSortOrder).ToList();
                var selectedClassifications = organization.MatchmakerOrganizationClassifications.Select(x => x.Classification).ToList();
                var selectListItems = allSelectListItems.ToSelectList(x => Convert.ToString(x.ClassificationID), x => x.DisplayName,
                    selectedClassifications.Select(y => Convert.ToString(y.ClassificationID)).ToList()).ToList();
                var sitkaLeftRightListbox = new SitkaLeftRightListbox($"ClassificationSystemID_{classificationSystem.ClassificationSystemID}",selectListItems);
                ClassificationSystemListboxes.Add(sitkaLeftRightListbox);
            }
        }

        public void UpdateModel(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Organization organization, DatabaseEntities databaseEntities)
        {
            var allCurrentMatchmakerClassifications =
                databaseEntities.MatchmakerOrganizationClassifications.Where(x =>
                    x.OrganizationID == organization.OrganizationID).ToList();

            var matchmakerOrganizationClassificationIDsSubmitted = new List<int>();
            if (ClassificationSystemListboxes != null)
            {
                matchmakerOrganizationClassificationIDsSubmitted.AddRange(ClassificationSystemListboxes.SelectMany(x => x.SelectedItems.Select(y => Int32.Parse(y))).ToList());
            }
            
            var matchmakerClassificationsToRemove = allCurrentMatchmakerClassifications.Where(x => !matchmakerOrganizationClassificationIDsSubmitted.Contains(x.ClassificationID));
            var matchmakerClassificationIDsToAdd = matchmakerOrganizationClassificationIDsSubmitted.Where(x =>
                !allCurrentMatchmakerClassifications.Select(y => y.ClassificationID).Contains(x)).ToList();

            foreach (var matchmakerOrganizationClassificationToRemove in matchmakerClassificationsToRemove)
            {
                matchmakerOrganizationClassificationToRemove.Delete(databaseEntities);
            }

            foreach (var classificationIDToAdd in matchmakerClassificationIDsToAdd)
            {
                organization.MatchmakerOrganizationClassifications.Add(new MatchmakerOrganizationClassification(organization.OrganizationID, classificationIDToAdd));
            }
        }
    }
}