//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectImageTiming
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectImageTimingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectImageTiming>
    {
        public ProjectImageTimingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectImageTimingPrimaryKey(ProjectImageTiming projectImageTiming) : base(projectImageTiming){}

        public static implicit operator ProjectImageTimingPrimaryKey(int primaryKeyValue)
        {
            return new ProjectImageTimingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectImageTimingPrimaryKey(ProjectImageTiming projectImageTiming)
        {
            return new ProjectImageTimingPrimaryKey(projectImageTiming);
        }
    }
}