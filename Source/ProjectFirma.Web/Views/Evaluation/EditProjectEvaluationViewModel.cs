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
        public List<int> SelectedEvaluationCriteriaValues { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectEvaluationViewModel()
        {
            SelectedEvaluationCriteriaValues = new List<int>();
        }

        public EditProjectEvaluationViewModel(ProjectEvaluation projectEvaluation)
        {
            ProjectEvaluationID = projectEvaluation.ProjectEvaluationID;
            Comments = projectEvaluation.Comments;
            SelectedEvaluationCriteriaValues = projectEvaluation.ProjectEvaluationSelectedValues.Any()
                                                ? projectEvaluation.ProjectEvaluationSelectedValues.Select(x => x.EvaluationCriteriaValueID).ToList()
                                                : new List<int>();
        }

        public void UpdateModel(FirmaSession currentFirmaSession, ProjectEvaluation projectEvaluation)
        {
            projectEvaluation.Comments = Comments;

            
            //gather all eval Criteria values selected to make sure they are valid
            var selectedEvaluationCriteriaValues = new List<EvaluationCriteriaValue>();
            foreach (var simpleValue in SelectedEvaluationCriteriaValues)
            {
                var evaluationCriteriaValue = HttpRequestStorage.DatabaseEntities.EvaluationCriteriaValues.SingleOrDefault(x => x.EvaluationCriteriaValueID == simpleValue);
                if (evaluationCriteriaValue != null)
                {
                    selectedEvaluationCriteriaValues.Add(evaluationCriteriaValue);
                }
            }



            var updatedSelectedProjectEvaluationValues = new List<ProjectEvaluationSelectedValue>();
            foreach (var selectedEvaluationCriteriaValue in selectedEvaluationCriteriaValues)
            {
                var projectEvaluationSelectedValue = HttpRequestStorage.DatabaseEntities.ProjectEvaluationSelectedValues.SingleOrDefault(x => x.EvaluationCriteriaValueID == selectedEvaluationCriteriaValue.EvaluationCriteriaID && x.ProjectEvaluationID == ProjectEvaluationID);
                if (projectEvaluationSelectedValue == null)
                {
                    projectEvaluationSelectedValue = new ProjectEvaluationSelectedValue(ProjectEvaluationID, selectedEvaluationCriteriaValue.EvaluationCriteriaValueID);
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
                    x.EvaluationCriteriaValueID = x.EvaluationCriteriaValueID;
                }, HttpRequestStorage.DatabaseEntities);
        }
        
    }
}
