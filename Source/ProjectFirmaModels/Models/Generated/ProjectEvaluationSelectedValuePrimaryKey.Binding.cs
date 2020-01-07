//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectEvaluationSelectedValue
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectEvaluationSelectedValuePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectEvaluationSelectedValue>
    {
        public ProjectEvaluationSelectedValuePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectEvaluationSelectedValuePrimaryKey(ProjectEvaluationSelectedValue projectEvaluationSelectedValue) : base(projectEvaluationSelectedValue){}

        public static implicit operator ProjectEvaluationSelectedValuePrimaryKey(int primaryKeyValue)
        {
            return new ProjectEvaluationSelectedValuePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectEvaluationSelectedValuePrimaryKey(ProjectEvaluationSelectedValue projectEvaluationSelectedValue)
        {
            return new ProjectEvaluationSelectedValuePrimaryKey(projectEvaluationSelectedValue);
        }
    }
}