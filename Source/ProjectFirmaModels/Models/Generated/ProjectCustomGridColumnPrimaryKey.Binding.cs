//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomGridColumn
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomGridColumnPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomGridColumn>
    {
        public ProjectCustomGridColumnPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomGridColumnPrimaryKey(ProjectCustomGridColumn projectCustomGridColumn) : base(projectCustomGridColumn){}

        public static implicit operator ProjectCustomGridColumnPrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomGridColumnPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomGridColumnPrimaryKey(ProjectCustomGridColumn projectCustomGridColumn)
        {
            return new ProjectCustomGridColumnPrimaryKey(projectCustomGridColumn);
        }
    }
}