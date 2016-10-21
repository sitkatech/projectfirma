using System;
using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IFileResourcePhoto
    {
        int? EntityImageIDAsNullable { get; }
        DateTime CreateDate { get; }
        int PrimaryKey { get; }
        FileResource FileResource { get; set; }
        string DeleteUrl { get; }
        bool IsKeyPhoto { get; }
        string CaptionOnFullView { get; }
        string CaptionOnGallery { get; }
        string Caption { get; set; }
        string PhotoUrl { get; }
        string PhotoUrlScaledThumbnail { get; }
        string EditUrl { get; }
        List<string> AdditionalCssClasses { get; }
        object OrderBy { get; set; }
    }
}