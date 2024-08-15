﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class TagModelExtensions
    {
        public static readonly UrlTemplate<string> DetailUrlTemplate = new UrlTemplate<string>(SitkaRoute<TagController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1String)));
        public static string GetDetailUrl(this Tag tag)
        {
            return DetailUrlTemplate.ParameterReplace(tag.TagName);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<TagController>.BuildUrlFromExpression(t => t.DeleteTag(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this Tag tag)
        {
            return DeleteUrlTemplate.ParameterReplace(tag.TagID);
        }

        public static HtmlString GetDisplayNameAsUrl(this Tag tag)
        {
            return UrlTemplate.MakeHrefString(TagModelExtensions.GetDetailUrl(tag), tag.GetDisplayName());
        }

        public static string GetDisplayNamesAsUrlListForAgGrid(this IEnumerable<Tag> tags)
        {
            List<HtmlLinkObject> tagHtmlLinkObjects = new List<HtmlLinkObject>();

            foreach (var tag in tags)
            {
                var tagItem = new HtmlLinkObject(tag.GetDisplayName(), tag.GetDetailUrl());
                tagHtmlLinkObjects.Add(tagItem);
            }

            return tagHtmlLinkObjects.ToJsonArrayForAgGrid();
        }

        public static bool IsTagNameUnique(IEnumerable<Tag> tags, string tagName, int currentTagID)
        {
            var tag = tags.SingleOrDefault(x => x.TagID != currentTagID && String.Equals(x.TagName, tagName, StringComparison.InvariantCultureIgnoreCase));
            return tag == null;
        }

        public static List<Project> GetAssociatedProjects(this Tag tag, FirmaSession currentFirmaSession)
        {
            return tag.ProjectTags.Select(x => x.Project).ToList().GetActiveProjectsAndProposals(currentFirmaSession.CanViewProposals(), currentFirmaSession);
        }
    }
}