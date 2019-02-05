/*-----------------------------------------------------------------------
<copyright file="Point.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Spatial;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using NUnit.Framework;

namespace ProjectFirmaModels.Models
{
    [ModelBinder(typeof(PointModelBinder))] // ModelBinder is for Action parameter parsing
    public class Point : IEquatable<Point>
    {
        private const int MaximumLongitude = 180;
        private const int MaximumLattitude = 90;

        public decimal Latitude
        {
            get { return _latitude; }
            private set
            {
                //Check.Require(value <= MaximumLattitude && value >= -MaximumLattitude, new ArgumentOutOfRangeException(String.Format("Invalid latitude {0}: needs to be between -90 and 90", value)));
                _latitude = value;
            }
        }

        public decimal Longitude
        {
            get { return _longitude; }
            private set
            {
                //Check.Require(value <= MaximumLongitude && value >= -MaximumLongitude, new ArgumentOutOfRangeException(String.Format("Invalid longitude {0}: needs to be between -180 and 180", value)));
                _longitude = value;
            }
        }

        public static Point Empty = new Point(-1m, -1m);
        private decimal _longitude;
        private decimal _latitude;

        public Point(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Point(double latitude, double longitude)
        {
            Latitude = Convert.ToDecimal(latitude);
            Longitude = Convert.ToDecimal(longitude);
        }

        public Point(DbGeometry dbGeometry)
        {
            var incomingSpatialType = dbGeometry.SpatialTypeName;
            Assert.That(incomingSpatialType == "Point", String.Format("Points can only be created from DbGeometry types, not '{0}' as passed.", incomingSpatialType));

            Latitude = Convert.ToDecimal(dbGeometry.YCoordinate);
            Longitude = Convert.ToDecimal(dbGeometry.XCoordinate);
        }

        public Point(string urlParameter)
        {
            // Lat~Long
            var pattern = new Regex("^(?<latitude>[^~]+)~(?<longitude>[^~]+)$");
            var match = pattern.Match(urlParameter);

            Check.Require(match.Success, String.Format("Value \"{0}\" does not parse as a {1}.", urlParameter, GetType().Name));

            Latitude = Decimal.Parse(match.Groups["latitude"].Value);
            Longitude = Decimal.Parse(match.Groups["longitude"].Value);
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.Latitude == Latitude && other.Longitude == Longitude;
        }

        public static bool operator ==(Point left, Point right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(Point))
            {
                return false;
            }
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Latitude.GetHashCode()*397) ^ Longitude.GetHashCode();
            }
        }

        public override string ToString()
        {
            return String.Format("[{0},{1}]", Latitude.ToString("0.00"), Longitude.ToString("0.00"));
        }

        public class PointModelBinder : SitkaModelBinder
        {
            public PointModelBinder() : base(s => new Point(s))
            {
            }
        }
    }
}
