//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectUpdateConfiguration
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectUpdateConfigurationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectUpdateConfiguration>
    {
        public ProjectUpdateConfigurationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectUpdateConfigurationPrimaryKey(ProjectUpdateConfiguration projectUpdateConfiguration) : base(projectUpdateConfiguration){}

        public static implicit operator ProjectUpdateConfigurationPrimaryKey(int primaryKeyValue)
        {
            return new ProjectUpdateConfigurationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectUpdateConfigurationPrimaryKey(ProjectUpdateConfiguration projectUpdateConfiguration)
        {
            return new ProjectUpdateConfigurationPrimaryKey(projectUpdateConfiguration);
        }
    }
}