namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class UpdateStatus
    {
        public readonly bool IsBasicsUpdated;
        public readonly bool IsEIPPerformanceMeasuresUpdated;
        public readonly bool IsExpendituresUpdated;
        public readonly bool IsTransportationBudgetsUpdated;
        public readonly bool IsPhotosUpdated;
        public readonly bool IsLocationSimpleUpdated;
        public readonly bool IsLocationDetailUpdated;
        public readonly bool IsExternalLinksUpdated;
        public readonly bool IsNotesUpdated;

        public UpdateStatus(bool isBasicsUpdated,
            bool isEIPPerformanceMeasuresUpdated,
            bool isExpendituresUpdated,
            bool isTransportationBudgetsUpdated,
            bool isPhotosUpdated,
            bool isLocationSimpleUpdated,
            bool isLocationDetailUpdated,
            bool isExternalLinksUpdated,
            bool isNotesUpdated)
        {
            IsBasicsUpdated = isBasicsUpdated;
            IsEIPPerformanceMeasuresUpdated = isEIPPerformanceMeasuresUpdated;
            IsExpendituresUpdated = isExpendituresUpdated;
            IsTransportationBudgetsUpdated = isTransportationBudgetsUpdated;
            IsPhotosUpdated = isPhotosUpdated;
            IsLocationSimpleUpdated = isLocationSimpleUpdated;
            IsLocationDetailUpdated = isLocationDetailUpdated;
            IsExternalLinksUpdated = isExternalLinksUpdated;
            IsNotesUpdated = isNotesUpdated;
        }
    }
}