//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReportTemplateModelType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReportTemplateModelTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReportTemplateModelType>
    {
        public ReportTemplateModelTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReportTemplateModelTypePrimaryKey(ReportTemplateModelType reportTemplateModelType) : base(reportTemplateModelType){}

        public static implicit operator ReportTemplateModelTypePrimaryKey(int primaryKeyValue)
        {
            return new ReportTemplateModelTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReportTemplateModelTypePrimaryKey(ReportTemplateModelType reportTemplateModelType)
        {
            return new ReportTemplateModelTypePrimaryKey(reportTemplateModelType);
        }
    }
}