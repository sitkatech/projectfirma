//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TechnicalAssistanceType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TechnicalAssistanceTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TechnicalAssistanceType>
    {
        public TechnicalAssistanceTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TechnicalAssistanceTypePrimaryKey(TechnicalAssistanceType technicalAssistanceType) : base(technicalAssistanceType){}

        public static implicit operator TechnicalAssistanceTypePrimaryKey(int primaryKeyValue)
        {
            return new TechnicalAssistanceTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TechnicalAssistanceTypePrimaryKey(TechnicalAssistanceType technicalAssistanceType)
        {
            return new TechnicalAssistanceTypePrimaryKey(technicalAssistanceType);
        }
    }
}