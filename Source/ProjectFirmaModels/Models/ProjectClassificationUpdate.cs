namespace ProjectFirmaModels.Models
{
    public partial class ProjectClassificationUpdate : IEntityClassification, IAuditableEntity, IProjectClassification
    {
        public string GetAuditDescriptionString()
        {
            return $"ProjectUpdateBatch: {ProjectUpdateBatchID}, Classification: {ClassificationID}";
        }

        public string ClassificationNote
        {
            get { return ProjectClassificationUpdateNotes; }
        }
    }
}