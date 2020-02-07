/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasuresValidationResult.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectCustomAttributesValidationResult
    {
        
        private readonly List<string> _warningMessages;

        public ProjectCustomAttributesValidationResult(ProjectFirmaModels.Models.ProjectUpdate projectUpdate)
        {
            _warningMessages = new List<string>();
            // Validate that required Custom Attributes are present
            var requiredCustomAttributeTypeIDs = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.Where(x => x.IsRequired && x.ProjectCustomAttributeGroup.ProjectCustomAttributeGroupProjectTypes.Any(pcagpt => pcagpt.ProjectTypeID == projectUpdate.ProjectTypeID)).Select(x => x.ProjectCustomAttributeTypeID).ToList();
            var projectrequiredCustomAttributeTypeIDs = projectUpdate.GetProjectCustomAttributes().Where(x => x.ProjectCustomAttributeType.IsRequired).Select(x => x.ProjectCustomAttributeTypeID).ToList();
            if (requiredCustomAttributeTypeIDs.Any(x => !projectrequiredCustomAttributeTypeIDs.Contains(x)))
            {
                _warningMessages.Add(FirmaValidationMessages.RequiredCustomAttribute);
            }
        }

        public ProjectCustomAttributesValidationResult(string customErrorMessage)
        {
            _warningMessages = new List<string> {customErrorMessage};
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}
