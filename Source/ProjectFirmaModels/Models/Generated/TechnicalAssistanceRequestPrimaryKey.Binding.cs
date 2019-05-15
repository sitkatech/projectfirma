//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TechnicalAssistanceRequest
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TechnicalAssistanceRequestPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TechnicalAssistanceRequest>
    {
        public TechnicalAssistanceRequestPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TechnicalAssistanceRequestPrimaryKey(TechnicalAssistanceRequest technicalAssistanceRequest) : base(technicalAssistanceRequest){}

        public static implicit operator TechnicalAssistanceRequestPrimaryKey(int primaryKeyValue)
        {
            return new TechnicalAssistanceRequestPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TechnicalAssistanceRequestPrimaryKey(TechnicalAssistanceRequest technicalAssistanceRequest)
        {
            return new TechnicalAssistanceRequestPrimaryKey(technicalAssistanceRequest);
        }
    }
}