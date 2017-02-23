/*-----------------------------------------------------------------------
<copyright file="DbSpatialHelperTest.cs" company="Sitka Technology Group">
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
using NUnit.Framework;

namespace LtInfo.Common.DbSpatial
{
    [TestFixture]
    public class DbSpatialHelperTest
    {
        private const double FeetPerMeter = 3.28084;
        private const double MetersPerLatDegreeAt45DegreesNorth = 111131.745;
        private const double MetersPerLonDegreeAt45DegreesNorth = 78846.80572069259;

        [Test]
        public void CanCalculateFeetPerDegreeLatitude()
        {
            var geometry = DbSpatialHelper.MakeDbGeometryFromCoordinates(120, 45, 4326);            
            var feetPerLatDegree = MetersPerLatDegreeAt45DegreesNorth * FeetPerMeter;
            var a = DbSpatialHelper.FeetToLatDegree(geometry, feetPerLatDegree);
            //Check that our calcs match the NWS expected value of 1 degree
            Assert.That(a, Is.InRange(0.9999, 1.0001));
        }

        [Test]
        public void CanCalculateFeetPerDegreeLongitude()
        {
            var geometry = DbSpatialHelper.MakeDbGeometryFromCoordinates(120, 45, 4326);
            var feetPerLonDegree = MetersPerLonDegreeAt45DegreesNorth * FeetPerMeter;
            var a = DbSpatialHelper.FeetToLonDegree(geometry, feetPerLonDegree);
            //Check that our calcs match the NWS expected value of 1 degree
            Assert.That(a, Is.InRange(0.9999, 1.0001));
        }


        [Test]
        public void CanCalculateDegreesCorrespondingToToleranceInFeet()
        {
            var geometry = DbSpatialHelper.MakeDbGeometryFromCoordinates(120, 45, 4326);
            var feetPerAverageLatLonDegree = ((MetersPerLatDegreeAt45DegreesNorth + MetersPerLonDegreeAt45DegreesNorth) / 2) * FeetPerMeter;            
            var a = DbSpatialHelper.FeetToAverageLatLonDegree(geometry, feetPerAverageLatLonDegree);
            //Check that our calcs match the NWS expected value of 1 degree
            Assert.That(a, Is.InRange(0.9999, 1.0001));

            //Check at 20 degrees North
            geometry = DbSpatialHelper.MakeDbGeometryFromCoordinates(120, 20, 4326);
            var MetersPerLatDegreeAt20DegreesNorth = 110704.27818646189;
            var MetersPerLonDegreeAt20DegreesNorth = 104647.05311831612;
            feetPerAverageLatLonDegree = ((MetersPerLatDegreeAt20DegreesNorth + MetersPerLonDegreeAt20DegreesNorth) / 2) * FeetPerMeter;
            a = DbSpatialHelper.FeetToAverageLatLonDegree(geometry, feetPerAverageLatLonDegree);
            //Check that our calcs match the NWS expected value of 1 degree
            Assert.That(a, Is.InRange(0.9999, 1.0001));

            //Check at 60 degrees North
            geometry = DbSpatialHelper.MakeDbGeometryFromCoordinates(120, 60, 4326);
            var MetersPerLatDegreeAt60DegreesNorth = 111412.24020000001;
            var MetersPerLonDegreeAt60DegreesNorth = 55799.979000000014;
            feetPerAverageLatLonDegree = ((MetersPerLatDegreeAt60DegreesNorth + MetersPerLonDegreeAt60DegreesNorth) / 2) * FeetPerMeter;
            a = DbSpatialHelper.FeetToAverageLatLonDegree(geometry, feetPerAverageLatLonDegree);
            //Check that our calcs match the NWS expected value of 1 degree
            Assert.That(a, Is.InRange(0.9999, 1.0001));
        }
    }
}
