using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
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
            CreatePersonName = performanceMeasureNote.CreatePerson?.GetFullNameFirstLast();
            UpdatePersonName = performanceMeasureNote.UpdatePerson?.GetFullNameFirstLast();
            CreateDate = performanceMeasureNote.CreateDate;
            UpdateDate = performanceMeasureNote.UpdateDate;
        }

        public int PerformanceMeasureNoteID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public string Note { get; set; }
        public string CreatePersonName { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatePersonName { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}