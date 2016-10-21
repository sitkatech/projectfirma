using TrpaArcGisServerSoap;

namespace ArcGisServerSoap
{
    /// <summary>
    /// "Parcels" layer http://gis.trpa.org:6080/arcgis/rest/services/AGIS_TRPA/MapServer/22
    /// </summary>
    internal class ParcelsArcLayerMapper : ArcLayerMapper<ArcParcel>
    {
        private int _geometryFieldNameIndex;
        private int _apnFieldIndex;
        public override string LayerName
        {
            get { return "Parcels"; }
        }
        public override void SetFields(Fields fields)
        {
            _apnFieldIndex = FindIndexByFieldName("APN", fields);
            _geometryFieldNameIndex = FindIndexByFieldName("SHAPE", fields);
        }
        public override ArcParcel Convert(Record r)
        {
            var apn = (string)r.Values[_apnFieldIndex];
            var geometry = (Geometry)r.Values[_geometryFieldNameIndex];
            return new ArcParcel(apn, geometry);
        }
    }
}