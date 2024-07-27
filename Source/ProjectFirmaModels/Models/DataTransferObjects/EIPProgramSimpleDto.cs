
namespace ProjectFirmaModels.Models.DataTransferObjects
{
  

    public class EIPProgramSimpleDto
    {
        public int EIPProgramID { get; set; }
        public int EIPFocusAreaID { get; set; }
        public byte EIPProgramNumber { get; set; }
        public string EIPProgramName { get; set; }
        public string EIPProgramDescription { get; set; }
        public EIPFocusAreaSimpleDto EIPFocusArea { get; set; }
    }

}