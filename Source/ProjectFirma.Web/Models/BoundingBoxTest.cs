using System;
using LtInfo.Common;
using LtInfo.Common.GdalOgr;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class BoundingBoxTest
    {
        private const int CoordinateSystemId = 4326;

        [Test]
        public void CanCreateBoundingBoxFromGeoJson()
        {
            var gdbFileInfo = FileUtility.FirstMatchingFileUpDirectoryTree(@"LTInfo\LTInfo.Common\GdalOgr\SampleFileGeodatabase.gdb.zip");
            const string sourceLayerName = "MySampleFeatureClass";
            // Act
            // ---
            const int totalMilliseconds = 110000;
            const string pathToOgr2OgrExecutable = @"C:\Program Files\GDAL\ogr2ogr.exe";
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(pathToOgr2OgrExecutable, CoordinateSystemId, totalMilliseconds);
            var geoJson = ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFileInfo, sourceLayerName);

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