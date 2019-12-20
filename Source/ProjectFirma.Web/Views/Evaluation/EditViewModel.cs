/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int EvaluationID { get; set; }

        [DisplayName("Name")]
        [Required]
        [StringLength(ProjectFirmaModels.Models.Evaluation.FieldLengths.EvaluationName)]
        public string EvaluationName { get; set; }

        [Required]
        [DisplayName("Definition")]
        [StringLength(ProjectFirmaModels.Models.Evaluation.FieldLengths.EvaluationDefinition)]
        public string EvaluationDefinition { get; set; }

        [DisplayName("Start Date")]
        public DateTime? EvaluationStartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EvaluationEndDate { get; set; }

        [DisplayName("Status")]
        public int EvaluationStatusID { get; set; }

        [DisplayName("Visibility")]
        public int EvaluationVisibilityID { get; set; }

        public int CreatePersonID { get; set; }
        public DateTime CreateDate { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.Evaluation evaluation)
        {
            EvaluationID = evaluation.EvaluationID;
            EvaluationName = evaluation.EvaluationName;
            EvaluationDefinition = evaluation.EvaluationDefinition;
            EvaluationStartDate = evaluation.EvaluationStartDate;
            EvaluationEndDate = evaluation.EvaluationEndDate;
            EvaluationStatusID = evaluation.EvaluationStatusID;
            EvaluationVisibilityID = evaluation.EvaluationVisibilityID;
            CreatePersonID = evaluation.CreatePersonID;
            CreateDate = evaluation.CreateDate;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Evaluation evaluation, FirmaSession currentFirmaSession)
        {
            evaluation.EvaluationName = EvaluationName;
            evaluation.EvaluationDefinition = EvaluationDefinition;
            evaluation.EvaluationStartDate = EvaluationStartDate;
            evaluation.EvaluationEndDate = EvaluationEndDate;
            evaluation.EvaluationStatusID = EvaluationStatusID;
            evaluation.EvaluationVisibilityID = EvaluationVisibilityID;
            evaluation.CreatePersonID = CreatePersonID;
            evaluation.CreateDate = CreateDate;

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();



            return validationResults;
        }

    }
}
