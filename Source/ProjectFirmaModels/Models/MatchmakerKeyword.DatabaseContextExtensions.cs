using System.Linq;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static MatchmakerKeyword GetMatchmakerKeyword(this IQueryable<MatchmakerKeyword> matchmakerKeywords,
                                                             string matchmakerKeywordName)
        {
            return matchmakerKeywords.SingleOrDefault(x => x.MatchmakerKeywordName == matchmakerKeywordName);
        }
    }
}
