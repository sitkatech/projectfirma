/*-----------------------------------------------------------------------
<copyright file="EditEvaluationCriteriaViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
    public class EditEvaluationCriteriaViewModel
    {
        public int EvaluationCriteriaID { get; set; }
        public int EvaluationID { get; set; }
        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationCriteriaName)]
        [Required]
        [StringLength(EvaluationCriteria.FieldLengths.EvaluationCriteriaName)]
        public string EvaluationCriteriaName { get; set; }
        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationCriteriaDefinition)]
        [Required]
        [StringLength(EvaluationCriteria.FieldLengths.EvaluationCriteriaDefinition)]
        public string EvaluationCriteriaDefinition { get; set; }
        public List<EvaluationCriteriaValueSimple> EvaluationCriteriaValueSimples { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditEvaluationCriteriaViewModel()
        {
            EvaluationCriteriaValueSimples = new List<EvaluationCriteriaValueSimple>();
        }

        public EditEvaluationCriteriaViewModel(EvaluationCriteria evaluationCriteria)
        {
            EvaluationCriteriaID = evaluationCriteria.EvaluationCriteriaID;
            EvaluationID = evaluationCriteria.EvaluationID;
            EvaluationCriteriaName = evaluationCriteria.EvaluationCriteriaName;
            EvaluationCriteriaDefinition = evaluationCriteria.EvaluationCriteriaDefinition;
            EvaluationCriteriaValueSimples = evaluationCriteria.EvaluationCriteriaValues.Select(x => new EvaluationCriteriaValueSimple(x)).ToList();
        }

        public void UpdateModel(EvaluationCriteria evaluationCriteria)
        {
            evaluationCriteria.EvaluationCriteriaName = EvaluationCriteriaName;
            evaluationCriteria.EvaluationCriteriaDefinition = EvaluationCriteriaDefinition;
            var updatedEvaluationCriteriaValues = new List<EvaluationCriteriaValue>();
            foreach (var simpleValue in EvaluationCriteriaValueSimples)
            {
                var evaluationCriteriaValue = HttpRequestStorage.DatabaseEntities.EvaluationCriteriaValues.SingleOrDefault(x => x.EvaluationCriteriaValueID == simpleValue.EvaluationCriteriaValueID);
                if (evaluationCriteriaValue == null)
                {
                    evaluationCriteriaValue = new EvaluationCriteriaValue(evaluationCriteria, simpleValue.EvaluationCriteriaValueRating, simpleValue.EvaluationCriteriaValueDescription) { SortOrder = simpleValue.SortOrder };
                }
                else
                {
                    evaluationCriteriaValue.EvaluationCriteriaValueDescription = simpleValue.EvaluationCriteriaValueDescription;
                    evaluationCriteriaValue.EvaluationCriteriaValueRating = simpleValue.EvaluationCriteriaValueRating;
                    evaluationCriteriaValue.SortOrder = simpleValue.SortOrder;
                }

                updatedEvaluationCriteriaValues.Add(evaluationCriteriaValue);
            }

            var allEvaluationCriteriaValuesFromDatabase = HttpRequestStorage.DatabaseEntities.AllEvaluationCriteriaValues.Local;


            evaluationCriteria.EvaluationCriteriaValues.Merge(
                updatedEvaluationCriteriaValues,
                allEvaluationCriteriaValuesFromDatabase,
                (x, y) => x.EvaluationCriteriaValueID == y.EvaluationCriteriaValueID,
                (x, y) =>
                {
                    x.EvaluationCriteriaValueRating = y.EvaluationCriteriaValueRating;
                    x.EvaluationCriteriaValueDescription = x.EvaluationCriteriaValueDescription;
                    x.SortOrder = y.SortOrder;
                }, HttpRequestStorage.DatabaseEntities);

        }
    }
}
