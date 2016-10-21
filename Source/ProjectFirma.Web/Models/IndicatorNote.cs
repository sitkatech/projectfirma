using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class IndicatorNote : IAuditableEntity, IEntityNote
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
            get { return SitkaRoute<IndicatorNoteController>.BuildUrlFromExpression(c => c.DeleteIndicatorNote(IndicatorNoteID)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<IndicatorNoteController>.BuildUrlFromExpression(c => c.Edit(IndicatorNoteID)); }
        }

        public string CreatePersonName
        {
            get { return CreatePersonID.HasValue ? CreatePerson.FullNameFirstLast : string.Empty; }
        }

        public string AuditDescriptionString
        {
            get
            {
                var indicator = HttpRequestStorage.DatabaseEntities.Indicators.Find(IndicatorID);
                var pmName = indicator != null ? indicator.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Performance Measure: {0}", pmName);
            }
        }
    }
}