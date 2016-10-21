using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Tag
{
    public class TagHelper
    {
        public readonly List<BootstrapTag> Tags;
        public readonly string AddTagsUrl;
        public readonly string RemoveTagsUrl;
        public readonly string FindTagsUrl;

        public TagHelper(List<BootstrapTag> tags)
        {
            Tags = tags;
            AddTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.AddTagsToProject());
            RemoveTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.RemoveTagsFromProject());
            FindTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Find(null));
        }
    }
}