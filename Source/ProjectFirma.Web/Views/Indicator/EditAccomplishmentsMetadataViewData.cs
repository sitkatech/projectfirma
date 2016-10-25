namespace ProjectFirma.Web.Views.Indicator
{
    public class EditAccomplishmentsMetadataViewData : FirmaUserControlViewData
    {
        public readonly bool ReportedInEIP;

        public EditAccomplishmentsMetadataViewData(bool reportedInEIP)
        {
            ReportedInEIP = reportedInEIP;
        }
    }
}