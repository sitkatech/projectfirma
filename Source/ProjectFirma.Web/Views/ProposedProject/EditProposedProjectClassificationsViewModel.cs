/*-----------------------------------------------------------------------
<copyright file="EditProposedProjectClassificationsViewModel.cs" company="Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class EditProposedProjectClassificationsViewModel : FormViewModel, IValidatableObject
    {
        public List<ProposedProjectClassificationSimple> ProposedProjectClassificationSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProposedProjectClassificationsViewModel()
        {
        }

        public EditProposedProjectClassificationsViewModel(List<ProposedProjectClassificationSimple> proposedProjectClassificationSimples)
        {
            ProposedProjectClassificationSimples = proposedProjectClassificationSimples;
        }

        public void UpdateModel(Models.ProposedProject proposedProject, List<ProposedProjectClassificationSimple> proposedProjectClassificationSimples)
        {
            foreach (var proposedProjectClassificationSimple in proposedProjectClassificationSimples)
            {
                var alreadySelected = proposedProject.ProposedProjectClassifications
                    .SingleOrDefault(x => x.ClassificationID == proposedProjectClassificationSimple.ClassificationID) != null;

                if (proposedProjectClassificationSimple.Selected && !alreadySelected)
                {
                    var proposedProjectClassification = new ProposedProjectClassification(proposedProject.ProposedProjectID,
                        proposedProjectClassificationSimple.ClassificationID)
                    {
                        ProposedProjectClassificationNotes = proposedProjectClassificationSimple.ProposedProjectClassificationNotes
                    };

                    proposedProject.ProposedProjectClassifications.Add(proposedProjectClassification);
                }
                else if (proposedProjectClassificationSimple.Selected && alreadySelected)
                {
                    var existingProposedProjectClassification = proposedProject.ProposedProjectClassifications.First(x => x.ClassificationID == proposedProjectClassificationSimple.ClassificationID);
                    existingProposedProjectClassification.ProposedProjectClassificationNotes = proposedProjectClassificationSimple.ProposedProjectClassificationNotes;
                }
                else if (!proposedProjectClassificationSimple.Selected && alreadySelected)
                {
                    var existingProposedProjectClassification = proposedProject.ProposedProjectClassifications.First(x => x.ClassificationID == proposedProjectClassificationSimple.ClassificationID);
                    existingProposedProjectClassification.DeleteProposedProjectClassification();
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var validationResults = new List<ValidationResult>();

            if (!ProposedProjectClassificationSimples.Any(x => x.Selected))
            {
                validationResults.Add(new ValidationResult(string.Format("You must select at least one {0}.", MultiTenantHelpers.GetClassificationDisplayName())));
            }

            var classifications = HttpRequestStorage.DatabaseEntities.Classifications.ToList();
            foreach (var proposedProjectClassificationSimple in ProposedProjectClassificationSimples)
            {
                if (proposedProjectClassificationSimple.Selected && string.IsNullOrWhiteSpace(proposedProjectClassificationSimple.ProposedProjectClassificationNotes))
                {
                    var classificationName = classifications.Single(x => x.ClassificationID == proposedProjectClassificationSimple.ClassificationID).DisplayName;
                    validationResults.Add(new ValidationResult(String.Format("You must include notes for {0}", classificationName)));
                }
            }
            return validationResults;
        }
    }
}
