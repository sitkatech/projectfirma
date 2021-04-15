//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaRawData
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaRawDataPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaRawData>
    {
        public GeospatialAreaRawDataPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaRawDataPrimaryKey(GeospatialAreaRawData geospatialAreaRawData) : base(geospatialAreaRawData){}

        public static implicit operator GeospatialAreaRawDataPrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaRawDataPrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaRawDataPrimaryKey(GeospatialAreaRawData geospatialAreaRawData)
        {
            return new GeospatialAreaRawDataPrimaryKey(geospatialAreaRawData);
        }
    }
}