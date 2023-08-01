/*-----------------------------------------------------------------------
<copyright file="EditAttachmentTypeViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AttachmentType
{
    public class EditAttachmentTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int AttachmentTypeID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.AttachmentType.FieldLengths.AttachmentTypeName)]
        [DisplayName("Name")]
        public string AttachmentTypeName { get; set; }

        [Required]
        [DisplayName("Attachment Type Description")]
        public string AttachmentTypeDescription { get; set; }

        [Required]
        [DisplayName("Can Be of the Following File Types")]
        public List<int> FileResourceMimeTypeIDs { get; set; }

        [Required]
        public List<int> TaxonomyTrunkIDs { get; set; }
        
        [Required]
        [DisplayName("Max File Size")]
        public int MaxFileSize { get; set; }

        [DisplayName("Maximum Number of Allowed Attachments per Project")]
        public int? NumberOfAllowedAttachments { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.QuickAccessAttachment)]
        public bool IsQuickAccessAttachment { get; set; }

        [DisplayName("Anonymous (Public)")]
        public bool ViewableByAnonymous { get; set; }

        [DisplayName("Unassigned")]
        public bool ViewableByUnassigned { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.NormalUser)]
        public bool ViewableByNormal { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectSteward)]
        public bool ViewableByProjectSteward { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditAttachmentTypeViewModel()
        {
            FileResourceMimeTypeIDs = new List<int>();
            TaxonomyTrunkIDs = new List<int>();
            if (!MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                var defaultTaxonomyTrunk = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.FirstOrDefault();
                if (defaultTaxonomyTrunk != null)
                {
                    TaxonomyTrunkIDs.Add(defaultTaxonomyTrunk.TaxonomyTrunkID);
                }
                else
                {
                    throw new Exception($"You do not have a default Taxonomy Trunk configured. Please set one up for {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabelPluralized()} to function completely.");
                }
            }
        }

        public EditAttachmentTypeViewModel(ProjectFirmaModels.Models.AttachmentType attachmentType)
        {
            AttachmentTypeID = attachmentType.AttachmentTypeID;
            AttachmentTypeName = attachmentType.AttachmentTypeName;
            AttachmentTypeDescription = attachmentType.AttachmentTypeDescription;
            NumberOfAllowedAttachments = attachmentType.NumberOfAllowedAttachments;
            MaxFileSize = attachmentType.MaxFileSize;
            FileResourceMimeTypeIDs = attachmentType.AttachmentTypeFileResourceMimeTypes.Select(x => x.FileResourceMimeTypeID).ToList();
            TaxonomyTrunkIDs = attachmentType.AttachmentTypeTaxonomyTrunks.Select(x => x.TaxonomyTrunkID).ToList();
            IsQuickAccessAttachment = attachmentType.IsQuickAccessAttachment;

            ViewableByAnonymous = attachmentType.AttachmentTypeRoles.Any(x => x.RoleID == null);
            ViewableByUnassigned = attachmentType.AttachmentTypeRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Unassigned.RoleID);
            ViewableByNormal = attachmentType.AttachmentTypeRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Normal.RoleID);
            ViewableByProjectSteward = attachmentType.AttachmentTypeRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.ProjectSteward.RoleID);

        }

        public void UpdateModel(ProjectFirmaModels.Models.AttachmentType attachmentType, 
                                ICollection<AttachmentTypeFileResourceMimeType> allAttachmentTypeFileResourceMimeTypes,
                                ICollection<AttachmentTypeTaxonomyTrunk> allAttachmentTypeTaxonomyTrunks,
                                ICollection<AttachmentTypeRole> allAttachmentTypeRoles)
        {
            attachmentType.AttachmentTypeName = AttachmentTypeName;

            attachmentType.AttachmentTypeDescription = AttachmentTypeDescription;

            attachmentType.NumberOfAllowedAttachments = NumberOfAllowedAttachments;

            attachmentType.MaxFileSize = MaxFileSize;

            var fileResourceMimeTypesUpdated = FileResourceMimeTypeIDs.Select(x => new AttachmentTypeFileResourceMimeType( attachmentType.AttachmentTypeID, x)).ToList();
            attachmentType.AttachmentTypeFileResourceMimeTypes.Merge(fileResourceMimeTypesUpdated,
                allAttachmentTypeFileResourceMimeTypes,
                (x, y) => x.AttachmentTypeID == y.AttachmentTypeID && x.FileResourceMimeTypeID == y.FileResourceMimeTypeID, HttpRequestStorage.DatabaseEntities);

            var taxonomyTrunksUpdated = TaxonomyTrunkIDs.Select(x => new AttachmentTypeTaxonomyTrunk(attachmentType.AttachmentTypeID, x)).ToList();
            attachmentType.AttachmentTypeTaxonomyTrunks.Merge(taxonomyTrunksUpdated,
                allAttachmentTypeTaxonomyTrunks,
                (x, y) => x.AttachmentTypeID == y.AttachmentTypeID && x.TaxonomyTrunkID == y.TaxonomyTrunkID, HttpRequestStorage.DatabaseEntities);

            attachmentType.IsQuickAccessAttachment = IsQuickAccessAttachment;

            var newAttachmentTypeRoles = new List<AttachmentTypeRole>();

            if (ViewableByAnonymous)
            {
                newAttachmentTypeRoles.Add(new AttachmentTypeRole(attachmentType.AttachmentTypeID));
            }
            if (ViewableByUnassigned)
            {
                newAttachmentTypeRoles.Add(new AttachmentTypeRole(attachmentType.AttachmentTypeID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Unassigned.RoleID
                });
            }
            if (ViewableByNormal)
            {
                newAttachmentTypeRoles.Add(new AttachmentTypeRole(attachmentType.AttachmentTypeID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Normal.RoleID
                });
            }
            if (ViewableByProjectSteward)
            {
                newAttachmentTypeRoles.Add(new AttachmentTypeRole(attachmentType.AttachmentTypeID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.ProjectSteward.RoleID
                });
            }

            attachmentType.AttachmentTypeRoles.Merge(newAttachmentTypeRoles,
                allAttachmentTypeRoles,
                (x, y) => x.AttachmentTypeID == y.AttachmentTypeID && x.RoleID == y.RoleID,
                HttpRequestStorage.DatabaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var attachmentTypes = HttpRequestStorage.DatabaseEntities.AttachmentTypes.ToList();
            if (!attachmentTypes.IsAttachmentTypeNameUnique(AttachmentTypeName, AttachmentTypeID))
            {
                yield return new SitkaValidationResult<EditAttachmentTypeViewModel, string>("Name already exists.",
                    x => x.AttachmentTypeName);
            }

            if (!TaxonomyTrunkIDs.Any())
            {
                yield return new SitkaValidationResult<EditAttachmentTypeViewModel, List<int>>($"Please select at least one {FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel()} for this {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()}",
                    x => x.TaxonomyTrunkIDs);
            }

            if (!FileResourceMimeTypeIDs.Any())
            {
                yield return new SitkaValidationResult<EditAttachmentTypeViewModel, List<int>>($"Please select at least one file type for this {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()}",
                    x => x.FileResourceMimeTypeIDs);
            }

            if (IsQuickAccessAttachment)
            {
                if (!NumberOfAllowedAttachments.HasValue || NumberOfAllowedAttachments.Value != 1)
                {
                    yield return new SitkaValidationResult<EditAttachmentTypeViewModel, int?>(
                        "'Maximum Number of Allowed Attachments per Project' must be set to 1 when Quick Link is enabled for Attachment Type.",
                        x => x.NumberOfAllowedAttachments);
                }

                if (attachmentTypes.Any(x => x.AttachmentTypeID != AttachmentTypeID && x.IsQuickAccessAttachment))
                {
                    var attachmentType = attachmentTypes.Single(x => x.IsQuickAccessAttachment);
                    yield return new SitkaValidationResult<EditAttachmentTypeViewModel, bool>(
                        $"'{FieldDefinitionEnum.QuickAccessAttachment.ToType().GetFieldDefinitionLabel()}' can only be set to 'Yes' for one Attachment Type at a time. '{attachmentType.AttachmentTypeName}' is already has this set to 'Yes'.",
                        x => x.IsQuickAccessAttachment);
                }
            }
        }
    }
}
