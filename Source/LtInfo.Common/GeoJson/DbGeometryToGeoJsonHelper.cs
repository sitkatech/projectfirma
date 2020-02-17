/*-----------------------------------------------------------------------
<copyright file="DbGeometryToGeoJsonHelper.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using LtInfo.Common.DesignByContract;
using Newtonsoft.Json;

namespace LtInfo.Common.GeoJson
{
    public static class DbGeometryToGeoJsonHelper
    {
        public static Feature FromDbGeometry(DbGeometry inp)
        {
            switch (inp.SpatialTypeName)
            {
                case "MultiPolygon":
                    return new Feature(MultiPolygonFromDbGeometry(inp));
                case "Polygon":
                    return new Feature(PolygonFromDbGeometry(inp));
                case "Point":
                    return new Feature(PointFromDbGeometry(inp));
                case "MultiPoint":
                    return new Feature(MultiPointFromDbGeometry(inp));
                case "MultiLineString":
                    return new Feature(MultiLineStringFromDbGeometry(inp));
                case "LineString":
                    return new Feature(LineStringFromDbGeometry(inp));
                case "GeometryCollection":
                    SitkaLogger.Instance.LogDetailedErrorMessage("Error parsing geometry: " + inp.SpatialTypeName);
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        public static Point PointFromDbGeometry(DbGeometry inp)
        {
            if (inp.SpatialTypeName != "Point")
            {
                throw new ArgumentException();
            }
            var coordinates = new Position(inp.YCoordinate.Value, inp.XCoordinate.Value, null);
            var point = new Point(coordinates);
            return point;
        }


        public static LineString LineStringFromDbGeometry(DbGeometry inp)
        {
            if (inp.SpatialTypeName != "LineString")
            {
                throw new ArgumentException();
            }
            var coordinates = new List<Position>();
            for (var i = 1; i <= inp.PointCount; i++)
            {
                coordinates.Add(new Position(inp.PointAt(i).YCoordinate.Value, inp.PointAt(i).XCoordinate.Value, null));
            }
            var lineString = new LineString(coordinates);
            return lineString;
        }

        public static MultiPoint MultiPointFromDbGeometry(DbGeometry inp)
        {
            if (inp.SpatialTypeName != "MultiPoint")
            {
                throw new ArgumentException();
            }

            var points = new List<Point>();
            for (var i = 1; i <= inp.ElementCount; i++)
            {
                points.Add(PointFromDbGeometry(inp.ElementAt(i)));
            }
            var multiPoint = new MultiPoint(points);
            return multiPoint;
        }

        public static MultiLineString MultiLineStringFromDbGeometry(DbGeometry inp)
        {
            if (inp.SpatialTypeName != "MultiLineString")
            {
                throw new ArgumentException();
            }
            var lineStrings = new List<LineString>();
            for (var i = 1; i <= inp.ElementCount; i++)
            {
                lineStrings.Add(LineStringFromDbGeometry(inp.ElementAt(i)));
            }
            var multiLineString = new MultiLineString(lineStrings);
            return multiLineString;
        }

        public static Polygon PolygonFromDbGeometry(DbGeometry inp)
        {
            if (inp.SpatialTypeName != "Polygon")
            {
                throw new ArgumentException();
            }
            var linearRings = new List<LineString>();

            // first get the exterior ring
            var exteriorRing = LineStringFromDbGeometry(inp.ExteriorRing);
            Check.Require(exteriorRing.IsLinearRing(), "We expect the exterior ring to be a Linear Ring for this to be a polygon!");
            linearRings.Add(exteriorRing);

            // then get any interior rings
            for (var i = 1; i <= inp.InteriorRingCount; ++i)
            {
                linearRings.Add(LineStringFromDbGeometry(inp.InteriorRingAt(i)));
            }

            var polygon = new Polygon(linearRings);
            return polygon;
        }

        public static MultiPolygon MultiPolygonFromDbGeometry(DbGeometry inp)
        {
            if (inp.SpatialTypeName != "MultiPolygon")
            {
                throw new ArgumentException();
            }

            var polygons = new List<Polygon>();
            for (var i = 1; i <= inp.ElementCount; i++)
            {
                polygons.Add(PolygonFromDbGeometry(inp.ElementAt(i)));
            }
            var multiPolygon = new MultiPolygon(polygons);
            return multiPolygon;
        }

        public static bool CanParseGeometry(DbGeometry geometry)
        {
            return geometry != null && geometry.IsValid && geometry.SpatialTypeName != "GeometryCollection";
        }

        public static string MakeDbGeometryIntoGeoJsonString(DbGeometry geometry, Formatting formatting)
        {
            var dbGeometryAsFeature = DbGeometryToGeoJsonHelper.FromDbGeometry(geometry);
            return JsonTools.SerializeObject(dbGeometryAsFeature, formatting);
        }

    }
}
