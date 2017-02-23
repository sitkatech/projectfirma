/*-----------------------------------------------------------------------
<copyright file="AssessmentSubGoal.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Linq;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class AssessmentSubGoal : IAuditableEntity
    {
        public List<AssessmentQuestion> ActiveQuestions
        {
            get { return AssessmentQuestions.Where(x => !x.IsArchived).ToList(); }
        }

        public string EditUrl
        {
            get
            {
                return SitkaRoute<AssessmentController>.BuildUrlFromExpression(c => c.EditSubGoal(AssessmentSubGoalID));
            }
        }
        public string DisplayName
        {
            get { return string.Format("Sub Goal {0}: {1}", AssessmentSubGoalNumber, AssessmentSubGoalTitle); }
        }
        public string AuditDescriptionString
        {
            get
            {
                return DisplayName;
            }
        }
    }
}
