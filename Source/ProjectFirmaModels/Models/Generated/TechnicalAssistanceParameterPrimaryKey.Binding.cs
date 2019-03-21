//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TechnicalAssistanceParameter
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TechnicalAssistanceParameterPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TechnicalAssistanceParameter>
    {
        public TechnicalAssistanceParameterPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TechnicalAssistanceParameterPrimaryKey(TechnicalAssistanceParameter technicalAssistanceParameter) : base(technicalAssistanceParameter){}

        public static implicit operator TechnicalAssistanceParameterPrimaryKey(int primaryKeyValue)
        {
            return new TechnicalAssistanceParameterPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TechnicalAssistanceParameterPrimaryKey(TechnicalAssistanceParameter technicalAssistanceParameter)
        {
            return new TechnicalAssistanceParameterPrimaryKey(technicalAssistanceParameter);
        }
    }
}