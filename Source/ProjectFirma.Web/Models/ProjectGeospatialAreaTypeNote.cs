namespace ProjectFirma.Web.Models
{
    public partial class ProjectGeospatialAreaTypeNote : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"GeospatialAreaType: {GeospatialAreaTypeID}, {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}: {ProjectID}";
        }
    }
}