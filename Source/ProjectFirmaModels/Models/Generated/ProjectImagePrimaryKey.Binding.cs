//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectImage
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectImage>
    {
        public ProjectImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectImagePrimaryKey(ProjectImage projectImage) : base(projectImage){}

        public static implicit operator ProjectImagePrimaryKey(int primaryKeyValue)
        {
            return new ProjectImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectImagePrimaryKey(ProjectImage projectImage)
        {
            return new ProjectImagePrimaryKey(projectImage);
        }
    }
}