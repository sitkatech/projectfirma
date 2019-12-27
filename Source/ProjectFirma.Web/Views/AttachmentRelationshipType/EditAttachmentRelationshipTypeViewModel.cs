/*-----------------------------------------------------------------------
<copyright file="EditAttachmentRelationshipTypeViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.Views.AttachmentRelationshipType
{
    public class EditAttachmentRelationshipTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int RelationshipTypeID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.AttachmentRelationshipType.FieldLengths.AttachmentRelationshipTypeName)]
        [DisplayName("Name")]
        public string AttachmentRelationshipTypeName { get; set; }

        [Required]
        [DisplayName("Attachment Relationship Type Description")]
        public string AttachmentRelationshipTypeDescription { get; set; }

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
        public EditAttachmentRelationshipTypeViewModel()
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
                    throw new Exception("You do not have a default Taxonomy Trunk configured. Please set one up for Attachment Relationship Types to function completely.");
                }
            }
        }

        public EditAttachmentRelationshipTypeViewModel(ProjectFirmaModels.Models.AttachmentRelationshipType attachmentRelationshipType)
        {
            RelationshipTypeID = attachmentRelationshipType.AttachmentRelationshipTypeID;
            AttachmentRelationshipTypeName = attachmentRelationshipType.AttachmentRelationshipTypeName;
            AttachmentRelationshipTypeDescription = attachmentRelationshipType.AttachmentRelationshipTypeDescription;
            NumberOfAllowedAttachments = attachmentRelationshipType.NumberOfAllowedAttachments;
            MaxFileSize = attachmentRelationshipType.MaxFileSize;
            FileResourceMimeTypeIDs = attachmentRelationshipType.AttachmentRelationshipTypeFileResourceMimeTypes.Select(x => x.FileResourceMimeTypeID).ToList();
            TaxonomyTrunkIDs = attachmentRelationshipType.AttachmentRelationshipTypeTaxonomyTrunks.Select(x => x.TaxonomyTrunkID).ToList();
        }

        public void UpdateModel(ProjectFirmaModels.Models.AttachmentRelationshipType attachmentRelationshipType, 
                                ICollection<AttachmentRelationshipTypeFileResourceMimeType> allAttachmentRelationshipTypeFileResourceMimeTypes,
                                ICollection<AttachmentRelationshipTypeTaxonomyTrunk> allAttachmentRelationshipTypeTaxonomyTrunks)
        {
            attachmentRelationshipType.AttachmentRelationshipTypeName = AttachmentRelationshipTypeName;

            attachmentRelationshipType.AttachmentRelationshipTypeDescription = AttachmentRelationshipTypeDescription;

            attachmentRelationshipType.NumberOfAllowedAttachments = NumberOfAllowedAttachments;

            attachmentRelationshipType.MaxFileSize = MaxFileSize;

            var fileResourceMimeTypesUpdated = FileResourceMimeTypeIDs.Select(x => new AttachmentRelationshipTypeFileResourceMimeType( attachmentRelationshipType.AttachmentRelationshipTypeID, x)).ToList();
            attachmentRelationshipType.AttachmentRelationshipTypeFileResourceMimeTypes.Merge(fileResourceMimeTypesUpdated,
                allAttachmentRelationshipTypeFileResourceMimeTypes,
                (x, y) => x.AttachmentRelationshipTypeID == y.AttachmentRelationshipTypeID && x.FileResourceMimeTypeID == y.FileResourceMimeTypeID, HttpRequestStorage.DatabaseEntities);

            var taxonomyTrunksUpdated = TaxonomyTrunkIDs.Select(x => new AttachmentRelationshipTypeTaxonomyTrunk(attachmentRelationshipType.AttachmentRelationshipTypeID, x)).ToList();
            attachmentRelationshipType.AttachmentRelationshipTypeTaxonomyTrunks.Merge(taxonomyTrunksUpdated,
                allAttachmentRelationshipTypeTaxonomyTrunks,
                (x, y) => x.AttachmentRelationshipTypeID == y.AttachmentRelationshipTypeID && x.TaxonomyTrunkID == y.TaxonomyTrunkID, HttpRequestStorage.DatabaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var attachmentRelationshipTypes = HttpRequestStorage.DatabaseEntities.AttachmentRelationshipTypes.ToList();
            if (!attachmentRelationshipTypes.IsAttachmentRelationshipTypeNameUnique(AttachmentRelationshipTypeName, RelationshipTypeID))
            {
                yield return new SitkaValidationResult<EditAttachmentRelationshipTypeViewModel, string>("Name already exists.",
                    x => x.AttachmentRelationshipTypeName);
            }

            if (!TaxonomyTrunkIDs.Any())
            {
                yield return new SitkaValidationResult<EditAttachmentRelationshipTypeViewModel, List<int>>($"Please select at least one {FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel()} for this {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()}",
                    x => x.TaxonomyTrunkIDs);
            }

            if (!FileResourceMimeTypeIDs.Any())
            {
                yield return new SitkaValidationResult<EditAttachmentRelationshipTypeViewModel, List<int>>($"Please select at least one file type for this {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()}",
                    x => x.FileResourceMimeTypeIDs);
            }

        }
    }
}
