/*-----------------------------------------------------------------------
<copyright file="EditGeospatialAreaMapLayerViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Organization;

namespace ProjectFirma.Web.Views.MapLayer
{
    public class EditGeospatialAreaMapLayerViewModel : FormViewModel, IValidatableObject
    {
        public int GeospatialAreaTypeID { get; set; }

        [Required]
        [DisplayName("Display on all maps?")]
        public bool DisplayOnAllMaps { get; set; }

        [Required]
        [DisplayName("Layer is on by default on Project Map?")]
        public bool LayerIsOnByDefaultOnProjectMap { get; set; }     
        [Required]
        [DisplayName("Layer is on by default on all maps other than the Project Map?")]
        public bool LayerIsOnByDefaultOnOtherMaps { get; set; }     
        
        [DisplayName("Service Url")]
        [StringLength(GeospatialAreaType.FieldLengths.ServiceUrl)] public string ServiceUrl { get; set; }

        [DisplayName("Image File")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase FileResourceData { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditGeospatialAreaMapLayerViewModel()
        {
        }

        public EditGeospatialAreaMapLayerViewModel(GeospatialAreaType geospatialAreaType)
        {
            GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            DisplayOnAllMaps = geospatialAreaType.DisplayOnAllProjectMaps;
            LayerIsOnByDefaultOnProjectMap = geospatialAreaType.OnByDefaultOnProjectMap;
            LayerIsOnByDefaultOnOtherMaps = geospatialAreaType.OnByDefaultOnOtherMaps;
            ServiceUrl = geospatialAreaType.ServiceUrl;
        }

        public void UpdateModel(GeospatialAreaType geospatialAreaType, FirmaSession currentFirmaSession)
        {
            geospatialAreaType.DisplayOnAllProjectMaps = DisplayOnAllMaps;
            geospatialAreaType.OnByDefaultOnProjectMap = LayerIsOnByDefaultOnProjectMap;
            geospatialAreaType.OnByDefaultOnOtherMaps = LayerIsOnByDefaultOnOtherMaps;
            geospatialAreaType.ServiceUrl = ServiceUrl;

            if (FileResourceData != null)
            {
                geospatialAreaType.MapLegendImageFileResourceInfo = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(FileResourceData, currentFirmaSession);

            }

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (MultiTenantHelpers.AreGeospatialAreasExternallySourced() && string.IsNullOrWhiteSpace(ServiceUrl))
            {
                errors.Add(new SitkaValidationResult<EditGeospatialAreaMapLayerViewModel, string>(
                    "Service Url is required when externally-sourced geospatial areas is enabled",
                    x => x.ServiceUrl));
            }

            if (FileResourceData != null)
            {
                FileResourceModelExtensions.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData), FileResourceModelExtensions.MaxUploadImageSizeInBytes);

            }


            return errors;
        }

    }
}
