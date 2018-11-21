/*-----------------------------------------------------------------------
<copyright file="LocationSimpleValidationResult.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class GeospatialAreaValidationResult
    {
        private readonly List<string> _warningMessages;

        public GeospatialAreaValidationResult(bool isIncomplete, GeospatialAreaType geospatialAreaType)
        {           
            _warningMessages = new List<string>();

            if (isIncomplete)
            {
                var geospatialAreaTypeName = geospatialAreaType.GeospatialAreaTypeName;
                _warningMessages.Add($"Select at least one {geospatialAreaTypeName}, or if {geospatialAreaTypeName} information is unavailable/irrelevant provide explanatory information in the Notes section.");
            }
        }
        public GeospatialAreaValidationResult(string customErrorMessage)
        {
            _warningMessages = new List<string> { customErrorMessage };
        }

        public List<string> GetWarningMessages()
        {     
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}
