using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using TrpaArcGisServerSoap;
namespace ArcGisServerSoap
{
    public class ArcGisManager
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(ArcGisManager));

        /// <summary>
        /// Corresponds to http://gis.trpa.org:6080/arcgis/rest/services/AGIS_TRPA/MapServer so "AccelaLayers" is synonymous with "AGIS_TRPA"
        /// </summary>
        private const string MapName = "AccelaLayers";

        /// <summary>
        /// A SQL where clause that is always true works to get all records in a given layer
        /// </summary>
        private const string AllRecordsWhereClause = "1 = 1";

        /// <summary>
        /// Gets all Identifying properties for all Town Centers, meaning the distinct labels that distinguish it
        /// </summary>
        public static List<ArcTownCenter> GetAllArcTownCenters()
        {
            return FindAllMatchingInLayer(AllRecordsWhereClause, new TownCentersArcLayerMapper());
        }

        /// <summary>
        /// Attempts to find the Parcel from the Parcel layer by APN number
        /// </summary>
        public static bool TryGetArcParcelByApn(string apnNumber, out ArcParcel arcParcel)
        {
            var sqlWhereClause = string.Format("APN = '{0}'", EscapeValueForSqlStatement(apnNumber));
            var allMatching = FindAllMatchingInLayer(sqlWhereClause, new ParcelsArcLayerMapper());
            if (allMatching.Count > 0)
            {
                if (allMatching.Count > 1)
                {
                    Logger.WarnFormat("Found more than one GIS assets in TRPA ArcGIS Layer for APN {0}", apnNumber);
                }
                arcParcel = allMatching.First();
                return true;
            }
            arcParcel = null;
            return false;
        }

        private static List<T> FindAllMatchingInLayer<T>(string sqlWhereClause, ArcLayerMapper<T> typeMapper)
        {
            var mapServerPortClient = new MapServerPortClient();
            try
            {
                var mapServerInfo = mapServerPortClient.GetServerInfo(MapName);
                var mapLayerInfos = mapServerInfo.MapLayerInfos;
                var mapLayerInfo = mapLayerInfos.Single(x => x.Name == typeMapper.LayerName);

                var queryFilter = new QueryFilter { WhereClause = sqlWhereClause };
                var recordSet = mapServerPortClient.QueryFeatureData(MapName, mapLayerInfo.LayerID, queryFilter);

                typeMapper.SetFields(mapLayerInfo.Fields);
                var townCenters = recordSet.Records.Select(typeMapper.Convert).ToList();
                return townCenters;
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occurred while working with map \"{0}\" layer \"{1}\" ArcGis SOAP service at endpoint: {2}\r\nIf problems continue, investigate the REST urls by hand and see if this code needs to be adjusted to react to changes in published layers: {3}",
                                            MapName,
                                            typeMapper.LayerName,
                                            mapServerPortClient.Endpoint.Address.Uri,
                                            mapServerPortClient.Endpoint.Address.Uri.ToString().Replace("/arcgis/services", "/arcgis/rest/services"));
                throw new ApplicationException(message, ex);
            }
        }

        private static string EscapeValueForSqlStatement(string valueForSqlStatement)
        {
            return String.IsNullOrWhiteSpace(valueForSqlStatement) ? valueForSqlStatement : valueForSqlStatement.Replace("'", "''");
        }

        public static double GetDistanceInMilesBetweenTwoGeometries(Geometry geometryOne, Geometry geometryTwo)
        {
            var spatialReference = GetSpatialReference();
            var geometryService = new GeometryServerPortClient();
            try
            {
                var distance = geometryService.GetDistance(spatialReference, geometryOne, geometryTwo, GetLinearUnitForSurveyMiles());
                return distance;
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occurred while working with ArcGis SOAP service at endpoint: {0}\r\nIf problems continue, investigate the REST urls by hand and see if this code needs to be adjusted to react to changes in published layers: {1}",
                                            geometryService.Endpoint.Address.Uri,
                                            geometryService.Endpoint.Address.Uri.ToString().Replace("/arcgis/services", "/arcgis/rest/services"));
                throw new ApplicationException(message, ex);
            }
        }

        private static LinearUnit GetLinearUnitForSurveyMiles()
        {
            return ConvertUnitType(esriUnits.esriMiles);
        }

        /// <summary>
        /// Returns an ArcGIS Server LinearUnit corresponding to the passed in esriUnits enumeration
        /// </summary>
        private static LinearUnit ConvertUnitType(esriUnits unitType)
        {
            // Instantiate an ArcGI Server linear unit and specify its WKID (well-known identifier) based on the passed-in enumeration
            var linearUnit = new LinearUnit();
            switch (unitType)
            {
                case esriUnits.esriCentimeters:
                    linearUnit.WKID = 109006;
                    break;
                case esriUnits.esriDecimalDegrees:
                    linearUnit.WKID = 9102;
                    break;
                case esriUnits.esriDecimeters:
                    linearUnit.WKID = 109005;
                    break;
                case esriUnits.esriFeet:
                    linearUnit.WKID = 9003;
                    break;
                case esriUnits.esriInches:
                    linearUnit.WKID = 109008;
                    break;
                case esriUnits.esriKilometers:
                    linearUnit.WKID = 9036;
                    break;
                case esriUnits.esriMeters:
                    linearUnit.WKID = 9001;
                    break;
                case esriUnits.esriMiles:
                    linearUnit.WKID = 9035;
                    break;
                case esriUnits.esriMillimeters:
                    linearUnit.WKID = 109007;
                    break;
                case esriUnits.esriNauticalMiles:
                    linearUnit.WKID = 9030;
                    break;
                case esriUnits.esriYards:
                    linearUnit.WKID = 109002;
                    break;
                default:
                    throw new ApplicationException(string.Format("Can't calculate the unit type for {0} for value {1}", unitType.GetType().Name, unitType));
            }
            linearUnit.WKIDSpecified = true;
            return linearUnit;
        }

        private static SpatialReference GetSpatialReference()
        {
            var mapServerPortClient = new MapServerPortClient();
            try
            {
                var mapServerInfo = mapServerPortClient.GetServerInfo(MapName);
                return mapServerInfo.SpatialReference;
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occurred while working with map \"{0}\" ArcGis SOAP service at endpoint: {1}\r\nIf problems continue, investigate the REST urls by hand and see if this code needs to be adjusted to react to changes in published layers: {2}",
                                            MapName,
                                            mapServerPortClient.Endpoint.Address.Uri,
                                            mapServerPortClient.Endpoint.Address.Uri.ToString().Replace("/arcgis/services", "/arcgis/rest/services"));
                throw new ApplicationException(message, ex);
            }
        }
    }
}
