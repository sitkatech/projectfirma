/*-----------------------------------------------------------------------
<copyright file="ProjectLocationDetailViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using LtInfo.Common;
using LtInfo.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationDetailViewModel : FormViewModel, IValidatableObject
    {
        public List<WktAndAnnotation> WktAndAnnotations { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (WktAndAnnotations != null && WktAndAnnotations.Any(x => x.HasCoordinatesOutOfRange()))
            {
                errors.Add(
                    new SitkaValidationResult<ProjectLocationDetailViewModel, List<WktAndAnnotation>>(
                        $"Feature coordinates are out of bounds.",
                        x => x.WktAndAnnotations));
            }

            return errors;
        }
    }

    public class WktAndAnnotation
    {
        public string Wkt { get; set; }
        public string Annotation { get; set; }

        public bool HasCoordinatesOutOfRange()
        {
            // Extract as comma-separated coord pairs from Wkt
            var coords = Regex.Replace(Wkt, "[A-Za-z()]", "");
            var coordPairs = coords.Split(new string[] {", "}, StringSplitOptions.None);
            foreach (var coordPair in coordPairs)
            {
                // Get lat/lng from coord pair
                var split = coordPair.Trim().Split(' ');
                var lngOutOfRange = decimal.Parse(split[0]) < -180 || decimal.Parse(split[0]) > 180;
                var latOutOfRange = decimal.Parse(split[1]) < -90 || decimal.Parse(split[1]) > 90;
                if (lngOutOfRange || latOutOfRange)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
