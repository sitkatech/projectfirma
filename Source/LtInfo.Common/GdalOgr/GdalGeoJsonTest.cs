/*-----------------------------------------------------------------------
<copyright file="GdalGeoJsonTest.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LtInfo.Common.GdalOgr
{
    [TestFixture]
    public class GdalGeoJsonTest
    {
        private const int CoordinateSystemId = 4326;
        
        [Test]
        public void CanReadColumnNamesFromGeoJsonString()
        {
            // Arrange
            // -------
            var gdbFileInfo = FileUtility.FirstMatchingFileUpDirectoryTree(@"LTInfo.Common\GdalOgr\SampleFileGeodatabase.gdb.zip");
            const string sourceLayerName = "MySampleFeatureClass";
            const int totalMilliseconds = 110000;
            const string pathToOgr2OgrExecutable = @"C:\Program Files\GDAL\ogr2ogr.exe";
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(pathToOgr2OgrExecutable, GdalGeoJsonTest.CoordinateSystemId, totalMilliseconds);

            // Act
            // ---
            var geoJson = ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFileInfo, sourceLayerName, true);

            // Assert
            // ------
            var featureCollection = JsonTools.DeserializeObject<GeoJSON.Net.Feature.FeatureCollection>(geoJson);
            var propertyNames = featureCollection.Features.First().Properties.Select(x => x.Key).ToList();
            var expectedPropertyNames = new List<string> { "MyStringColumn", "IgnoredTextColumn", "IgnoredIntColumn", "MyIntColumn", "MyFloatColumn", "Shape_Length", "Shape_Area" };
            Assert.That(propertyNames, Is.EquivalentTo(expectedPropertyNames), "Should get expected columns");
        }
    }
}
