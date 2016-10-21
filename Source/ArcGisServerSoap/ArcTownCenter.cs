using TrpaArcGisServerSoap;

namespace ArcGisServerSoap
{
    /// <summary>
    /// Simple object to encapsulate TRPA object form the TownCenter layer
    /// </summary>
    public class ArcTownCenter
    {
        public readonly string Name;
        public readonly string Description;
        public readonly Geometry TownCenterFeature;

        public ArcTownCenter(string name, string description, Geometry townCenterFeature)
        {
            Name = name;
            Description = description;
            TownCenterFeature = townCenterFeature;
        }
    }
}