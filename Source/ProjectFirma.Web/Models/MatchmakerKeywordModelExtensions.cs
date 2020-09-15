using System;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class MatchmakerKeywordModelExtensions
    {
        public static readonly UrlTemplate<string> DetailUrlTemplate = new UrlTemplate<string>(SitkaRoute<TagController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1String)));
        public static string GetDetailUrl(this MatchmakerKeyword matchmakerKeyword)
        {
            throw new NotImplementedException("Need to implement this!");
            //return DetailUrlTemplate.ParameterReplace(matchmakerKeyword.MatchmakerKeywordName);
        }
    }
}