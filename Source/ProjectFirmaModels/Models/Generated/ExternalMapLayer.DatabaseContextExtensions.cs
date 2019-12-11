//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ExternalMapLayer]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ExternalMapLayer GetExternalMapLayer(this IQueryable<ExternalMapLayer> externalMapLayers, int externalMapLayerID)
        {
            var externalMapLayer = externalMapLayers.SingleOrDefault(x => x.ExternalMapLayerID == externalMapLayerID);
            Check.RequireNotNullThrowNotFound(externalMapLayer, "ExternalMapLayer", externalMapLayerID);
            return externalMapLayer;
        }

    }
}