namespace ProjectFirma.Web.Views.Indicator
{
    public class EditAccomplishmentsMetadataViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly bool ReportedInEIP;

        public EditAccomplishmentsMetadataViewData(bool reportedInEIP)
        {
            ReportedInEIP = reportedInEIP;
        }
    }
}