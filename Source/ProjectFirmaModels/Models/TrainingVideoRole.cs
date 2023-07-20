namespace ProjectFirmaModels.Models
{
    public partial class TrainingVideoRole : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Training Video ID: {TrainingVideoID}, Role ID: {RoleID}";
    }
}