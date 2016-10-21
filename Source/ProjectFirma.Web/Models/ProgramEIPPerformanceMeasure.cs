using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProgramEIPPerformanceMeasure : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var program = HttpRequestStorage.DatabaseEntities.Programs.Find(ProgramID);
                var eipPerformanceMeasure = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasures.Find(EIPPerformanceMeasureID);
                var projectName = program != null ? program.AuditDescriptionString : ViewUtilities.NotFoundString;
                var eipPerformanceMeasureName = eipPerformanceMeasure != null ? eipPerformanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Program: {0}, Performance Measure: {1}", projectName, eipPerformanceMeasureName);
            }
        }
    }
}