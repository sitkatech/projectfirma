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
using ProjectFirma.Web.Security;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class TechnicalAssistanceRequestsViewModel : FormViewModel, IValidatableObject
    {
        public List<TechnicalAssistanceRequestSimple> TechnicalAssistanceRequestSimples { get; set; }
        // For ProjectUpdate process only
        public string TechnicalAssistanceRequestsComment { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public TechnicalAssistanceRequestsViewModel()
        {
        }

        // Constructor for ProjectUpdate process
        public TechnicalAssistanceRequestsViewModel(List<TechnicalAssistanceRequestSimple> technicalAssistanceRequestSimples, string technicalAssistanceRequestsComment)
        {
            // Preconditions
            Check.EnsureNotNull(technicalAssistanceRequestSimples);
            TechnicalAssistanceRequestSimples = technicalAssistanceRequestSimples;
            TechnicalAssistanceRequestsComment = technicalAssistanceRequestsComment;
        }

        public void UpdateModel(FirmaSession currentFirmaSession, List<TechnicalAssistanceRequestUpdate> currentTechnicalAssistanceRequests, IList<TechnicalAssistanceRequestUpdate> allTechnicalAssistanceRequests, ProjectUpdateBatch projectUpdateBatch)
        {
            var userCanAllocate = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(currentFirmaSession, projectUpdateBatch.Project).HasPermission;
            var updatedTechnicalAssistanceRequests = TechnicalAssistanceRequestSimples != null ? 
                TechnicalAssistanceRequestSimples.Select(x => new TechnicalAssistanceRequestUpdate(x.TechnicalAssistanceRequestID, projectUpdateBatch.ProjectUpdateBatchID, x.FiscalYear, x.PersonID, x.TechnicalAssistanceTypeID.Value, x.HoursRequested, x.HoursAllocated, x.HoursProvided, x.Notes)).ToList() :
                new List<TechnicalAssistanceRequestUpdate>();
            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            currentTechnicalAssistanceRequests.Merge(updatedTechnicalAssistanceRequests, allTechnicalAssistanceRequests, 
                (x, y) => x.TechnicalAssistanceRequestUpdateID == y.TechnicalAssistanceRequestUpdateID,
                (x, y) =>
                {
                    x.ProjectUpdateBatchID = y.ProjectUpdateBatchID;
                    x.FiscalYear = y.FiscalYear;
                    x.PersonID = y.PersonID;
                    x.TechnicalAssistanceTypeID = y.TechnicalAssistanceTypeID;
                    x.HoursRequested = y.HoursRequested;
                    x.HoursAllocated = userCanAllocate ? y.HoursAllocated : x.HoursAllocated;
                    x.HoursProvided = userCanAllocate ? y.HoursProvided : x.HoursProvided;
                    x.Notes = y.Notes;
                }, databaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (TechnicalAssistanceRequestSimples != null)
            {
                var reportedYears = TechnicalAssistanceRequestSimples.Select(x => x.FiscalYear).Distinct().OrderByDescending(x => x).ToList();
                var reportedYearsMissingData = reportedYears?.Select(x => x).Where(x => TechnicalAssistanceRequestSimples.Any(y => y.FiscalYear == x && y.TechnicalAssistanceTypeID == null)).ToList();
                reportedYearsMissingData?.ForEach(x => errors.Add(new ValidationResult($"{x} has rows missing a value for Assistance Type.")));
            }
            return errors;
        }
    }
}
