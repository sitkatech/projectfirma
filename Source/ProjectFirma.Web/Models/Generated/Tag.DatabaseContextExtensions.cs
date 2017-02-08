//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Tag]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public static void DeleteTag(this IQueryable<Tag> tags, List<int> tagIDList)
        {
            if(tagIDList.Any())
            {
                tags.Where(x => tagIDList.Contains(x.TagID)).Delete();
            }
        }

        public static void DeleteTag(this IQueryable<Tag> tags, ICollection<Tag> tagsToDelete)
        {
            if(tagsToDelete.Any())
            {
                var tagIDList = tagsToDelete.Select(x => x.TagID).ToList();
                tags.Where(x => tagIDList.Contains(x.TagID)).Delete();
            }
        }

        public static void DeleteTag(this IQueryable<Tag> tags, int tagID)
        {
            DeleteTag(tags, new List<int> { tagID });
        }

        public static void DeleteTag(this IQueryable<Tag> tags, Tag tagToDelete)
        {
            DeleteTag(tags, new List<Tag> { tagToDelete });
        }
    }
}