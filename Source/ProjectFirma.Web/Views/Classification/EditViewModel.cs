/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Classification
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int ClassificationID { get; set; }

        [Required]
        [StringLength(Models.Classification.FieldLengths.DisplayName)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(Models.Classification.FieldLengths.ClassificationDescription)]
        public string ClassificationDescription { get; set; }
        
        [StringLength(Models.Classification.FieldLengths.GoalStatement)]
        public string GoalStatement { get; set; }

        [DisplayName("Key Image")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase KeyImageFileResourceData { get; set; }

        [Required]
        public string ThemeColor { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.Classification classification)
        {
            ClassificationID = classification.ClassificationID;
            DisplayName = classification.DisplayName;
            ClassificationDescription = classification.ClassificationDescription;
            GoalStatement = classification.GoalStatement;
            ThemeColor = classification.ThemeColor;
        }

        public void UpdateModel(Models.Classification classification, Person currentPerson)
        {
            classification.DisplayName = DisplayName;
            classification.ClassificationDescription = ClassificationDescription;
            classification.GoalStatement = GoalStatement;

            if (KeyImageFileResourceData != null)
            {
                classification.KeyImageFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(KeyImageFileResourceData, currentPerson);
            }
            classification.ThemeColor = ThemeColor;

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (KeyImageFileResourceData != null && KeyImageFileResourceData.ContentLength > MaxImageSizeInBytes)
            {
                var errorMessage = String.Format("Logo is too large - must be less than {0}. Your logo was {1}.",
                    FileUtility.FormatBytes(MaxImageSizeInBytes),
                    FileUtility.FormatBytes(KeyImageFileResourceData.ContentLength));
                validationResults.Add(
                    new SitkaValidationResult<EditViewModel, HttpPostedFileBase>(errorMessage, x => x.KeyImageFileResourceData));
            }

            return validationResults;
        }

        public const int MaxImageSizeInBytes = 1024 * 500;
    }
}
