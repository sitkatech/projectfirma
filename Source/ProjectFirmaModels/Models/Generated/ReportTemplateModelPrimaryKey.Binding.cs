//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReportTemplateModel
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReportTemplateModelPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReportTemplateModel>
    {
        public ReportTemplateModelPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReportTemplateModelPrimaryKey(ReportTemplateModel reportTemplateModel) : base(reportTemplateModel){}

        public static implicit operator ReportTemplateModelPrimaryKey(int primaryKeyValue)
        {
            return new ReportTemplateModelPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReportTemplateModelPrimaryKey(ReportTemplateModel reportTemplateModel)
        {
            return new ReportTemplateModelPrimaryKey(reportTemplateModel);
        }
    }
}