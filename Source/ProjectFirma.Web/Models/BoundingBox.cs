/*-----------------------------------------------------------------------
<copyright file="BoundingBox.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.GdalOgr;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    [ModelBinder(typeof(BoundingBoxModelBinder))] // ModelBinder is for Action parameter parsing
    public class BoundingBox
    {
        // This is for the Lake Tahoe region
        private const decimal DefaultPadding = 1.0m;

        public Point Southwest { get; private set; }
        public Point Northeast { get; private set; }

        public BoundingBox(Point southwest, Point northeast)
        {
            MakeFromPoint(southwest, northeast);
        }

        public BoundingBox(Point point, decimal paddingDegrees)
        {
            var sw = new Point(point.Latitude - paddingDegrees/2, point.Longitude - paddingDegrees/2);
            var ne = new Point(point.Latitude + paddingDegrees/2, point.Longitude + paddingDegrees/2);

            MakeFromPoint(sw, ne);
        }

        /// <summary>
        /// Bounding box that is the envelope of all the given points
        /// </summary>
        /// <param name="pointList"></param>
        public BoundingBox(List<Point> pointList)
        {
            Point southwest;
            Point northeast;
            if (pointList.Count == 1)
            {
                var point = pointList.Single();
                southwest= new Point(point.Latitude - DefaultPadding / 2, point.Longitude - DefaultPadding / 2);
                northeast= new Point(point.Latitude + DefaultPadding / 2, point.Longitude + DefaultPadding / 2);
            }
            else if (pointList.Any())
            {
                southwest = new Point(pointList.Min(point => point.Latitude), pointList.Min(point => point.Longitude));
                northeast = new Point(pointList.Max(point => point.Latitude), pointList.Max(point => point.Longitude));
                
            }
            else
            {
                var geometry = MultiTenantHelpers.GetDefaultBoundingBox();
                var pointCount = geometry.Envelope.ElementAt(1).PointCount.Value;
                var envelope = geometry.Envelope.ElementAt(1);
                var pointList1 = new List<Point>();

                for (var i = 1; i <= pointCount; i++)
                {
                    var dbGeometryPoint = envelope.PointAt(i);

                    if (!dbGeometryPoint.XCoordinate.HasValue || !dbGeometryPoint.YCoordinate.HasValue)
                    {
                        continue;
                    }

                    pointList1.Add(new Point(envelope.PointAt(i).YCoordinate.Value, envelope.PointAt(i).XCoordinate.Value));
                }
                var defaultBoundingBoxPoints = pointList1;
                southwest = new Point(defaultBoundingBoxPoints.Min(point => point.Latitude), defaultBoundingBoxPoints.Min(point => point.Longitude));
                northeast = new Point(defaultBoundingBoxPoints.Max(point => point.Latitude), defaultBoundingBoxPoints.Max(point => point.Longitude));

            }
            MakeFromPoint(southwest, northeast);
        }

        public BoundingBox(List<BoundingBox> boundingBoxes)
        {
            var southwest = new Point(boundingBoxes.Min(s => s.Southwest.Latitude), boundingBoxes.Min(s => s.Southwest.Longitude));
            var northeast = new Point(boundingBoxes.Max(s => s.Northeast.Latitude), boundingBoxes.Max(s => s.Northeast.Longitude));

            MakeFromPoint(southwest, northeast);
        }

        /// <summary>
        /// This should be the opposite of <see cref="ToString()"/>
        /// </summary>
        public BoundingBox(string urlParameter)
        {
            // North~South~East~West
            var pattern = new Regex("^(?<north>[^~]+)~(?<south>[^~]+)~(?<east>[^~]+)~(?<west>[^~]+)$");
            var match = pattern.Match(urlParameter);

            Check.Require(match.Success, $"Value \"{urlParameter}\" does not parse as a {GetType().Name}.");

            var north = decimal.Parse(match.Groups["north"].Value);
            var south = decimal.Parse(match.Groups["south"].Value);
            var east = decimal.Parse(match.Groups["east"].Value);
            var west = decimal.Parse(match.Groups["west"].Value);

            var southwest = new Point(south, west);
            var northeast = new Point(north, east);

            MakeFromPoint(southwest, northeast);
        }

        public BoundingBox (DbGeometry geometry) : this(GetPointsFromDbGeometry(geometry))
        {
        }

        public BoundingBox(IEnumerable<DbGeometry> geometries)
            : this(geometries.SelectMany(GetPointsFromDbGeometry).ToList())
        {
        }

        public BoundingBox(BoundingBoxJson boundingBoxJson)
        {
            var southwest = new Point(boundingBoxJson.Bottom, boundingBoxJson.Left);
            var northeast = new Point(boundingBoxJson.Top, boundingBoxJson.Right);

            MakeFromPoint(southwest, northeast);
        }

        private void MakeFromPoint(Point southwest, Point northeast)
        {
            DemandIsValid(southwest, northeast);

            Southwest = southwest;
            Northeast = northeast;
        }

        public static BoundingBox MakeNewDefaultBoundingBox()
        {
            return new BoundingBox(MultiTenantHelpers.GetDefaultBoundingBox());
        }

        public static List<Point> GetPointsFromDbGeometry(DbGeometry geometry)
        {
            var pointList = new List<Point>();
            if (!DbGeometryToGeoJsonHelper.CanParseGeometry(geometry))
            {
                return pointList;
            }

            var pointCount = geometry.Envelope.ElementAt(1).PointCount.Value;
            var envelope = geometry.Envelope.ElementAt(1);
            

            for (var i = 1; i <= pointCount; i++)
            {
                var dbGeometryPoint = envelope.PointAt(i);

                if (!dbGeometryPoint.XCoordinate.HasValue || !dbGeometryPoint.YCoordinate.HasValue)
                {
                    continue;
                }

                pointList.Add(new Point(envelope.PointAt(i).YCoordinate.Value, envelope.PointAt(i).XCoordinate.Value));
            }
            return pointList;
        }

        public static BoundingBox MakeBoundingBoxFromGeoJson(string geoJson)
        {
            var result = OgrInfoCommandLineRunner.GetExtentFromGeoJson(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable),
                geoJson,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            if (result == null)
            {
                return MakeNewDefaultBoundingBox();
            }

            var p1 = new Point(result.Item2, result.Item1);
            var p2 = new Point(result.Item4, result.Item3);

            var boundingBox = new BoundingBox(p1, p2);
            return boundingBox;
        }

        public static BoundingBox MakeBoundingBoxFromProject(IProject project)
        {
            if (project.GetDefaultBoundingBox() != null)
            {
                return new BoundingBox(project.GetDefaultBoundingBox());
            }

            if (project.GetProjectLocationDetails().Any())
            {
                var pointList = new List<Point>();
                
                // If there is a Project point (lat/lng), include it
                if (project.ProjectLocationPoint != null)
                {
                    pointList.Add(new Point(project.ProjectLocationPoint));
                }

                // Always include Project Location details
                foreach (DbGeometry geometry in project.GetProjectLocationDetails().Select(x => x.GetProjectLocationGeometry()))
                {
                    pointList.AddRange(GetPointsFromDbGeometry(geometry));
                }

                return new BoundingBox(pointList);
            }

            if (project.ProjectLocationPoint != null)
            {
                return new BoundingBox(new Point(project.ProjectLocationPoint), 0.001m);
            }

            if (project.GetProjectGeospatialAreas().Any())
            {
                return new BoundingBox(project.GetProjectGeospatialAreas().Select(x => x.GeospatialAreaFeature).ToList());
            }

            if (MultiTenantHelpers.GetDefaultBoundingBox() != null)
            {
                return new BoundingBox(MultiTenantHelpers.GetDefaultBoundingBox());
            }

            var geospatialAreaDbGeometries = HttpRequestStorage.DatabaseEntities.GeospatialAreas.Select(x => x.GeospatialAreaFeature).ToList();
            return geospatialAreaDbGeometries.Any()
                ? new BoundingBox(geospatialAreaDbGeometries)
                : MakeNewDefaultBoundingBox();
        }

        public static BoundingBox MakeBoundingBoxFromLayerGeoJsonList(List<LayerGeoJson> layerGeoJsons)
        {
            return !layerGeoJsons.Any() ? MakeNewDefaultBoundingBox() : new BoundingBox(layerGeoJsons.Select(x => MakeBoundingBoxFromGeoJson(x.GetGeoJsonFeatureCollectionAsJsonString())).ToList());
        }

        public static void DemandIsValid(Point southWestPoint, Point northEastPoint)
        {
            var isValid = southWestPoint.Latitude <= northEastPoint.Latitude;
            if (!isValid)
            {
                throw new ArgumentOutOfRangeException("southWestPoint",
                    $"SouthWest latitude {southWestPoint.Latitude} must be less than Northeast latitude {northEastPoint.Latitude}");
            }
        }

        public Point GetCenterPoint()
        {
            var latitude = ((Northeast.Latitude - Southwest.Latitude) / 2) + Southwest.Latitude;
            var eastLongitude = Northeast.Longitude + 180;
            var westLongitude = Southwest.Longitude + 180;
            var crossedTheInternationalDateLine = westLongitude > eastLongitude;

            var longitudeDifference = (eastLongitude - westLongitude) / 2;
            var longitude = westLongitude + ((crossedTheInternationalDateLine) ? longitudeDifference - 360 : longitudeDifference - 180);
            return new Point(latitude, longitude);
        }

        /// <summary>
        /// This should be the opposite of <see cref="BoundingBox(string)"/>
        /// </summary>
        public override string ToString()
        {
            return $"{Northeast.Latitude}~{Southwest.Latitude}~{Northeast.Longitude}~{Southwest.Longitude}";
        }

        public class BoundingBoxModelBinder : SitkaModelBinder
        {
            public BoundingBoxModelBinder() : base(s => new BoundingBox(s))
            {
            }
        }

        public bool IsEquvalentTo(BoundingBox boxB)
        {
            return Southwest == boxB.Southwest && Northeast == boxB.Northeast;
        }
    }
}
