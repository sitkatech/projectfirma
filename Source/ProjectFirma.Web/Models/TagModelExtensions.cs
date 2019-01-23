using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class TagModelExtensions
    {
        public static string GetDeleteUrl(Tag tag)
        {
            return SitkaRoute<TagController>.BuildUrlFromExpression(c => c.DeleteTag(tag.TagID));
        }

        public static string GetDetailUrl(Tag tag)
        {
            return SitkaRoute<TagController>.BuildUrlFromExpression(x => x.Detail(tag.TagName));
        }

        public static bool IsTagNameUnique(IEnumerable<Tag> tags, string tagName, int currentTagID)
        {
            var tag = tags.SingleOrDefault(x => x.TagID != currentTagID && String.Equals(x.TagName, tagName, StringComparison.InvariantCultureIgnoreCase));
            return tag == null;
        }
    }
}