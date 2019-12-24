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

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EditEvaluationCriterionViewModel
    {
        public List<EvaluationCriterionSimple> EvaluationCriterionSimples { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditEvaluationCriterionViewModel()
        {
        }

        public EditEvaluationCriterionViewModel(ProjectFirmaModels.Models.Evaluation evaluation)
        {
            EvaluationCriterionSimples = evaluation.EvaluationCriterions.Select(x => new EvaluationCriterionSimple(x)).ToList();
        }

        public void UpdateModel(ProjectFirmaModels.Models.Evaluation evaluation)
        {
            var allEvaluationCriteriaFromDatabase = HttpRequestStorage.DatabaseEntities.AllEvaluationCriterions.Local;
            var allEvaluationCriteriaValuesFromDatabase = HttpRequestStorage.DatabaseEntities.AllEvaluationCriterionValues.Local;

            var evaluationCriteriaToUpdate = EvaluationCriterionSimples.Select(x =>
            {
                var evaluationCriterion = new EvaluationCriterion(evaluation, x.EvaluationCriterionName, x.EvaluationCriterionDefinition);

                evaluationCriterion.EvaluationCriterionID = x.EvaluationCriterionID;
                evaluationCriterion.EvaluationCriterionValues =
                    x.EvaluationCriterionValues.OrderBy(y => y.SortOrder).Select(
                        (y, index) =>
                            new EvaluationCriterionValue(
                                new EvaluationCriterion(evaluation, x.EvaluationCriterionName, x.EvaluationCriterionDefinition),
                                y.EvaluationCriterionValueRating,
                                y.EvaluationCriterionValueDescription)
                            {
                                EvaluationCriterionValueID = y.EvaluationCriterionValueID,
                                SortOrder = index + 1
                            }).ToList();

                return evaluationCriterion;
            }).ToList();

            var evaluationCriterionValuesToUpdate = evaluationCriteriaToUpdate.SelectMany(x => x.EvaluationCriterionValues).ToList();
            evaluation.EvaluationCriterions.SelectMany(x => x.EvaluationCriterionValues).ToList().Merge(
                evaluationCriterionValuesToUpdate,
                allEvaluationCriteriaValuesFromDatabase,
                (x, y) => x.EvaluationCriterionValueID == y.EvaluationCriterionValueID,
                (x, y) =>
                {
                    x.EvaluationCriterionValueRating = y.EvaluationCriterionValueRating;
                    x.EvaluationCriterionValueDescription = x.EvaluationCriterionValueDescription;
                    x.SortOrder = y.SortOrder;
                }, HttpRequestStorage.DatabaseEntities);

            evaluation.EvaluationCriterions.Merge(evaluationCriteriaToUpdate,
                allEvaluationCriteriaFromDatabase,
                (x, y) => x.EvaluationCriterionID == y.EvaluationCriterionID,
                (x, y) =>
                {
                    x.EvaluationCriterionName = y.EvaluationCriterionName;
                    x.EvaluationCriterionDefinition = x.EvaluationCriterionDefinition;
                }, HttpRequestStorage.DatabaseEntities);
        }
    }
}
