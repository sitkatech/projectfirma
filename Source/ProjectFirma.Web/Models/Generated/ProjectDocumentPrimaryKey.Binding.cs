//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectDocument
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectDocumentPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectDocument>
    {
        public ProjectDocumentPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectDocumentPrimaryKey(ProjectDocument projectDocument) : base(projectDocument){}

        public static implicit operator ProjectDocumentPrimaryKey(int primaryKeyValue)
        {
            return new ProjectDocumentPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectDocumentPrimaryKey(ProjectDocument projectDocument)
        {
            return new ProjectDocumentPrimaryKey(projectDocument);
        }
    }
}