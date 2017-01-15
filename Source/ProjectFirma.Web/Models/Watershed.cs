using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class Watershed : IAuditableEntity
    {
        public string DisplayName
        {
            get { return WatershedName; }
        }

        public List<Project> AssociatedProjects
        {
            get { return ProjectWatersheds.Select(ptc => ptc.Project).Distinct(new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList(); }
        }

        public static bool IsWatershedNameUnique(IEnumerable<Watershed> watersheds, string watershedName, int currentWatershedID)
        {
            var watershed = watersheds.SingleOrDefault(x => x.WatershedID != currentWatershedID && String.Equals(x.WatershedName, watershedName, StringComparison.InvariantCultureIgnoreCase));
            return watershed == null;
        }

        public string AuditDescriptionString
        {
            get { return WatershedName; }
        }

        public static GeoJSON.Net.Feature.FeatureCollection ToGeoJsonFeatureCollection(List<Watershed> watersheds)
        {
            var featureCollection = new GeoJSON.Net.Feature.FeatureCollection();
            featureCollection.Features.AddRange(watersheds.Select(MakeFeatureWithRelevantProperties).ToList());
            return featureCollection;
        }

        private static GeoJSON.Net.Feature.Feature MakeFeatureWithRelevantProperties(Watershed watershed)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(watershed.WatershedFeature);
            feature.Properties.Add("Watershed", watershed.GetDisplayNameAsUrl().ToString());
            return feature;
        }
    }
}