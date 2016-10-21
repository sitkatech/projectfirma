using TrpaArcGisServerSoap;

namespace ArcGisServerSoap
{
    /// <summary>
    /// Simple object to encapsulate TRPA object form the Parcel layer
    /// </summary>
    public class ArcParcel
    {
        public readonly string Apn;
        public readonly Geometry ParcelFeature;

        public ArcParcel(string apn, Geometry parcelFeature)
        {
            Apn = apn;
            ParcelFeature = parcelFeature;
        }
    }
}