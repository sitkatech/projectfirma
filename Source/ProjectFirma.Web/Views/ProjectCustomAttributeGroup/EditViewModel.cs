using System;
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
using ProjectFirma.Web.Views.ProjectCreate;
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

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectCategory)]
        public List<ProjectCategoryEnum> ProjectCategoryEnums { get; set; }

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
            ProjectCategoryEnums = projectCustomAttributeGroup.ProjectCustomAttributeGroupProjectCategories.Select(x => x.ProjectCategory.ToEnum).ToList();
        }


        public void UpdateModel(ProjectFirmaModels.Models.ProjectCustomAttributeGroup projectCustomAttributeGroup, FirmaSession currentFirmaSession)
        {
            projectCustomAttributeGroup.ProjectCustomAttributeGroupName = ProjectCustomAttributeGroupName; 

            List<ProjectCustomAttributeGroupProjectCategory> updatedProjectCustomAttributeGroupProjectCategories = new List<ProjectCustomAttributeGroupProjectCategory>();
            foreach (var projectCategoryEnum in ProjectCategoryEnums)
            {
                var projectCustomAttributeGroupProjectType = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroupProjectCategories
                                                                                                .FirstOrDefault(x => 
                                                                                                                x.ProjectCategoryID == (int)projectCategoryEnum && 
                                                                                                                x.ProjectCustomAttributeGroupID == ProjectCustomAttributeGroupID);

                if (projectCustomAttributeGroupProjectType == null)
                {
                    projectCustomAttributeGroupProjectType = new ProjectCustomAttributeGroupProjectCategory(ProjectCustomAttributeGroupID, (int)projectCategoryEnum);
                }

                updatedProjectCustomAttributeGroupProjectCategories.Add(projectCustomAttributeGroupProjectType);
            }
            var allProjectCustomAttributeGroupProjectCategories = HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeGroupProjectCategories.Local;

            projectCustomAttributeGroup.ProjectCustomAttributeGroupProjectCategories.Merge(
                updatedProjectCustomAttributeGroupProjectCategories,
                allProjectCustomAttributeGroupProjectCategories,
                (x, y) => x.ProjectCustomAttributeGroupProjectCategoryID == y.ProjectCustomAttributeGroupProjectCategoryID, HttpRequestStorage.DatabaseEntities);


            if (projectCustomAttributeGroup.SortOrder != null) return;
            var allProjectCustomAttributeGroups = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroups;
            var maxSortOrder = allProjectCustomAttributeGroups.Select(x => x.SortOrder).Max();
            projectCustomAttributeGroup.SortOrder = maxSortOrder + EditSortOrderViewModel.SortOrderIncrement;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var ProjectCategoryEnum in ProjectCategoryEnums)
            {
                if (!Enum.IsDefined(typeof(ProjectCategoryEnum), ProjectCategoryEnum))
                {
                    yield return new SitkaValidationResult<EditViewModel, List<ProjectCategoryEnum>>($"A valid value for {FieldDefinitionEnum.ProjectCategory.ToType().GetFieldDefinitionLabel()} is required.", m => m.ProjectCategoryEnums);
                }
            }
        }
    }
}
