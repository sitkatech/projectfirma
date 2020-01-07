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
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EditEvaluationCriterionViewModel
    {
        public int EvaluationCriterionID { get; set; }
        public int EvaluationID { get; set; }
        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationCriterionName)]
        [Required]
        [StringLength(EvaluationCriterion.FieldLengths.EvaluationCriterionName)]
        public string EvaluationCriterionName { get; set; }
        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationCriterionDefinition)]
        [Required]
        [StringLength(EvaluationCriterion.FieldLengths.EvaluationCriterionDefinition)]
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

        public void UpdateModel(EvaluationCriterion evaluationCriterion)
        {
            evaluationCriterion.EvaluationCriterionName = EvaluationCriterionName;
            evaluationCriterion.EvaluationCriterionDefinition = EvaluationCriterionDefinition;
            var updatedEvaluationCriterionValues = new List<EvaluationCriterionValue>();
            foreach (var simpleValue in EvaluationCriterionValueSimples)
            {
                var evaluationCriterionValue = HttpRequestStorage.DatabaseEntities.EvaluationCriterionValues.SingleOrDefault(x => x.EvaluationCriterionValueID == simpleValue.EvaluationCriterionID);
                if (evaluationCriterionValue == null)
                {
                    evaluationCriterionValue = new EvaluationCriterionValue(evaluationCriterion, simpleValue.EvaluationCriterionValueRating, simpleValue.EvaluationCriterionValueDescription) { SortOrder = simpleValue.SortOrder };
                }
                else
                {
                    evaluationCriterionValue.EvaluationCriterionValueDescription = simpleValue.EvaluationCriterionValueDescription;
                    evaluationCriterionValue.EvaluationCriterionValueRating = simpleValue.EvaluationCriterionValueRating;
                    evaluationCriterionValue.SortOrder = simpleValue.SortOrder;
                }

                updatedEvaluationCriterionValues.Add(evaluationCriterionValue);
            }

            //var allEvaluationCriteriaFromDatabase = HttpRequestStorage.DatabaseEntities.AllEvaluationCriterions.Local;
            var allEvaluationCriteriaValuesFromDatabase = HttpRequestStorage.DatabaseEntities.AllEvaluationCriterionValues.Local;


            evaluationCriterion.EvaluationCriterionValues.Merge(
                updatedEvaluationCriterionValues,
                allEvaluationCriteriaValuesFromDatabase,
                (x, y) => x.EvaluationCriterionValueID == y.EvaluationCriterionValueID,
                (x, y) =>
                {
                    x.EvaluationCriterionValueRating = y.EvaluationCriterionValueRating;
                    x.EvaluationCriterionValueDescription = x.EvaluationCriterionValueDescription;
                    x.SortOrder = y.SortOrder;
                }, HttpRequestStorage.DatabaseEntities);

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
