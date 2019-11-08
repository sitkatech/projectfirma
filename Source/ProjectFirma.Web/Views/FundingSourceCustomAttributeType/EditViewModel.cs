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

namespace ProjectFirma.Web.Views.FundingSourceCustomAttributeType
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int FundingSourceCustomAttributeTypeID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.FundingSourceCustomAttributeType.FieldLengths.FundingSourceCustomAttributeTypeName)]
        [DisplayName("Name of Attribute")]
        public string FundingSourceCustomAttributeTypeName { get; set; }

        [Required(ErrorMessage = "Specify data type for this custom attribute")]
        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingSourceCustomAttributeDataType)]
        public int? FundingSourceCustomAttributeDataTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.MeasurementUnit)]
        public int? MeasurementUnitTypeID { get; set; }

        [DisplayName("Options")]
        public string FundingSourceCustomAttributeTypeOptionsSchema { get; set; }
        
        [Required(ErrorMessage = "Specify whether the attribute is required or optional")]
        [DisplayName("Required?")]
        public bool? IsRequired { get; set; }

        [DisplayName("Description")]
        [StringLength(ProjectFirmaModels.Models.FundingSourceCustomAttributeType.FieldLengths.FundingSourceCustomAttributeTypeDescription)]
        public string FundingSourceCustomAttributeTypeDesription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.NormalUser)]
        public bool EditableByNormal { get; set; }
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectSteward)]
        public bool EditableByProjectSteward { get; set; }
        [DisplayName("Unassigned")]
        public bool ViewableByUnassigned { get; set; }
        [FieldDefinitionDisplay(FieldDefinitionEnum.NormalUser)]
        public bool ViewableByNormal { get; set; }
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectSteward)]
        public bool ViewableByProjectSteward { get; set; }
        [Required]
        public bool FundingSourceCustomAttributeIncludeInGridSpec { get; set; }



        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.FundingSourceCustomAttributeType fundingSourceCustomAttributeType)
        {
            FundingSourceCustomAttributeTypeID = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID;
            FundingSourceCustomAttributeTypeName = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeName;
            FundingSourceCustomAttributeDataTypeID = fundingSourceCustomAttributeType.FundingSourceCustomAttributeDataTypeID;
            MeasurementUnitTypeID = fundingSourceCustomAttributeType.MeasurementUnitTypeID;
            FundingSourceCustomAttributeTypeOptionsSchema = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeOptionsSchema;
            IsRequired = fundingSourceCustomAttributeType.IsRequired;
            FundingSourceCustomAttributeTypeDesription = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeDescription;
            FundingSourceCustomAttributeIncludeInGridSpec = fundingSourceCustomAttributeType.IncludeInFundingSourceGrid;
            EditableByNormal = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeRoles.Any(x => x.FundingSourceCustomAttributeTypeRolePermissionType == FundingSourceCustomAttributeTypeRolePermissionType.Edit && x.RoleID == ProjectFirmaModels.Models.Role.Normal.RoleID);
            EditableByProjectSteward = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeRoles.Any(x => x.FundingSourceCustomAttributeTypeRolePermissionType == FundingSourceCustomAttributeTypeRolePermissionType.Edit && x.RoleID == ProjectFirmaModels.Models.Role.ProjectSteward.RoleID);
            ViewableByUnassigned = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeRoles.Any(x => x.FundingSourceCustomAttributeTypeRolePermissionType == FundingSourceCustomAttributeTypeRolePermissionType.View && x.RoleID == ProjectFirmaModels.Models.Role.Unassigned.RoleID);
            ViewableByNormal = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeRoles.Any(x => x.FundingSourceCustomAttributeTypeRolePermissionType == FundingSourceCustomAttributeTypeRolePermissionType.View && x.RoleID == ProjectFirmaModels.Models.Role.Normal.RoleID);
            ViewableByProjectSteward = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeRoles.Any(x => x.FundingSourceCustomAttributeTypeRolePermissionType == FundingSourceCustomAttributeTypeRolePermissionType.View && x.RoleID == ProjectFirmaModels.Models.Role.ProjectSteward.RoleID);

        }


        public void UpdateModel(ProjectFirmaModels.Models.FundingSourceCustomAttributeType fundingSourceCustomAttributeType, FirmaSession currentFirmaSession)
        {
            fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeName = FundingSourceCustomAttributeTypeName;
            fundingSourceCustomAttributeType.FundingSourceCustomAttributeDataTypeID = FundingSourceCustomAttributeDataTypeID ?? ModelObjectHelpers.NotYetAssignedID;
            fundingSourceCustomAttributeType.MeasurementUnitTypeID = MeasurementUnitTypeID;
            fundingSourceCustomAttributeType.IsRequired = IsRequired.GetValueOrDefault();
            fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeDescription = FundingSourceCustomAttributeTypeDesription;
            fundingSourceCustomAttributeType.IncludeInFundingSourceGrid = FundingSourceCustomAttributeIncludeInGridSpec;

            var fundingSourceCustomAttributeDataType = FundingSourceCustomAttributeDataTypeID != null
                ? FundingSourceCustomAttributeDataType.AllLookupDictionary[FundingSourceCustomAttributeDataTypeID.Value]
                : null;
            if (fundingSourceCustomAttributeDataType != null && fundingSourceCustomAttributeDataType.HasOptions())
            {
                fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeOptionsSchema = FundingSourceCustomAttributeTypeOptionsSchema;
            }
            else
            {
                fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeOptionsSchema = null;
            }

            var newFundingSourceCustomAttributeTypeRoles = new List<FundingSourceCustomAttributeTypeRole>();
            if (this.EditableByNormal == true)
            {
                newFundingSourceCustomAttributeTypeRoles.Add(new FundingSourceCustomAttributeTypeRole(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID, ProjectFirmaModels.Models.Role.Normal.RoleID, FundingSourceCustomAttributeTypeRolePermissionType.Edit.FundingSourceCustomAttributeTypeRolePermissionTypeID));
            }
            if (this.EditableByProjectSteward == true) { 
                newFundingSourceCustomAttributeTypeRoles.Add(new FundingSourceCustomAttributeTypeRole(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID, ProjectFirmaModels.Models.Role.ProjectSteward.RoleID, FundingSourceCustomAttributeTypeRolePermissionType.Edit.FundingSourceCustomAttributeTypeRolePermissionTypeID));
            }
            if (this.ViewableByUnassigned == true) { 
                newFundingSourceCustomAttributeTypeRoles.Add(new FundingSourceCustomAttributeTypeRole(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID, ProjectFirmaModels.Models.Role.Unassigned.RoleID, FundingSourceCustomAttributeTypeRolePermissionType.View.FundingSourceCustomAttributeTypeRolePermissionTypeID));
            }
            if (this.ViewableByNormal == true) { 
                newFundingSourceCustomAttributeTypeRoles.Add(new FundingSourceCustomAttributeTypeRole(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID, ProjectFirmaModels.Models.Role.Normal.RoleID, FundingSourceCustomAttributeTypeRolePermissionType.View.FundingSourceCustomAttributeTypeRolePermissionTypeID));
            }
            if (this.ViewableByProjectSteward == true) { 
                newFundingSourceCustomAttributeTypeRoles.Add(new FundingSourceCustomAttributeTypeRole(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID, ProjectFirmaModels.Models.Role.ProjectSteward.RoleID, FundingSourceCustomAttributeTypeRolePermissionType.View.FundingSourceCustomAttributeTypeRolePermissionTypeID));
            }

            fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeRoles.Merge(newFundingSourceCustomAttributeTypeRoles,
                HttpRequestStorage.DatabaseEntities.AllFundingSourceCustomAttributeTypeRoles.Local,
                (x, y) => x.FundingSourceCustomAttributeTypeID == y.FundingSourceCustomAttributeTypeID && x.RoleID == y.RoleID &&
                          x.FundingSourceCustomAttributeTypeRolePermissionTypeID ==
                          y.FundingSourceCustomAttributeTypeRolePermissionTypeID, HttpRequestStorage.DatabaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes
                .Where(x => x.FundingSourceCustomAttributeTypeName == FundingSourceCustomAttributeTypeName)
                .Any(x => x.FundingSourceCustomAttributeTypeID != FundingSourceCustomAttributeTypeID))
            {
                yield return new ValidationResult($"A {FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabel()} with this name already exists.");
            }

            if (ModelObjectHelpers.IsRealPrimaryKeyValue(FundingSourceCustomAttributeTypeID))
            {
                var type = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.GetFundingSourceCustomAttributeType(FundingSourceCustomAttributeTypeID);
                var isStringType = type.FundingSourceCustomAttributeDataType == FundingSourceCustomAttributeDataType.String;
                if (!isStringType && type.FundingSourceCustomAttributeDataTypeID != FundingSourceCustomAttributeDataTypeID)
                {
                    yield return new ValidationResult("You cannot change the type of attribute.");
                }

                var updatedTypeIsStringPickFromListOrMultiselect = FundingSourceCustomAttributeDataTypeID == FundingSourceCustomAttributeDataType.String.FundingSourceCustomAttributeDataTypeID ||
                                                                   FundingSourceCustomAttributeDataTypeID == FundingSourceCustomAttributeDataType.PickFromList.FundingSourceCustomAttributeDataTypeID ||
                                                                   FundingSourceCustomAttributeDataTypeID == FundingSourceCustomAttributeDataType.MultiSelect.FundingSourceCustomAttributeDataTypeID;
                if (isStringType && !updatedTypeIsStringPickFromListOrMultiselect)
                {
                    yield return new ValidationResult("You cannot change a String attribute to any other than a single or multi select list.");
                }
            }

            var fundingSourceCustomAttributeDataType = FundingSourceCustomAttributeDataTypeID != null
                ? FundingSourceCustomAttributeDataType.AllLookupDictionary[FundingSourceCustomAttributeDataTypeID.Value]
                : null;
            if (fundingSourceCustomAttributeDataType != null && fundingSourceCustomAttributeDataType.HasOptions())
            {
                List<string> options = null;
                try
                {
                    options = JsonConvert.DeserializeObject<List<string>>(FundingSourceCustomAttributeTypeOptionsSchema);
                }
                catch { /* ignored */ }

                if (options == null)
                {
                    yield return new ValidationResult("Options cannot be saved.");
                    yield break;
                }

                if (options.Any(string.IsNullOrEmpty))
                {
                    yield return new ValidationResult("Options cannot be empty.");
                }

                if (options.Count.Equals(0))
                {
                    yield return new ValidationResult("This type of attribute must have options defined.");
                }

                if (fundingSourceCustomAttributeDataType == FundingSourceCustomAttributeDataType.MultiSelect && options.Count == 1)
                {
                    yield return new ValidationResult("This type of attribute must have more than one option defined.");
                }

                if (options.Select(x => x.ToLower()).HasDuplicates())
                {
                    yield return new ValidationResult("Options must be unique, remove duplicates.");
                }
            }
        }
    }
}
