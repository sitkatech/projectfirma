namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class UpdateStatus
    {
        public readonly bool IsBasicsUpdated;
        public readonly bool IsPerformanceMeasuresUpdated;
        public readonly bool IsExpendituresUpdated;
        public readonly bool IsBudgetsUpdated;
        public readonly bool IsPhotosUpdated;
        public readonly bool IsLocationSimpleUpdated;
        public readonly bool IsLocationDetailUpdated;
        public readonly bool IsExternalLinksUpdated;
        public readonly bool IsNotesUpdated;

        public UpdateStatus(bool isBasicsUpdated,
            bool isPerformanceMeasuresUpdated,
            bool isExpendituresUpdated,
            bool isBudgetsUpdated,
            bool isPhotosUpdated,
            bool isLocationSimpleUpdated,
            bool isLocationDetailUpdated,
            bool isExternalLinksUpdated,
            bool isNotesUpdated)
        {
            IsBasicsUpdated = isBasicsUpdated;
            IsPerformanceMeasuresUpdated = isPerformanceMeasuresUpdated;
            IsExpendituresUpdated = isExpendituresUpdated;
            IsBudgetsUpdated = isBudgetsUpdated;
            IsPhotosUpdated = isPhotosUpdated;
            IsLocationSimpleUpdated = isLocationSimpleUpdated;
            IsLocationDetailUpdated = isLocationDetailUpdated;
            IsExternalLinksUpdated = isExternalLinksUpdated;
            IsNotesUpdated = isNotesUpdated;
        }
    }
}