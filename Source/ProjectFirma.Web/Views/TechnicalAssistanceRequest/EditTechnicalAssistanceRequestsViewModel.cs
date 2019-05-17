/*-----------------------------------------------------------------------
<copyright file="EditEditTechnicalAssistanceRequestsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.TechnicalAssistanceRequest
{
    public class EditTechnicalAssistanceRequestsViewModel : FormViewModel, IValidatableObject
    {
        public List<TechnicalAssistanceRequestSimple> TechnicalAssistanceRequestSimples { get; set; }
        // For ProjectUpdate process only
        public string TechnicalAssistanceRequestsComment { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditTechnicalAssistanceRequestsViewModel()
        {
        }

        public  EditTechnicalAssistanceRequestsViewModel(ProjectFirmaModels.Models.Project project)
        {
            // Preconditions
            Check.EnsureNotNull(project);

            var technicalAssistanceRequestSimples = new List<TechnicalAssistanceRequestSimple>();
            if (project.TechnicalAssistanceRequests != null)
            {
                technicalAssistanceRequestSimples.AddRange(project.TechnicalAssistanceRequests.Select(x => new TechnicalAssistanceRequestSimple(x)).ToList());
            }
            TechnicalAssistanceRequestSimples = technicalAssistanceRequestSimples;
        }

        public void UpdateModel(List<ProjectFirmaModels.Models.TechnicalAssistanceRequest> currentTechnicalAssistanceRequests, IList<ProjectFirmaModels.Models.TechnicalAssistanceRequest> allTechnicalAssistanceRequests, ProjectFirmaModels.Models.Project project)
        {
            if (TechnicalAssistanceRequestSimples != null)
            {
                var updatedTechnicalAssistanceRequests = TechnicalAssistanceRequestSimples.Select(x => new ProjectFirmaModels.Models.TechnicalAssistanceRequest(x.TechnicalAssistanceRequestID, x.ProjectID, x.FiscalYear, x.PersonID, x.TechnicalAssistanceTypeID.Value, x.HoursRequested, x.HoursAllocated, x.HoursProvided, x.Notes)).ToList();
                var databaseEntities = HttpRequestStorage.DatabaseEntities;
                currentTechnicalAssistanceRequests.Merge(updatedTechnicalAssistanceRequests, allTechnicalAssistanceRequests, 
                    (x, y) => x.TechnicalAssistanceRequestID == y.TechnicalAssistanceRequestID,
                    (x, y) =>
                    {
                        x.ProjectID = y.ProjectID;
                        x.FiscalYear = y.FiscalYear;
                        x.PersonID = y.PersonID;
                        x.TechnicalAssistanceTypeID = y.TechnicalAssistanceTypeID;
                        x.HoursRequested = y.HoursRequested;
                        x.HoursAllocated = y.HoursAllocated;
                        x.HoursProvided = y.HoursProvided;
                        x.Notes = y.Notes;
                    }, databaseEntities);
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var reportedYears = TechnicalAssistanceRequestSimples.Select(x => x.FiscalYear).Distinct().OrderByDescending(x => x).ToList();
            var reportedYearsMissingData = reportedYears?.Select(x => x).Where(x => TechnicalAssistanceRequestSimples.Any(y => y.FiscalYear == x && y.TechnicalAssistanceTypeID == null)).ToList();
            reportedYearsMissingData?.ForEach(x => errors.Add(new ValidationResult($"{x} has rows missing a value for Assistance Type.")));
            return errors;
        }
    }
}
