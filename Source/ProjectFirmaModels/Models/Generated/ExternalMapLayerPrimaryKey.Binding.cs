//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ExternalMapLayer
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ExternalMapLayerPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ExternalMapLayer>
    {
        public ExternalMapLayerPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ExternalMapLayerPrimaryKey(ExternalMapLayer externalMapLayer) : base(externalMapLayer){}

        public static implicit operator ExternalMapLayerPrimaryKey(int primaryKeyValue)
        {
            return new ExternalMapLayerPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ExternalMapLayerPrimaryKey(ExternalMapLayer externalMapLayer)
        {
            return new ExternalMapLayerPrimaryKey(externalMapLayer);
        }
    }
}