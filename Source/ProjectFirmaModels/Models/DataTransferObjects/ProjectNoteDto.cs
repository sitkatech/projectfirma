using System;

namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class ProjectNoteSimpleDto
    {
        public int ProjectNoteID { get; set; }
        public int ProjectID { get; set; }
        public string Note { get; set; }
        public int? CreatePersonID { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdatePersonID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatePersonFullName { get; set; }
        public string UpdatePersonFullName { get; set; }
        public Guid? CreatePersonGuid{ get; set; }
        public Guid? UpdatePersonGuid { get; set; }
    }

}