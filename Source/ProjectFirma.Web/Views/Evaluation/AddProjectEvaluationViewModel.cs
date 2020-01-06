/*-----------------------------------------------------------------------
<copyright file="AddProjectEvaluationViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class AddProjectEvaluationViewModel : FormViewModel
    {
        [Required]
        public int EvaluationID { get; set; }
        public List<int> ProjectIDs { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public AddProjectEvaluationViewModel()
        {
        }

        public AddProjectEvaluationViewModel(ProjectFirmaModels.Models.Evaluation evaluation)
        {
            EvaluationID = evaluation.EvaluationID;
        }

        public void UpdateModel(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Evaluation evaluation)
        {
            if (ProjectIDs == null || !ProjectIDs.Any())
            {
                return;
            }
            foreach (var projectID in ProjectIDs)
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Single(x => x.ProjectID == projectID);
                if (project == null)
                {
                    //bad projectID from front-end
                    continue;
                }

                // get or create a new one
                var projectEvaluation = ProjectEvaluationModelExtensions.GetOrCreateProjectEvaluation(evaluation, project);
                HttpRequestStorage.DatabaseEntities.AllProjectEvaluations.Add(projectEvaluation);
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges(currentFirmaSession);
        }
        
    }
}
