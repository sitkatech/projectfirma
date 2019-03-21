//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectUpdateSetting
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateSettingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectUpdateSetting>
    {
        public ProjectUpdateSettingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectUpdateSettingPrimaryKey(ProjectUpdateSetting projectUpdateSetting) : base(projectUpdateSetting){}

        public static implicit operator ProjectUpdateSettingPrimaryKey(int primaryKeyValue)
        {
            return new ProjectUpdateSettingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectUpdateSettingPrimaryKey(ProjectUpdateSetting projectUpdateSetting)
        {
            return new ProjectUpdateSettingPrimaryKey(projectUpdateSetting);
        }
    }
}