using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class Tag : IAuditableEntity
    {
        public string EditUrl
        {
            get { return SitkaRoute<TagController>.BuildUrlFromExpression(t => t.Edit(TagID)); }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<TagController>.BuildUrlFromExpression(c => c.DeleteTag(TagID)); }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string DisplayName
        {
            get { return TagName; }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<TagController>.BuildUrlFromExpression(x => x.Summary(TagName)); }
        }

        public string AuditDescriptionString
        {
            get { return TagName; }
        }

        public List<Project> AssociatedProjects
        {
            get { return ProjectTags.Select(x => x.Project).ToList(); }
        }

        public static bool IsTagNameUnique(IEnumerable<Tag> tags, string tagName, int currentTagID)
        {
            var tag = tags.SingleOrDefault(x => x.TagID != currentTagID && String.Equals(x.TagName, tagName, StringComparison.InvariantCultureIgnoreCase));
            return tag == null;
        }
    }
}