/*-----------------------------------------------------------------------
<copyright file="EditBoundingBoxViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Tenant
{
    public class EditBoundingBoxViewModel : FormViewModel
    {
        [Required]
        public int? TenantID { get; set; }

        [Required(ErrorMessage = "The North coordinate is required.")]
        [Range(-90, 90, ErrorMessage = "The North coordinate must be between -90 and 90 degrees")]
        public decimal? North { get; set; }

        [Required(ErrorMessage = "The South coordinate is required.")]
        [Range(-90, 90, ErrorMessage = "The South coordinate must be between -90 and 90 degrees")]
        public decimal? South { get; set; }

        [Required(ErrorMessage = "The East coordinate is required.")]
        [Range(-180, 180, ErrorMessage = "The East coordinate must be between -180 and 180 degrees")]
        public decimal? East { get; set; }

        [Required(ErrorMessage = "The West coordinate is required.")]
        [Range(-180, 180, ErrorMessage = "The West coordinate must be between -180 and 180 degrees")]
        public decimal? West { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditBoundingBoxViewModel()
        {
        }

        public EditBoundingBoxViewModel(TenantAttribute tenantAttribute)
        {
            TenantID = tenantAttribute.TenantID;

            if (tenantAttribute.DefaultBoundingBox != null)
            {
                var defaultBoundingBoxBoundary = tenantAttribute.DefaultBoundingBox.Boundary;
                var southWest = defaultBoundingBoxBoundary.PointAt(1);
                var northEast = defaultBoundingBoxBoundary.PointAt(3);

                if (northEast.YCoordinate != null)
                {
                    North = (decimal) northEast.YCoordinate;
                }
                if (southWest.YCoordinate != null)
                {
                    South = (decimal) southWest.YCoordinate;
                }
                if (northEast.XCoordinate != null)
                {
                    East = (decimal) northEast.XCoordinate;
                }
                if (southWest.XCoordinate != null)
                {
                    West = (decimal) southWest.XCoordinate;
                }
            }
        }

        public void UpdateModel()
        {
            var defaultBoundingBox = DbGeometry.FromText(String.Format("POLYGON(({0} {1}, {0} {2}, {3} {2}, {3} {1}, {0} {1}))", West, North, South, East), 4326);
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(x => x.TenantID == TenantID);
            tenantAttribute.DefaultBoundingBox = defaultBoundingBox;
        }
    }
}
