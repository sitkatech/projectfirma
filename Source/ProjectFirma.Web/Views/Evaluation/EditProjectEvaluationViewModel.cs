/*-----------------------------------------------------------------------
<copyright file="EditProjectEvaluationViewModel.cs" company="Tahoe Regional Planning Agency">
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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EditProjectEvaluationViewModel : FormViewModel
    {
        [Required]
        public int ProjectEvaluationID { get; set; }

        public string Comments { get; set; }
        public List<int> SelectedEvaluationCriterionValues { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectEvaluationViewModel()
        {
            SelectedEvaluationCriterionValues = new List<int>();
        }

        public EditProjectEvaluationViewModel(ProjectEvaluation projectEvaluation)
        {
            ProjectEvaluationID = projectEvaluation.ProjectEvaluationID;
            Comments = projectEvaluation.Comments;
            SelectedEvaluationCriterionValues = projectEvaluation.ProjectEvaluationSelectedValues.Any()
                                                ? projectEvaluation.ProjectEvaluationSelectedValues.Select(x => x.EvaluationCriterionValueID).ToList()
                                                : new List<int>();
        }

        public void UpdateModel(FirmaSession currentFirmaSession, ProjectEvaluation projectEvaluation)
        {
            projectEvaluation.Comments = Comments;

            
            //gather all eval criterion values selected to make sure they are valid
            var selectedEvaluationCriterionValues = new List<EvaluationCriterionValue>();
            foreach (var simpleValue in SelectedEvaluationCriterionValues)
            {
                var evaluationCriterionValue = HttpRequestStorage.DatabaseEntities.EvaluationCriterionValues.SingleOrDefault(x => x.EvaluationCriterionValueID == simpleValue);
                if (evaluationCriterionValue != null)
                {
                    selectedEvaluationCriterionValues.Add(evaluationCriterionValue);
                }
            }



            var updatedSelectedProjectEvaluationValues = new List<ProjectEvaluationSelectedValue>();
            foreach (var selectedEvaluationCriterionValue in selectedEvaluationCriterionValues)
            {
                var projectEvaluationSelectedValue = HttpRequestStorage.DatabaseEntities.ProjectEvaluationSelectedValues.SingleOrDefault(x => x.EvaluationCriterionValueID == selectedEvaluationCriterionValue.EvaluationCriterionID && x.ProjectEvaluationID == ProjectEvaluationID);
                if (projectEvaluationSelectedValue == null)
                {
                    projectEvaluationSelectedValue = new ProjectEvaluationSelectedValue(ProjectEvaluationID, selectedEvaluationCriterionValue.EvaluationCriterionValueID);
                }

                updatedSelectedProjectEvaluationValues.Add(projectEvaluationSelectedValue);
            }


            


            var allProjectEvaluationSelectedValuesFromDatabase = HttpRequestStorage.DatabaseEntities.AllProjectEvaluationSelectedValues.Local;


            projectEvaluation.ProjectEvaluationSelectedValues.Merge(
                updatedSelectedProjectEvaluationValues,
                allProjectEvaluationSelectedValuesFromDatabase,
                (x, y) => x.ProjectEvaluationSelectedValueID == y.ProjectEvaluationSelectedValueID,
                (x, y) =>
                {
                    x.ProjectEvaluationID = y.ProjectEvaluationID;
                    x.EvaluationCriterionValueID = x.EvaluationCriterionValueID;
                }, HttpRequestStorage.DatabaseEntities);
        }
        
    }
}
