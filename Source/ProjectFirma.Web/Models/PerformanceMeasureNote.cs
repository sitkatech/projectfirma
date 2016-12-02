using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureNote : IAuditableEntity, IEntityNote
    {
        public DateTime LastUpdated
        {
            get { return UpdateDate ?? CreateDate; }
        }

        public string LastUpdatedBy
        {
            get
            {
                if (UpdatePersonID.HasValue)
                {
                    return UpdatePerson.FullNameFirstLast;
                }
                if (CreatePersonID.HasValue)
                {
                    return CreatePerson.FullNameFirstLast;
                }
                return "System";
            }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<PerformanceMeasureNoteController>.BuildUrlFromExpression(c => c.DeletePerformanceMeasureNote(PerformanceMeasureNoteID)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<PerformanceMeasureNoteController>.BuildUrlFromExpression(c => c.Edit(PerformanceMeasureNoteID)); }
        }

        public string CreatePersonName
        {
            get { return CreatePersonID.HasValue ? CreatePerson.FullNameFirstLast : string.Empty; }
        }

        public string AuditDescriptionString
        {
            get
            {
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Find(PerformanceMeasureID);
                var pmName = performanceMeasure != null ? performanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Performance Measure: {0}", pmName);
            }
        }
    }
}