using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Areas.ParcelTracker.Controllers;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.GeoJson;

namespace ProjectFirma.Web.Models
{
    public partial class Jurisdiction : IAuditableEntity
    {
        public const int JurisdictionIDTRPA = 6;
        public const int JurisdictionIDUnknown = 8;

        public static GeoJSON.Net.Feature.FeatureCollection ToGeoJsonFeatureCollection(List<Jurisdiction> jurisdictions)
        {
            var featureCollection = new GeoJSON.Net.Feature.FeatureCollection();
            featureCollection.Features.AddRange(jurisdictions.Select(MakeFeatureWithRelevantProperties).ToList());
            return featureCollection;
        }

        private static GeoJSON.Net.Feature.Feature MakeFeatureWithRelevantProperties(Jurisdiction jurisdiction)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(jurisdiction.JurisdictionFeature);
            feature.Properties.Add("State", jurisdiction.StateProvince.StateProvinceAbbreviation);
            feature.Properties.Add("County/City", jurisdiction.Organization.OrganizationName);
            return feature;
        }

        public string GetResidentialAllocationCommodityPoolUrl()
        {
            var commodityPool = HttpRequestStorage.DatabaseEntities.CommodityPools.ToList().SingleOrDefault(x => x.JurisdictionID == JurisdictionID && x.Commodity == Commodity.ResidentialAllocation);

            var commodityPoolID = commodityPool.CommodityPoolID;
            return SitkaRoute<DevelopmentRightPoolController>.BuildUrlFromExpression(x => x.Summary(commodityPoolID));
        }

        public string AuditDescriptionString { get { return Organization.OrganizationName; } }

        public bool IsTRPA()
        {
            return JurisdictionID == JurisdictionIDTRPA;
        }
    }
}