using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

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
        public static HtmlString GetDisplayNameAsUrl(this Tag tag)
        {
            return UrlTemplate.MakeHrefString(TagModelExtensions.GetDetailUrl(tag), tag.GetDisplayName());
        }

        public static bool IsTagNameUnique(IEnumerable<Tag> tags, string tagName, int currentTagID)
        {
            var tag = tags.SingleOrDefault(x => x.TagID != currentTagID && String.Equals(x.TagName, tagName, StringComparison.InvariantCultureIgnoreCase));
            return tag == null;
        }

        public static List<Project> GetAssociatedProjects(this Tag tag, Person currentPerson)
        {
            return tag.ProjectTags.Select(x => x.Project).ToList().GetActiveProjectsAndProposals(currentPerson.CanViewProposals());
        }
    }
}