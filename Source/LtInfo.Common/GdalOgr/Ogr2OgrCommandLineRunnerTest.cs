/*-----------------------------------------------------------------------
<copyright file="Ogr2OgrCommandLineRunnerTest.cs" company="Sitka Technology Group">
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

using System.IO;
using System.Linq;
using NUnit.Framework;

namespace LtInfo.Common.GdalOgr
{
    [TestFixture]
    public class Ogr2OgrCommandLineRunnerTest : DatabaseDirectAccessTestFixtureBase
    {
        private const int CoordinateSystemId = 4326;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            BaseFixtureSetup();
        }

        [TestFixtureTearDown]
        public void TestFixtureTeardown()
        {
            BaseFixtureTeardown();
        }

        [Test]
        public void CanProperlyCreateCommandLineOptionsForOgr2OgrUsingGeoJson()
        {
            // Arrange
            // -------

            var gdalDataDirectoryInfo = new DirectoryInfo(@"C:\Program Files\GDAL\gdal-data");
            const string sourceLayerName = "MySourceLayerName";
            var inputGdbFile = new FileInfo(@"C:\temp\MyZippedGdbFile.gdb.zip");

            // Act
            // ---
            var actualCommandLineArguments = Ogr2OgrCommandLineRunner.BuildCommandLineArgumentsForFileGdbToGeoJson(
                inputGdbFile,
                gdalDataDirectoryInfo,
                sourceLayerName, CoordinateSystemId, true);

            // Assert
            // ------

            // Expecting a command line something like this:
            //"C:\Program Files\GDAL\ogr2ogr.exe" --config GDAL_DATA "C:\\Program Files\\GDAL\\gdal-data" -t_srs EPSG:4326 -explodecollections -f GeoJSON /dev/stdout "C:\\svn\\sitkatech\\trunk\\Corral\\Source\\ProjectFirma.Web\\Models\\GdalOgr\\SampleFileGeodatabase.gdb.zip" \"MySourceLayerName\" -dim 2

            var expectedCommandLineArguments = new[] { "--config", "GDAL_DATA", gdalDataDirectoryInfo.FullName, "-t_srs", Ogr2OgrCommandLineRunner.GetMapProjection(CoordinateSystemId), "-explodecollections", "-f", "GeoJSON", "/dev/stdout", inputGdbFile.FullName, string.Format("\"{0}\"", sourceLayerName), "-dim", "2" };

            Assert.That(actualCommandLineArguments, Is.EquivalentTo(expectedCommandLineArguments), "Should produce expected arguments");

            var expectedCommandLineArgumentsEncodedString = string.Join(" ", expectedCommandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());
            var actualCommandLineArgumentsEncodedString = string.Join(" ", actualCommandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());

            Assert.That(actualCommandLineArgumentsEncodedString, Is.EqualTo(expectedCommandLineArgumentsEncodedString), "Should produce the expected command line argument string in the correct order");
        }

        [Test]
        public void CanExecuteOgr2OgrForFileGdbToGeoJson()
        {
            // Arrange
            // -------

        var gdbFileInfo = FileUtility.FirstMatchingFileUpDirectoryTree(@"LTInfo.Common\GdalOgr\SampleFileGeodatabase.gdb.zip");
            const string sourceLayerName = "MySampleFeatureClass";

            // Act
            // ---
            const int totalMilliseconds = 110000;
            const string pathToOgr2OgrExecutable = @"C:\Program Files\GDAL\ogr2ogr.exe";
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(pathToOgr2OgrExecutable, CoordinateSystemId, totalMilliseconds);
            var geoJson = ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFileInfo, sourceLayerName, true);

            // Assert
            // ------
            Assert.That(geoJson, Contains.Substring("\"properties\":"), "Should have properties");
        }
    }
}

