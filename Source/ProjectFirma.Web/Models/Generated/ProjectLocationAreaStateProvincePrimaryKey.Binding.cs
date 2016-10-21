//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationAreaStateProvince
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectLocationAreaStateProvincePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationAreaStateProvince>
    {
        public ProjectLocationAreaStateProvincePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationAreaStateProvincePrimaryKey(ProjectLocationAreaStateProvince projectLocationAreaStateProvince) : base(projectLocationAreaStateProvince){}

        public static implicit operator ProjectLocationAreaStateProvincePrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationAreaStateProvincePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationAreaStateProvincePrimaryKey(ProjectLocationAreaStateProvince projectLocationAreaStateProvince)
        {
            return new ProjectLocationAreaStateProvincePrimaryKey(projectLocationAreaStateProvince);
        }
    }
}