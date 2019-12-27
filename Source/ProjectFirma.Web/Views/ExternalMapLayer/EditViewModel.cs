/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ExternalMapLayer
{
    public class EditViewModel : FormViewModel, IValidatableObject
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


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.ExternalMapLayer externalMapLayer)
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

        public void UpdateModel(ProjectFirmaModels.Models.ExternalMapLayer externalMapLayer)
        {
            externalMapLayer.DisplayName = DisplayName;
            externalMapLayer.LayerUrl = LayerUrl;
            externalMapLayer.DisplayOnAllProjectMaps = DisplayOnAllMaps;
            externalMapLayer.LayerIsOnByDefault = LayerIsOnByDefault;
            externalMapLayer.IsActive = IsActive;
            externalMapLayer.IsTiledMapService = IsTiledMapService;
            externalMapLayer.FeatureNameField = FeatureNameField;
            externalMapLayer.LayerDescription = LayerDescription;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if (HttpRequestStorage.DatabaseEntities.ExternalMapLayers.Any(x => x.DisplayName == DisplayName && x.ExternalMapLayerID != ExternalMapLayerID))
            {
                validationResults.Add(new SitkaValidationResult<EditViewModel, string>("This Display Name is already associated with an External Map Layer", x => x.DisplayName));
            }
            if (HttpRequestStorage.DatabaseEntities.ExternalMapLayers.Any(x => x.LayerUrl == LayerUrl && x.ExternalMapLayerID != ExternalMapLayerID))
            {
                validationResults.Add(new SitkaValidationResult<EditViewModel, string>("This Url is already associated with an External Map Layer", x => x.LayerUrl));
            }
            if (IsTiledMapService && !string.IsNullOrWhiteSpace(FeatureNameField))
            {
                validationResults.Add(new SitkaValidationResult<EditViewModel, string>("Feature popups are not supported for tiled map services, please do not provide a feature name field.", x => x.FeatureNameField));
            }
            return validationResults;
        }

    }
}
