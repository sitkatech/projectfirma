/*-----------------------------------------------------------------------
<copyright file="NewViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.CostParameterSet
{
    public class NewViewModel : FormViewModel
    {
        [Required]
        public int CostParameterSetID { get; set; }

        [StringLength(Models.CostParameterSet.FieldLengths.Comment)]
        [DisplayName("Comment")]
        public string Comment { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.GlobalInflationRate)]
        public Percentage InflationRate { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.CurrentYearForPVCalculations)]
        public int CurrentYearForPVCalculations { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewViewModel()
        {
        }

        public NewViewModel(Models.CostParameterSet costParameterSet)
        {
            CostParameterSetID = costParameterSet.CostParameterSetID;
            InflationRate = costParameterSet.InflationRate;
            CurrentYearForPVCalculations = costParameterSet.CurrentYearForPVCalculations;
            Comment = costParameterSet.Comment;
        }
        
        public void UpdateModel(Models.CostParameterSet costParameterSet, Person currentPerson)
        {
            costParameterSet.InflationRate = InflationRate;
            costParameterSet.CurrentYearForPVCalculations = CurrentYearForPVCalculations;
            costParameterSet.Comment = Comment;
        }
    }
}
