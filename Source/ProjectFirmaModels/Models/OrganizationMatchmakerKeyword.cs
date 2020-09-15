namespace ProjectFirmaModels.Models
{
    public partial class OrganizationMatchmakerKeyword : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"OrganizationMatchmakerKeywordID: {this.OrganizationMatchmakerKeywordID} - OrganizationID: {this.OrganizationID} - MatchmakerKeywordID: {this.MatchmakerKeywordID}";
        }
    }
}