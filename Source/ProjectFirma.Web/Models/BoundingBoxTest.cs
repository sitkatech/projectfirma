/*-----------------------------------------------------------------------
<copyright file="BoundingBoxTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.GdalOgr;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class BoundingBoxTest
    {
        [Test]
        public void CanCreateBoundingBoxFromGeoJson()
        {
            var gdbFileInfo = FileUtility.FirstMatchingFileUpDirectoryTree(@"LTInfo.Common\GdalOgr\SampleFileGeodatabase.gdb.zip");
            const string sourceLayerName = "MySampleFeatureClass";
            // Act
            // ---
            const int totalMilliseconds = 110000;
            const string pathToOgr2OgrExecutable = @"C:\Program Files\GDAL\ogr2ogr.exe";
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(pathToOgr2OgrExecutable, LtInfoGeometryConfiguration.DefaultCoordinateSystemId, totalMilliseconds);
            var geoJson = ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFileInfo, sourceLayerName, true);

            // Act
            // ---            
            var boundingBox = BoundingBox.MakeBoundingBoxFromGeoJson(geoJson);

            var expectedResult = new Tuple<double, double, double, double>(-122.825678, 45.555868, -122.272895, 45.938212);

            Assert.That(expectedResult.Item1, Is.EqualTo(boundingBox.Southwest.Longitude));
            Assert.That(expectedResult.Item2, Is.EqualTo(boundingBox.Southwest.Latitude));
            Assert.That(expectedResult.Item3, Is.EqualTo(boundingBox.Northeast.Longitude));
            Assert.That(expectedResult.Item4, Is.EqualTo(boundingBox.Northeast.Latitude));
        }
    }
}
