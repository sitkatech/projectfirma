//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Tag]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Tag GetTag(this IQueryable<Tag> tags, int tagID)
        {
            var tag = tags.SingleOrDefault(x => x.TagID == tagID);
            Check.RequireNotNullThrowNotFound(tag, "Tag", tagID);
            return tag;
        }

        public static void DeleteTag(this List<int> tagIDList)
        {
            if(tagIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTags.RemoveRange(HttpRequestStorage.DatabaseEntities.Tags.Where(x => tagIDList.Contains(x.TagID)));
            }
        }

        public static void DeleteTag(this ICollection<Tag> tagsToDelete)
        {
            if(tagsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTags.RemoveRange(tagsToDelete);
            }
        }

        public static void DeleteTag(this int tagID)
        {
            DeleteTag(new List<int> { tagID });
        }

        public static void DeleteTag(this Tag tagToDelete)
        {
            DeleteTag(new List<Tag> { tagToDelete });
        }
    }
}