
namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public class EIPActionPrioritySimpleDto
    {
        public int EIPActionPriorityID { get; set; }
        public int EIPProgramID { get; set; }
        public byte EIPActionPriorityNumber { get; set; }
        public string EIPActionPriorityName { get; set; }
        public string EIPActionPriorityDescription { get; set; }
        public EIPProgramSimpleDto EIPProgram { get; set; }
        public string DisplayNumber { get; set; }
    }

}