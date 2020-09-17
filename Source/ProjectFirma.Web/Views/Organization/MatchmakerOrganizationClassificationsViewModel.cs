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
        public List<SitkaListbox> Listboxes { get; set; }

        public MatchmakerOrganizationClassificationsViewModel()
        {

        }

        public MatchmakerOrganizationClassificationsViewModel(ProjectFirmaModels.Models.Organization organization, List<ProjectFirmaModels.Models.ClassificationSystem> allClassificationSystems)
        {
            Listboxes = new List<SitkaListbox>();
            foreach (var classificationSystem in allClassificationSystems)
            {
                var allSelectListItems = classificationSystem.Classifications.ToList();
                var selectedClassifications = organization.MatchmakerOrganizationClassifications.Select(x => x.Classification).ToList();
                var selectListItems = allSelectListItems.ToSelectList(x => x.ClassificationID.ToString(), x => x.DisplayName,
                    selectedClassifications.Select(y => y.ClassificationID).ToList()).ToList();
                var listboxReal = new SitkaListbox($"ClassificationSystemID_{classificationSystem.ClassificationSystemID}",selectListItems);
                Listboxes.Add(listboxReal);
            }
        }
    }
}