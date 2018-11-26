using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectGeospatialAreaTypeNote : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var geospatialAreaType = GeospatialAreaType != null ? GeospatialAreaType.GeospatialAreaTypeName : ViewUtilities.NotFoundString;
                var projectUpdate = Project != null ? Project.DisplayName : ViewUtilities.NotFoundString;
                return $"GeospatialAreaType: {geospatialAreaType}, {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}: {projectUpdate}";
            }
        }
    }
}