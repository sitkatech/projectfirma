//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TechnicalAssistanceRequestUpdate
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TechnicalAssistanceRequestUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TechnicalAssistanceRequestUpdate>
    {
        public TechnicalAssistanceRequestUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TechnicalAssistanceRequestUpdatePrimaryKey(TechnicalAssistanceRequestUpdate technicalAssistanceRequestUpdate) : base(technicalAssistanceRequestUpdate){}

        public static implicit operator TechnicalAssistanceRequestUpdatePrimaryKey(int primaryKeyValue)
        {
            return new TechnicalAssistanceRequestUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TechnicalAssistanceRequestUpdatePrimaryKey(TechnicalAssistanceRequestUpdate technicalAssistanceRequestUpdate)
        {
            return new TechnicalAssistanceRequestUpdatePrimaryKey(technicalAssistanceRequestUpdate);
        }
    }
}