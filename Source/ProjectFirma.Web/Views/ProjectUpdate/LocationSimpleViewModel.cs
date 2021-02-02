/*-----------------------------------------------------------------------
<copyright file="LocationSimpleViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirmaModels.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class LocationSimpleViewModel : ProjectLocationSimpleViewModel
    {
        [DisplayName("Review Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.LocationSimpleComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public LocationSimpleViewModel()
        {
        }

        public LocationSimpleViewModel(DbGeometry projectLocationPoint, ProjectLocationSimpleTypeEnum projectLocationSimpleType, 
            string projectLocationNotes, string comments, bool locationIsPrivate)
            : base(projectLocationPoint, projectLocationSimpleType, projectLocationNotes, locationIsPrivate)
        {
            Comments = comments;
        }

        public void UpdateModelBatch(ProjectUpdateBatch projectUpdateBatch)
        {
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            projectUpdate.ProjectLocationSimpleTypeID = ProjectFirmaModels.Models.ProjectLocationSimpleType.ToType(ProjectLocationSimpleType).ProjectLocationSimpleTypeID;
            switch (ProjectLocationSimpleType)
            {
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                case ProjectLocationSimpleTypeEnum.LatLngInput:
                    projectUpdate.ProjectLocationPoint = ProjectLocationPointX.HasValue && ProjectLocationPointY.HasValue
                        ? DbSpatialHelper.MakeDbGeometryFromCoordinates(ProjectLocationPointX.Value, ProjectLocationPointY.Value, LtInfoGeometryConfiguration.DefaultCoordinateSystemId)
                        : null;
                    break;
                case ProjectLocationSimpleTypeEnum.None:
                    projectUpdate.ProjectLocationPoint = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            projectUpdate.ProjectLocationNotes = ProjectLocationNotes;
            projectUpdate.LocationIsPrivate = LocationIsPrivate;
        }
    }
}
