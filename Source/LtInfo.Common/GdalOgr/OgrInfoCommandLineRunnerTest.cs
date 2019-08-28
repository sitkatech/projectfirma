/*-----------------------------------------------------------------------
<copyright file="OgrInfoCommandLineRunnerTest.cs" company="Sitka Technology Group">
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
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace LtInfo.Common.GdalOgr
{
    [TestFixture]
    public class OgrInfoCommandLineRunnerTest
    {
        private const int CoordinateSystemId = 4326;

        [Test]
        public void CanProperlyCreateCommandLineOptionsForOgrInfoToParseFeatureClasses()
        {
            // Arrange
            // -------

            var gdalDataDirectoryInfo = new DirectoryInfo(@"C:\Program Files\GDAL\gdal-data");
            var inputGdbFile = new FileInfo(@"C:\temp\MyZippedGdbFile.gdb.zip");

            // Act
            // ---
            var actualCommandLineArguments = OgrInfoCommandLineRunner.BuildOgrInfoCommandLineArgumentsToListFeatureClasses(inputGdbFile,
                gdalDataDirectoryInfo);

            // Assert
            // ------

            // Expecting a command line something like this:
            //"C:\Program Files\GDAL\ogrinfo.exe" --config GDAL_DATA "C:\\Program Files\\GDAL\\gdal-data" -ro -so -q "C:\\temp\\SampleFileGeodatabase.gdb.zip"

            var expectedCommandLineArguments = new[] { "--config", "GDAL_DATA", gdalDataDirectoryInfo.FullName, "-ro", "-so", "-q", inputGdbFile.FullName };

            Assert.That(actualCommandLineArguments, Is.EquivalentTo(expectedCommandLineArguments), "Should produce expected arguments");

            var expectedCommandLineArgumentsEncodedString = string.Join(" ", expectedCommandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());
            var actualCommandLineArgumentsEncodedString = string.Join(" ", actualCommandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());

            Assert.That(actualCommandLineArgumentsEncodedString, Is.EqualTo(expectedCommandLineArgumentsEncodedString), "Should produce the expected command line argument string in the correct order");
        }

        [Test]
        public void CanExecuteOgrInfoToParseFeatureClassesSuccessfully()
        {
            // Arrange
            // -------

            var gdbFileInfo = FileUtility.FirstMatchingFileUpDirectoryTree(@"LtInfo.Common\GdalOgr\SampleFileGeodatabase.gdb.zip");
            var gdbFileInfoWith2FeatureClasses = FileUtility.FirstMatchingFileUpDirectoryTree(@"LtInfo.Common\GdalOgr\SampleFileGeodatabaseWith2FeatureClasses.gdb.zip");

            // Act
            // ---
            const int totalMilliseconds = 110000;
            const string pathToOgrInfoExecutable = @"C:\Program Files\GDAL\ogrinfo.exe";
            var result = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(pathToOgrInfoExecutable), gdbFileInfo, gdbFileInfo.Name, totalMilliseconds);
            var result2 = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(pathToOgrInfoExecutable), gdbFileInfoWith2FeatureClasses, gdbFileInfoWith2FeatureClasses.Name, totalMilliseconds);

            // Assert
            // ------
            Assert.That(result, Is.EquivalentTo(new List<string> { "MySampleFeatureClass" }), "Should return list of features");
            Assert.That(result2, Is.EquivalentTo(new List<string> { "FairviewProjectAreas", "TahoeParcelTreatments" }), "Should return list of features");
        }

        [Test]
        public void CanReadExtentFromGeoJsonFile()
        {
            var gdbFileInfo = FileUtility.FirstMatchingFileUpDirectoryTree(@"LTInfo.Common\GdalOgr\SampleFileGeodatabase.gdb.zip");
            const string sourceLayerName = "MySampleFeatureClass";
            // Act
            // ---
            const int totalMilliseconds = 110000;
            const string pathToOgr2OgrExecutable = @"C:\Program Files\GDAL\ogr2ogr.exe";
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(pathToOgr2OgrExecutable, CoordinateSystemId, totalMilliseconds);
            var geoJson = ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFileInfo, sourceLayerName, true);

            // Act
            // ---            
            const string pathToOgrInfoExecutable = @"C:\Program Files\GDAL\ogrinfo.exe";
            var result = OgrInfoCommandLineRunner.GetExtentFromGeoJson(new FileInfo(pathToOgrInfoExecutable), geoJson, totalMilliseconds);

            // Assert
            // ------
            var expectedResult = new Tuple<double, double, double, double>(-122.825678, 45.555868, -122.272895, 45.938212);
            Assert.That(result.Item1, Is.EqualTo(expectedResult.Item1));
            Assert.That(result.Item2, Is.EqualTo(expectedResult.Item2));
            Assert.That(result.Item3, Is.EqualTo(expectedResult.Item3));
            Assert.That(result.Item4, Is.EqualTo(expectedResult.Item4));
        }
   
    }
}
