using System;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectExternalImportDataSimple
    {
        public string ApplicationNumber { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Permit { get; set; }
        public string Species { get; set; }
        public string Goal { get; set; }
        public string LandUse { get; set; }
        // ReSharper disable once InconsistentNaming
        public string OSTAT { get; set; }
        public string Needed { get; set; }
        // ReSharper disable once InconsistentNaming
        public string DEI { get; set; }
        public string StreamName { get; set; }
        public string Tributary { get; set; }
        public string Subbasin { get; set; }
        public string ReportedSubbasin { get; set; }
        public string Township { get; set; }
        public string Range { get; set; }
        public string Section { get; set; }
        public string County { get; set; }
        public string SpeciesBenefit { get; set; }
        public string MultiYear { get; set; }
        public string HasPermit { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public int? ProjectID { get; set; }
        // ReSharper disable once InconsistentNaming
        public string OGMSProjectID { get; set; }
        public double? Cash { get; set; }
        public string Inkind { get; set; }
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }
        public short? StartYear { get; set; }
        public short? EndYear { get; set; }
        public string HasPlan { get; set; }
        public string PlanName { get; set; }
        public string PlanBy { get; set; }
        public string PlanYear { get; set; }
        public string HasOtherSelection { get; set; }
        public string OtherSelection { get; set; }
        // ReSharper disable once InconsistentNaming
        public string HUC { get; set; }
        public string ConservationEasementProtected { get; set; }

        public ImportExternalProjectStaging PopulateNewImportExternalProjectStaging()
        {
            return new ImportExternalProjectStaging(HttpRequestStorage.Person, DateTime.Now)
            {
                ProjectName = ProjectName,
                Description = Description,
                PlanningDesignStartYear = StartYear,
                ImplementationStartYear = StartYear,
                EndYear = EndYear,
                EstimatedCost = Cash
            };
        }
    }
}
