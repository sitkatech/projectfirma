using System.Collections.Generic;
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
            var gdbFileInfo = FileUtility.FirstMatchingFileUpDirectoryTree(@"LTInfo\LTInfo.Common\GdalOgr\SampleFileGeodatabase.gdb.zip");
            const string sourceLayerName = "MySampleFeatureClass";

            // Act
            // ---
            const int totalMilliseconds = 110000;
            const string pathToOgr2OgrExecutable = @"C:\Program Files\GDAL\ogr2ogr.exe";
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(pathToOgr2OgrExecutable, GdalGeoJsonTest.CoordinateSystemId, totalMilliseconds);
            var geoJson = ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFileInfo, sourceLayerName);


            var a = JsonTools.DeserializeObject<GeoJSON.Net.Feature.FeatureCollection>(geoJson);
            var columnList = new List<string> {"Ogr_Fid", "Ogr_Geometry", "MyIntColumn", "MyStringColumn", "MyFloatColumn"};
        }
    }
}