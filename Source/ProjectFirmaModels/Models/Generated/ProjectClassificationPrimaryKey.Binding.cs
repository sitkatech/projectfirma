//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectClassification
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectClassificationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectClassification>
    {
        public ProjectClassificationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectClassificationPrimaryKey(ProjectClassification projectClassification) : base(projectClassification){}

        public static implicit operator ProjectClassificationPrimaryKey(int primaryKeyValue)
        {
            return new ProjectClassificationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectClassificationPrimaryKey(ProjectClassification projectClassification)
        {
            return new ProjectClassificationPrimaryKey(projectClassification);
        }
    }
}