using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestParcelLandCapabilityRating
    {
        public static ParcelLandCapabilityRating Create(Parcel parcel, BaileyRating baileyRating, ParcelLandCapabilityDeterminationType parcelLandCapabilityDeterminationType, int squareFootage, DateTime determinationDate, Person lastUpdatePerson)
        {
            var parcelLandCapability = TestParcelLandCapability.Create(parcel, parcelLandCapabilityDeterminationType, determinationDate, lastUpdatePerson);
            return new ParcelLandCapabilityRating(parcelLandCapability, LandCapabilityType.BaileyRating)
            {
                BaileyRatingID = baileyRating.BaileyRatingID,
                SquareFootage = squareFootage
            };
        }

        public static ParcelLandCapabilityRating Create(Parcel parcel, short ipesScore, ParcelLandCapabilityDeterminationType parcelLandCapabilityDeterminationType, int squareFootage, DateTime determinationDate, Person lastUpdatePerson)
        {
            var parcelLandCapability = TestParcelLandCapability.Create(parcel, parcelLandCapabilityDeterminationType, determinationDate, lastUpdatePerson);
            return new ParcelLandCapabilityRating(parcelLandCapability, LandCapabilityType.IPESScore)
            {
                IPESScore = ipesScore,
                SquareFootage = squareFootage
            };
        }
    }
}