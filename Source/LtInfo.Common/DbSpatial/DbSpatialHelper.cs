/*-----------------------------------------------------------------------
<copyright file="DbSpatialHelper.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data.SqlTypes;
using System.Linq;
using LtInfo.Common.GdalOgr;
using Microsoft.SqlServer.Types;

namespace LtInfo.Common.DbSpatial
{
    public static class DbSpatialHelper
    {
        private const double MetersPerFoot = 0.3048;

        public static double FeetToAverageLatLonDegree(DbGeometry geometry, double feet)
        {            
            return 2 / ((1 / FeetToLonDegree(geometry, feet)) + (1 / FeetToLatDegree(geometry, feet))); //Harmonic mean
        }

        public static double FeetToLatDegree(DbGeometry geometry, double feet)
        {
            var longitude = geometry.Centroid == null ? geometry.XCoordinate.Value : geometry.Centroid.XCoordinate.Value;
            var latitude = geometry.Centroid == null ? geometry.YCoordinate.Value : geometry.Centroid.YCoordinate.Value;
            var coordinateSystemId = geometry.CoordinateSystemId == 0 ? Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId : geometry.CoordinateSystemId;

            var geography = MakeDbGeographyFromLatLon(longitude, latitude - 0.5, coordinateSystemId);

            var dbGeographyOneDegreeLatitude = MakeDbGeographyFromLatLon(longitude, latitude + 0.5, coordinateSystemId);
            var degreesLatitudePerMeter =
                geography.Distance(dbGeographyOneDegreeLatitude).Value;

            return (feet * MetersPerFoot) / degreesLatitudePerMeter;
        }

        public static double FeetToLonDegree(DbGeometry geometry, double feet)
        {
            var longitude = geometry.Centroid == null ? geometry.XCoordinate.Value : geometry.Centroid.XCoordinate.Value;
            var latitude = geometry.Centroid == null ? geometry.YCoordinate.Value : geometry.Centroid.YCoordinate.Value;
            var coordinateSystemId = geometry.CoordinateSystemId == 0 ? Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId : geometry.CoordinateSystemId;

            var geography = MakeDbGeographyFromLatLon(longitude - 0.5, latitude, coordinateSystemId);

            var dbGeographyOneDegreeLongitude = MakeDbGeographyFromLatLon(longitude + 0.5, latitude, coordinateSystemId);
            var degreesLongitudePerMeter =
                geography.Distance(dbGeographyOneDegreeLongitude).Value;

            return (feet*MetersPerFoot)/degreesLongitudePerMeter;
        }

        public static DbGeometry MakeDbGeometryFromCoordinates(double xCoordinate, double yCoordinate, int coordinateSystemId)
        {
            var geometry = DbGeometry.PointFromText(string.Format("POINT({0} {1})", xCoordinate, yCoordinate),
                coordinateSystemId);
            return geometry;
        }

        public static DbGeography MakeDbGeographyFromLatLon(double longitude, double latitude, int coordinateSystemId)
        {
            var geography = DbGeography.PointFromText(string.Format("POINT({0} {1})", longitude, latitude),
                coordinateSystemId);
            return geography;
        }

        public static DbGeography GeographyFromGeometry(DbGeometry ogrGeometry)
        {
            return DbGeography.FromBinary(ogrGeometry.AsBinary());
        }

        public static DbGeometry ToDbGeometry(this SqlGeometry sqlGeometry)
        {
            return DbGeometry.FromBinary(sqlGeometry.STAsBinary().Buffer);
        }

        public static SqlGeometry ToSqlGeometry(this DbGeometry dbGeometry)
        {
            return SqlGeometry.STGeomFromWKB(new SqlBytes(dbGeometry.AsBinary()), dbGeometry.CoordinateSystemId);
        }

        public static void Reduce(List<IHaveSqlGeometry> geometries)
        {
            const int thresholdInFeet = 25;
            var thresholdInDegrees = FeetToAverageLatLonDegree(geometries.First().DbGeometry, thresholdInFeet);
            geometries.ForEach(x => x.DbGeometry = x.SqlGeometry.Reduce(thresholdInDegrees).ToDbGeometry());
        }
    }
}
