using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class GeospatialAreaTypeSimple
    {

        public int GeospatialAreaTypeID { get; }
        public string GeospatialAreaTypeName { get; }
        public string GeospatialAreaTypeNamePluralized { get; }
        public string GeospatialAreaTypeLayerName { get; }
        public string GeospatialAreaTypeMapServiceUrl { get; }
        public List<int> GeospatialAreaIDsContainingProjectSimpleLocation { get; }
        public List<int> GeospatialAreaIDsInitiallySelected { get; }

        public GeospatialAreaTypeSimple(GeospatialAreaType geospatialAreaType)
        {
            GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            GeospatialAreaTypeName = geospatialAreaType.GeospatialAreaTypeName;
            GeospatialAreaTypeNamePluralized = geospatialAreaType.GeospatialAreaTypeNamePluralized;
            GeospatialAreaTypeLayerName = geospatialAreaType.GeospatialAreaLayerName;
            GeospatialAreaTypeMapServiceUrl = geospatialAreaType.MapServiceUrl();
        }

        public GeospatialAreaTypeSimple(GeospatialAreaType geospatialAreaType, List<int> geospatialAreaIDsContainingProjectSimpleLocation, List<int> geospatialAreaIDsInitiallySelected) : this(geospatialAreaType)
        {
            GeospatialAreaIDsContainingProjectSimpleLocation = geospatialAreaIDsContainingProjectSimpleLocation;
            GeospatialAreaIDsInitiallySelected = geospatialAreaIDsInitiallySelected;
        }
    }
}