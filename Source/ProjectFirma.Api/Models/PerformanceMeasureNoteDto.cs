using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Models
{
    public class PerformanceMeasureNoteDto
    {
        public PerformanceMeasureNoteDto()
        {
        }

        public PerformanceMeasureNoteDto(PerformanceMeasureNote performanceMeasureNote)
        {
            PerformanceMeasureNoteID = performanceMeasureNote.PerformanceMeasureNoteID;
            PerformanceMeasureID = performanceMeasureNote.PerformanceMeasureID;
            Note = performanceMeasureNote.Note;
            CreatePersonEmail = performanceMeasureNote.CreatePerson?.Email;
            UpdatePersonEmail = performanceMeasureNote.UpdatePerson?.Email;
            CreateDate = performanceMeasureNote.CreateDate;
            UpdateDate = performanceMeasureNote.UpdateDate;
        }

        public int PerformanceMeasureNoteID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public string Note { get; set; }
        public string CreatePersonEmail { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatePersonEmail { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}