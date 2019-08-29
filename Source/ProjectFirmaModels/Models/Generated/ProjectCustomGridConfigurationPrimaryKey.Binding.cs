//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomGridConfiguration
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomGridConfigurationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomGridConfiguration>
    {
        public ProjectCustomGridConfigurationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomGridConfigurationPrimaryKey(ProjectCustomGridConfiguration projectCustomGridConfiguration) : base(projectCustomGridConfiguration){}

        public static implicit operator ProjectCustomGridConfigurationPrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomGridConfigurationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomGridConfigurationPrimaryKey(ProjectCustomGridConfiguration projectCustomGridConfiguration)
        {
            return new ProjectCustomGridConfigurationPrimaryKey(projectCustomGridConfiguration);
        }
    }
}