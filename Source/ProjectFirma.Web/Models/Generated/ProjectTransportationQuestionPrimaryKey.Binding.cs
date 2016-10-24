//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectTransportationQuestion
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectTransportationQuestionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectTransportationQuestion>
    {
        public ProjectTransportationQuestionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectTransportationQuestionPrimaryKey(ProjectTransportationQuestion projectTransportationQuestion) : base(projectTransportationQuestion){}

        public static implicit operator ProjectTransportationQuestionPrimaryKey(int primaryKeyValue)
        {
            return new ProjectTransportationQuestionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectTransportationQuestionPrimaryKey(ProjectTransportationQuestion projectTransportationQuestion)
        {
            return new ProjectTransportationQuestionPrimaryKey(projectTransportationQuestion);
        }
    }
}