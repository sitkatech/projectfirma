using LtInfo.Common;
using LtInfo.Common.Models;
using Newtonsoft.Json;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeGroup
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int ProjectCustomAttributeGroupID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ProjectCustomAttributeGroup.FieldLengths.ProjectCustomAttributeGroupName)]
        [DisplayName("Name of Group")]
        public string ProjectCustomAttributeGroupName { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.ProjectCustomAttributeGroup projectCustomAttributeGroup)
        {
            ProjectCustomAttributeGroupID = projectCustomAttributeGroup.ProjectCustomAttributeGroupID;
            ProjectCustomAttributeGroupName = projectCustomAttributeGroup.ProjectCustomAttributeGroupName;
        }


        public void UpdateModel(ProjectFirmaModels.Models.ProjectCustomAttributeGroup projectCustomAttributeGroup, FirmaSession currentFirmaSession)
        {
            projectCustomAttributeGroup.ProjectCustomAttributeGroupName = ProjectCustomAttributeGroupName;
            if (projectCustomAttributeGroup.SortOrder != null) return;
            var allProjectCustomAttributeGroups = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroups;
            var maxSortOrder = allProjectCustomAttributeGroups.Select(x => x.SortOrder).Max();
            projectCustomAttributeGroup.SortOrder = maxSortOrder + EditSortOrderViewModel.SortOrderIncrement;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // todo: validate the group
            return new List<ValidationResult>();
        }
    }
}
