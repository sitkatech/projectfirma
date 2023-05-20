/*-----------------------------------------------------------------------
<copyright file="EditExternalMapLayerViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.MapLayer
{
    public class EditExternalMapLayerViewModel : FormViewModel, IValidatableObject
    {
        public int ExternalMapLayerID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ExternalMapLayer.FieldLengths.DisplayName)]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ExternalMapLayer.FieldLengths.LayerUrl)]
        [DisplayName("Url")]
        public string LayerUrl { get; set; }

        [Required]
        [DisplayName("Display on all maps?")]
        public bool DisplayOnAllMaps { get; set; }

        [Required]
        [DisplayName("Layer is on by default?")]
        public bool LayerIsOnByDefault { get; set; }

        [Required]
        [DisplayName("Is Active?")]
        public bool IsActive { get; set; }

        [Required]
        [DisplayName("Is a Tiled Map Service?")]
        public bool IsTiledMapService { get; set; }

        [StringLength(ProjectFirmaModels.Models.ExternalMapLayer.FieldLengths.FeatureNameField)]
        [DisplayName("Field to use as source for feature names")]
        public string FeatureNameField { get; set; }

        [StringLength(ProjectFirmaModels.Models.ExternalMapLayer.FieldLengths.LayerDescription)]
        [DisplayName("Internal Layer Description")]
        public string LayerDescription { get; set; }

        [DisplayName("Image File")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase FileResourceData { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditExternalMapLayerViewModel()
        {
        }

        public EditExternalMapLayerViewModel(ProjectFirmaModels.Models.ExternalMapLayer externalMapLayer)
        {
            ExternalMapLayerID = externalMapLayer.ExternalMapLayerID;
            DisplayName = externalMapLayer.DisplayName;
            LayerUrl = externalMapLayer.LayerUrl;
            DisplayOnAllMaps = externalMapLayer.DisplayOnAllProjectMaps;
            LayerIsOnByDefault = externalMapLayer.LayerIsOnByDefault;
            IsActive = externalMapLayer.IsActive;
            IsTiledMapService = externalMapLayer.IsTiledMapService;
            FeatureNameField = externalMapLayer.FeatureNameField;
            LayerDescription = externalMapLayer.LayerDescription;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ExternalMapLayer externalMapLayer, FirmaSession currentFirmaSession)
        {
            externalMapLayer.DisplayName = DisplayName;
            externalMapLayer.LayerUrl = LayerUrl;
            externalMapLayer.DisplayOnAllProjectMaps = DisplayOnAllMaps;
            externalMapLayer.LayerIsOnByDefault = LayerIsOnByDefault;
            externalMapLayer.IsActive = IsActive;
            externalMapLayer.IsTiledMapService = IsTiledMapService;
            externalMapLayer.FeatureNameField = FeatureNameField;
            externalMapLayer.LayerDescription = LayerDescription;

            externalMapLayer.MapLegendImageFileResourceInfo = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(FileResourceData, currentFirmaSession);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if (HttpRequestStorage.DatabaseEntities.ExternalMapLayers.Any(x => x.DisplayName == DisplayName && x.ExternalMapLayerID != ExternalMapLayerID))
            {
                validationResults.Add(new SitkaValidationResult<EditExternalMapLayerViewModel, string>("This Display Name is already associated with an External Map Layer", x => x.DisplayName));
            }
            if (HttpRequestStorage.DatabaseEntities.ExternalMapLayers.Any(x => x.LayerUrl == LayerUrl && x.ExternalMapLayerID != ExternalMapLayerID))
            {
                validationResults.Add(new SitkaValidationResult<EditExternalMapLayerViewModel, string>("This Url is already associated with an External Map Layer", x => x.LayerUrl));
            }
            if (IsTiledMapService && !string.IsNullOrWhiteSpace(FeatureNameField))
            {
                validationResults.Add(new SitkaValidationResult<EditExternalMapLayerViewModel, string>("Feature popups are not supported for tiled map services, please do not provide a feature name field.", x => x.FeatureNameField));
            }

            FileResourceModelExtensions.ValidateFileSize(FileResourceData, validationResults, GeneralUtility.NameOf(() => FileResourceData));

            return validationResults;
        }

    }
}
