//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationObjectiveImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TransportationObjectiveImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationObjectiveImage>
    {
        public TransportationObjectiveImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationObjectiveImagePrimaryKey(TransportationObjectiveImage transportationObjectiveImage) : base(transportationObjectiveImage){}

        public static implicit operator TransportationObjectiveImagePrimaryKey(int primaryKeyValue)
        {
            return new TransportationObjectiveImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationObjectiveImagePrimaryKey(TransportationObjectiveImage transportationObjectiveImage)
        {
            return new TransportationObjectiveImagePrimaryKey(transportationObjectiveImage);
        }
    }
}