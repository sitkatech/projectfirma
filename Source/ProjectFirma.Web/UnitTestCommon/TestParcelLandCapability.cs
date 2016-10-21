using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestParcelLandCapability
    {
        public static ParcelLandCapability Create(Parcel parcel, ParcelLandCapabilityDeterminationType parcelLandCapabilityDeterminationType, DateTime determinationDate, Person lastUpdatePerson)
        {
            var parcelLandCapability = new ParcelLandCapability(parcel, parcelLandCapabilityDeterminationType, determinationDate, DateTime.Now, lastUpdatePerson);
            parcel.ParcelLandCapability = parcelLandCapability;
            return parcelLandCapability;
        }
    }
}