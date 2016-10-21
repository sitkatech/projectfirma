using TrpaArcGisServerSoap;

namespace ArcGisServerSoap
{
    /// <summary>
    /// "Town Centers" layer http://gis.trpa.org:6080/arcgis/rest/services/AGIS_TRPA/MapServer/15
    /// </summary>
    internal class TownCentersArcLayerMapper : ArcLayerMapper<ArcTownCenter>
    {
        private int _geometryFieldNameIndex;
        private int _nameFieldIndex;
        private int _descriptionFieldIndex;

        public override string LayerName
        {
            get { return "Town Centers"; }
        }
        public override void SetFields(Fields fields)
        {
            _nameFieldIndex = FindIndexByFieldName("Name_1", fields);
            _descriptionFieldIndex = FindIndexByFieldName("descript_1", fields);
            _geometryFieldNameIndex = FindIndexByFieldName("Shape", fields);
        }
        public override ArcTownCenter Convert(Record r)
        {
            var townCenterName = (string)r.Values[_nameFieldIndex];
            var townCenterDescription = (string)r.Values[_descriptionFieldIndex];
            var townCenterFeature = (Geometry)r.Values[_geometryFieldNameIndex];
            return new ArcTownCenter(townCenterName, townCenterDescription, townCenterFeature);
        }
    }
}