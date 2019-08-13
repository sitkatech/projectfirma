//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaImage
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaImage>
    {
        public GeospatialAreaImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaImagePrimaryKey(GeospatialAreaImage geospatialAreaImage) : base(geospatialAreaImage){}

        public static implicit operator GeospatialAreaImagePrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaImagePrimaryKey(GeospatialAreaImage geospatialAreaImage)
        {
            return new GeospatialAreaImagePrimaryKey(geospatialAreaImage);
        }
    }
}