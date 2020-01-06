/*-----------------------------------------------------------------------
<copyright file="EditEvaluationCriterionViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EditEvaluationCriterionViewModel
    {
        public int EvaluationCriterionID { get; set; }
        public int EvaluationID { get; set; }
        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationCriterionName)]
        [Required]
        public string EvaluationCriterionName { get; set; }
        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationCriterionDefinition)]
        [Required]
        public string EvaluationCriterionDefinition { get; set; }
        public List<EvaluationCriterionValueSimple> EvaluationCriterionValueSimples { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditEvaluationCriterionViewModel()
        {
            EvaluationCriterionValueSimples = new List<EvaluationCriterionValueSimple>();
        }

        public EditEvaluationCriterionViewModel(EvaluationCriterion evaluationCriterion)
        {
            EvaluationCriterionID = evaluationCriterion.EvaluationCriterionID;
            EvaluationID = evaluationCriterion.EvaluationID;
            EvaluationCriterionName = evaluationCriterion.EvaluationCriterionName;
            EvaluationCriterionDefinition = evaluationCriterion.EvaluationCriterionDefinition;
            EvaluationCriterionValueSimples = evaluationCriterion.EvaluationCriterionValues.Select(x => new EvaluationCriterionValueSimple(x)).ToList();
        }

        public void UpdateModel(EvaluationCriterion evaluation)
        {
            //var allEvaluationCriteriaFromDatabase = HttpRequestStorage.DatabaseEntities.AllEvaluationCriterions.Local;
            //var allEvaluationCriteriaValuesFromDatabase = HttpRequestStorage.DatabaseEntities.AllEvaluationCriterionValues.Local;

            //var evaluationCriterionToUpdate = HttpRequestStorage.DatabaseEntities.EvaluationCriterions.SingleOrDefault(x => x.EvaluationCriterionID == EvaluationCriterionSimple.EvaluationCriterionID);
            //if (evaluationCriterionToUpdate == null)
            //{
            //    evaluationCriterionToUpdate = new EvaluationCriterion(EvaluationCriterionSimple.EvaluationID, EvaluationCriterionSimple.EvaluationCriterionName, evaluationCriterionToUpdate.EvaluationCriterionDefinition);
            //}


            //var evaluationCriterionValuesToUpdate = evaluationCriteriaToUpdate.SelectMany(x => x.EvaluationCriterionValueSimples).ToList();





            //evaluation.EvaluationCriterions.SelectMany(x => x.EvaluationCriterionValueSimples).ToList().Merge(
            //    evaluationCriterionValuesToUpdate,
            //    allEvaluationCriteriaValuesFromDatabase,
            //    (x, y) => x.EvaluationCriterionValueID == y.EvaluationCriterionValueID,
            //    (x, y) =>
            //    {
            //        x.EvaluationCriterionValueRating = y.EvaluationCriterionValueRating;
            //        x.EvaluationCriterionValueDescription = x.EvaluationCriterionValueDescription;
            //        x.SortOrder = y.SortOrder;
            //    }, HttpRequestStorage.DatabaseEntities);

            //evaluation.EvaluationCriterions.Merge(evaluationCriteriaToUpdate,
            //    allEvaluationCriteriaFromDatabase,
            //    (x, y) => x.EvaluationCriterionID == y.EvaluationCriterionID,
            //    (x, y) =>
            //    {
            //        x.EvaluationCriterionName = y.EvaluationCriterionName;
            //        x.EvaluationCriterionDefinition = x.EvaluationCriterionDefinition;
            //    }, HttpRequestStorage.DatabaseEntities);
        }
    }
}
