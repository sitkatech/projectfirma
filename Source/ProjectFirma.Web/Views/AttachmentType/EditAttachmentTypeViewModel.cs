/*-----------------------------------------------------------------------
<copyright file="EditAttachmentTypeViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
        }

        public void UpdateModel(ProjectFirmaModels.Models.AttachmentType attachmentType, 
                                ICollection<AttachmentTypeFileResourceMimeType> allAttachmentTypeFileResourceMimeTypes,
                                ICollection<AttachmentTypeTaxonomyTrunk> allAttachmentTypeTaxonomyTrunks)
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

        }
    }
}
