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
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectType)]
        public List<ProjectTypeEnum> ProjectTypeEnums { get; set; }

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
            ProjectTypeEnums = projectCustomAttributeGroup.ProjectCustomAttributeGroupProjectTypes.Select(x => x.ProjectType.ToEnum).ToList();
        }


        public void UpdateModel(ProjectFirmaModels.Models.ProjectCustomAttributeGroup projectCustomAttributeGroup, FirmaSession currentFirmaSession)
        {
            projectCustomAttributeGroup.ProjectCustomAttributeGroupName = ProjectCustomAttributeGroupName; 

            List<ProjectCustomAttributeGroupProjectType> updatedProjectCustomAttributeGroupProjectTypes = new List<ProjectCustomAttributeGroupProjectType>();
            foreach (var projectTypeEnum in ProjectTypeEnums)
            {
                var projectCustomAttributeGroupProjectType = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroupProjectTypes
                                                                                                .FirstOrDefault(x => 
                                                                                                                x.ProjectTypeID == (int)projectTypeEnum && 
                                                                                                                x.ProjectCustomAttributeGroupID == ProjectCustomAttributeGroupID);

                if (projectCustomAttributeGroupProjectType == null)
                {
                    projectCustomAttributeGroupProjectType = new ProjectCustomAttributeGroupProjectType(ProjectCustomAttributeGroupID, (int)projectTypeEnum);
                }

                updatedProjectCustomAttributeGroupProjectTypes.Add(projectCustomAttributeGroupProjectType);
            }
            var allProjectCustomAttributeGroupProjectTypes = HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeGroupProjectTypes.Local;

            projectCustomAttributeGroup.ProjectCustomAttributeGroupProjectTypes.Merge(
                updatedProjectCustomAttributeGroupProjectTypes,
                allProjectCustomAttributeGroupProjectTypes,
                (x, y) => x.ProjectCustomAttributeGroupProjectTypeID == y.ProjectCustomAttributeGroupProjectTypeID, HttpRequestStorage.DatabaseEntities);


            if (projectCustomAttributeGroup.SortOrder != null) return;
            var allProjectCustomAttributeGroups = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroups;
            var maxSortOrder = allProjectCustomAttributeGroups.Select(x => x.SortOrder).Max();
            projectCustomAttributeGroup.SortOrder = maxSortOrder + EditSortOrderViewModel.SortOrderIncrement;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var projectTypeEnum in ProjectTypeEnums)
            {
                if (!Enum.IsDefined(typeof(ProjectTypeEnum), projectTypeEnum))
                {
                    yield return new SitkaValidationResult<EditViewModel, List<ProjectTypeEnum>>($"A valid value for {FieldDefinitionEnum.ProjectType.ToType().GetFieldDefinitionLabel()} is required.", m => m.ProjectTypeEnums);
                }
            }
        }
    }
}
