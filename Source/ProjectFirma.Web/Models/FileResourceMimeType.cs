namespace ProjectFirma.Web.Models
{
    public partial class FileResourceMimeType
    {
        public string FileResourceMimeTypeIconSmallAsImage
        {
            get { return string.Format("<img src=\"{0}\" alt=\"Download {1}\" />", FileResourceMimeTypeIconSmallFilename, FileResourceMimeTypeDisplayName); }
        }
    }
}