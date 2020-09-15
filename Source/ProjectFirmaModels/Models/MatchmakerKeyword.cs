using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class MatchmakerKeyword : IAuditableEntity
    {
        public string GetDisplayName()
        {
            return MatchmakerKeywordName;
        }

        public string GetAuditDescriptionString()
        {
            return $"MatchmakerKeywordID:{MatchmakerKeywordID} MatchmakerKeywordName: {MatchmakerKeywordName}";
        }
    }


    


}