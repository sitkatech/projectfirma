﻿using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ReportTemplateModelExtensions
    {
        public static HtmlString DownloadTemplateLink(this ProjectFirmaModels.Models.ReportTemplate reportTemplate)
        {
            var linkText = reportTemplate.FileResourceInfo.OriginalBaseFilename +
                           reportTemplate.FileResourceInfo.OriginalFileExtension;
            return UrlTemplate.MakeHrefString(reportTemplate.FileResourceInfo.GetFileResourceUrl(), linkText);
        }

        public static string FileResourceName(this ProjectFirmaModels.Models.ReportTemplate reportTemplate)
        {
            return $"{reportTemplate.FileResourceInfo.OriginalBaseFilename}{reportTemplate.FileResourceInfo.OriginalFileExtension}";
        }

    }
}