using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasureImportanceDto
    {
        public PerformanceMeasureImportanceDto(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            Importance = performanceMeasure.Importance;
            FileResources = performanceMeasure.PerformanceMeasureImages.Select(x => new FileResourceDto(x.FileResource))
                .ToList();

        }

        public PerformanceMeasureImportanceDto()
        {
        }

        public int PerformanceMeasureID { get; set; }
        public string Importance { get; set; }
        public List<FileResourceDto> FileResources { get; set; }

    }
}