using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplateProjectImageModel : ReportTemplateBaseModel
    {
        public string ImageTiming { get; set; }
        public string ImageCaption { get; set; }
        public string ImageCredit { get; set; }
        public string Image { get; set; }
        public bool IsKeyPhoto { get; set; }

        public ReportTemplateProjectImageModel(ProjectImage projectImage)
        {
            ImageTiming = projectImage.ProjectImageTiming.ProjectImageTimingDisplayName;
            ImageCaption = projectImage.Caption;
            ImageCredit = projectImage.Credit;
            Image = projectImage.FileResource.GetFullGuidBasedFilename();
            IsKeyPhoto = projectImage.IsKeyPhoto;
        }

    }
}