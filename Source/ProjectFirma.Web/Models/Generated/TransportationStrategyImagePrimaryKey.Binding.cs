//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationStrategyImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TransportationStrategyImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationStrategyImage>
    {
        public TransportationStrategyImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationStrategyImagePrimaryKey(TransportationStrategyImage transportationStrategyImage) : base(transportationStrategyImage){}

        public static implicit operator TransportationStrategyImagePrimaryKey(int primaryKeyValue)
        {
            return new TransportationStrategyImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationStrategyImagePrimaryKey(TransportationStrategyImage transportationStrategyImage)
        {
            return new TransportationStrategyImagePrimaryKey(transportationStrategyImage);
        }
    }
}