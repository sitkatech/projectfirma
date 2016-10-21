using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestParcel
    {
        public static Parcel Create(string parcelNumber)
        {
            return new Parcel(parcelNumber, Jurisdiction.JurisdictionIDUnknown, ParcelStatus.Active.ParcelStatusID, false);
        }
    }
}