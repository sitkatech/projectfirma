//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TechnicalAssistanceParamter
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TechnicalAssistanceParamterPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TechnicalAssistanceParamter>
    {
        public TechnicalAssistanceParamterPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TechnicalAssistanceParamterPrimaryKey(TechnicalAssistanceParamter technicalAssistanceParamter) : base(technicalAssistanceParamter){}

        public static implicit operator TechnicalAssistanceParamterPrimaryKey(int primaryKeyValue)
        {
            return new TechnicalAssistanceParamterPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TechnicalAssistanceParamterPrimaryKey(TechnicalAssistanceParamter technicalAssistanceParamter)
        {
            return new TechnicalAssistanceParamterPrimaryKey(technicalAssistanceParamter);
        }
    }
}