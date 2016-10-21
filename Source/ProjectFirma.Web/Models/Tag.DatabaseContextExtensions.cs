using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Tag GetTag(this IQueryable<Tag> tags, string tagName)
        {
            return tags.SingleOrDefault(x => x.TagName == tagName);
        }
    }
}