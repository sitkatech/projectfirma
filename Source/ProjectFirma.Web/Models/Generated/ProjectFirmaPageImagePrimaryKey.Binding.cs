//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFirmaPageImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectFirmaPageImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFirmaPageImage>
    {
        public ProjectFirmaPageImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFirmaPageImagePrimaryKey(ProjectFirmaPageImage projectFirmaPageImage) : base(projectFirmaPageImage){}

        public static implicit operator ProjectFirmaPageImagePrimaryKey(int primaryKeyValue)
        {
            return new ProjectFirmaPageImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFirmaPageImagePrimaryKey(ProjectFirmaPageImage projectFirmaPageImage)
        {
            return new ProjectFirmaPageImagePrimaryKey(projectFirmaPageImage);
        }
    }
}