//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransportationQuestion
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TransportationQuestionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransportationQuestion>
    {
        public TransportationQuestionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransportationQuestionPrimaryKey(TransportationQuestion transportationQuestion) : base(transportationQuestion){}

        public static implicit operator TransportationQuestionPrimaryKey(int primaryKeyValue)
        {
            return new TransportationQuestionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransportationQuestionPrimaryKey(TransportationQuestion transportationQuestion)
        {
            return new TransportationQuestionPrimaryKey(transportationQuestion);
        }
    }
}