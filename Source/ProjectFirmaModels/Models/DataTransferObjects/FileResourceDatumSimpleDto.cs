namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class FileResourceDatumSimpleDto
    {
        public int FileResourceDatumID { get; set; }
        public int FileResourceInfoID { get; set; }
        public byte[] Data { get; set; }
    }

}