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
using System;
using System.Data;
using System.Diagnostics;
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
        public void CanProperlyCreateCommandLineOptionsForArcGisQueryToMsSQL()
        {
            // Arrange
            // -------

            var gdalDataDirectoryInfo = new DirectoryInfo(@"C:\Program Files\GDAL\gdal-data");
            const string destinationTableName = "MyTableWithGeometry";
            const string arcGisQuery = "http://sampleserver3.arcgisonline.com/ArcGIS/rest/services/Hydrography/Watershed173811/FeatureServer/0/query?where=objectid+%3D+objectid&outfields=*&f=json";
            // Act
            // ---
            const string sourceColumnName = "areasqkm";
            const string destinationColumnName = "SquareKm";
            var actualCommandLineArguments = Ogr2OgrCommandLineRunner.BuildCommandLineArgumentsForArgGisQueryToMsSql(arcGisQuery, gdalDataDirectoryInfo, TempDbSqlDatabase.DatabaseConnectionStringToTempDb, destinationTableName, sourceColumnName, destinationColumnName, CoordinateSystemId);

            // Assert
            // ------

            // Expecting a command line something like this:
            //"C:\Program Files\GDAL\ogr2ogr.exe" -append -sql "select areasqkm as SquareKm from OGRGeoJSON --config GDAL_DATA "C:\\Program Files\\GDAL\\gdal-data" -f MSSQLSpatial dbconnectionstring test.json "http://sampleserver3.arcgisonline.com/ArcGIS/rest/services/Hydrography/Watershed173811/FeatureServer/0/query?where=objectid+%3D+objectid&outfields=*&f=json" -nln SomeTableName"

            var expectedCommandLineArguments = new[]
            {
                "-append", "-sql", string.Format("SELECT {0} AS {1} FROM {2}", sourceColumnName, destinationColumnName, Ogr2OgrCommandLineRunner.OgrGeoJsonTableName), "--config", "GDAL_DATA", gdalDataDirectoryInfo.FullName, "-t_srs", Ogr2OgrCommandLineRunner.GetMapProjection(CoordinateSystemId),
                "-f", "MSSQLSpatial", TempDbSqlDatabase.DatabaseConnectionStringToTempDb, string.Format("\"{0}\"", arcGisQuery), "-nln", destinationTableName
            };
            Assert.That(actualCommandLineArguments, Is.EquivalentTo(expectedCommandLineArguments), "Should produce expected arguments");

            var expectedCommandLineArgumentsEncodedString = string.Join(" ", expectedCommandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());
            var actualCommandLineArgumentsEncodedString = string.Join(" ", actualCommandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());

            Assert.That(actualCommandLineArgumentsEncodedString, Is.EqualTo(expectedCommandLineArgumentsEncodedString), "Should produce the expected command line argument string in the correct order");
        }

        [Test]
        public void CanProperlyCreateCommandLineOptionsForOgr2OgrUsingGeoJSON()
        {
            // Arrange
            // -------

            var gdalDataDirectoryInfo = new DirectoryInfo(@"C:\Program Files\GDAL\gdal-data");
            const string sourceLayerName = "MySourceLayerName";
            var inputGdbFile = new FileInfo(@"C:\temp\MyZippedGdbFile.gdb.zip");

            // Act
            // ---
            var actualCommandLineArguments = Ogr2OgrCommandLineRunner.BuildCommandLineArgumentsForFileGdbToGeoJson(inputGdbFile,
                gdalDataDirectoryInfo,
                sourceLayerName, CoordinateSystemId);

            // Assert
            // ------

            // Expecting a command line something like this:
            //"C:\Program Files\GDAL\ogr2ogr.exe" --config GDAL_DATA "C:\\Program Files\\GDAL\\gdal-data" -t_srs EPSG:4326 -explodecollections -f GeoJSON /dev/stdout "C:\\svn\\sitkatech\\trunk\\Corral\\Source\\Corral.Web\\Models\\GdalOgr\\SampleFileGeodatabase.gdb.zip"

            var expectedCommandLineArguments = new[] { "--config", "GDAL_DATA", gdalDataDirectoryInfo.FullName, "-t_srs", Ogr2OgrCommandLineRunner.GetMapProjection(CoordinateSystemId), "-explodecollections", "-f", "GeoJSON", "/dev/stdout", inputGdbFile.FullName, string.Format("\"{0}\"", sourceLayerName) };

            Assert.That(actualCommandLineArguments, Is.EquivalentTo(expectedCommandLineArguments), "Should produce expected arguments");

            var expectedCommandLineArgumentsEncodedString = string.Join(" ", expectedCommandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());
            var actualCommandLineArgumentsEncodedString = string.Join(" ", actualCommandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());

            Assert.That(actualCommandLineArgumentsEncodedString, Is.EqualTo(expectedCommandLineArgumentsEncodedString), "Should produce the expected command line argument string in the correct order");
        }

        [Test]
        [Ignore]
        public void CanExecuteOgr2OgrForArcGisQueryToMsSQL()
        {
            // Arrange
            // -------
            const string arcGisQuery = "http://sampleserver3.arcgisonline.com/ArcGIS/rest/services/Hydrography/Watershed173811/FeatureServer/0/query?where=objectid%20IN%20%281%2C2%2C3%2C4%29&outfields=*&f=json";

            const string destinationTableName = "test_table";
            const string sourceColumnName = "areasqkm";
            const string destinationColumnName = "attribute";

            // Act
            // ---
            const int totalMilliseconds = 110000;
            const string pathToOgr2OgrExecutable = @"C:\Program Files\GDAL\ogr2ogr.exe";
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(pathToOgr2OgrExecutable, CoordinateSystemId, totalMilliseconds);

            try
            {
                CreateOgrRequiredTables(null, destinationTableName);

                // Act
                // ---
                ogr2OgrCommandLineRunner.ImportArcGisQueryToMsSql(arcGisQuery, destinationTableName, sourceColumnName, destinationColumnName, TempDbSqlDatabase.DatabaseConnectionStringToTempDb);
                var result = ExecAdHocSql(string.Format("select * from {0}", destinationTableName));

                // Assert
                // ------

                Assert.That(result, Is.Not.Null, "Should have found the table imported");
                Assert.That(result.Rows.Count, Is.EqualTo(4), "Should have gotten 4 rows");

                var myStringColumns = result.Rows.Cast<DataRow>().Select(x => x.IsNull(destinationColumnName) ? null : (string)x[destinationColumnName]).ToList();
                Assert.That(myStringColumns, Is.EquivalentTo(new[] { "0.043", "0.012", "0.013", "0.008" }), "Should have gotten these values for areasquarekm");

            }
            finally
            {
                // Cleanup
                // -------
                try
                {
                    ExecAdHocSql("drop table " + destinationTableName);
                }
                catch
                {
                    // ignored
                }
                try
                {
                    ExecAdHocSql("drop table spatial_ref_sys");
                }
                catch
                {
                    // ignored
                }
                try
                {
                    ExecAdHocSql("drop table geometry_columns");
                }
                catch
                {
                    // ignored
                }
            }

        }

        [Test]
        public void CanExecuteOgr2OgrForFileGdbToGeoJson()
        {
            // Arrange
            // -------

        var gdbFileInfo = FileUtility.FirstMatchingFileUpDirectoryTree(@"LTInfo\LTInfo.Common\GdalOgr\SampleFileGeodatabase.gdb.zip");
            const string sourceLayerName = "MySampleFeatureClass";

            // Act
            // ---
            const int totalMilliseconds = 110000;
            const string pathToOgr2OgrExecutable = @"C:\Program Files\GDAL\ogr2ogr.exe";
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(pathToOgr2OgrExecutable, CoordinateSystemId, totalMilliseconds);
            var geoJson = ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFileInfo, sourceLayerName);

            // Assert
            // ------
            Assert.That(geoJson, Contains.Substring("\"properties\":"), "Should have properties");
        }

        [Test]
        public void CanExecuteOgr2OgrFromGeoJsonSingleColumnToExistingMsSql()
        {
            var gdbFileInfo = FileUtility.FirstMatchingFileUpDirectoryTree(@"LTInfo\LTInfo.Common\GdalOgr\SampleFileGeodatabase.gdb.zip");
            const string sourceLayerName = "MySampleFeatureClass";
            // Act
            // ---
            const int totalMilliseconds = 110000;
            const string pathToOgr2OgrExecutable = @"C:\Program Files\GDAL\ogr2ogr.exe";
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(pathToOgr2OgrExecutable, CoordinateSystemId, totalMilliseconds);
            var geoJson = ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFileInfo, sourceLayerName);

            var sourceColumnName1 = "mystringcolumn";
            var destinationTableName = "test_table";
            var destinationColumnName = "attribute";
            
            try
            {                
                CreateOgrRequiredTables(destinationTableName, null);
                
                // Act
                // ---
                ogr2OgrCommandLineRunner.ImportGeoJsonToMsSql(geoJson, TempDbSqlDatabase.DatabaseConnectionStringToTempDb, destinationTableName, sourceColumnName1, destinationColumnName, string.Format(", {0} as ProjectID", 77));
                var result = ExecAdHocSql(string.Format("select * from {0}", destinationTableName));

                // Assert
                // ------
                          
                Assert.That(result, Is.Not.Null, "Should have found the table imported");
                Assert.That(result.Rows.Count, Is.EqualTo(6), "Should have gotten 6 rows");
                
                var myStringColumns = result.Rows.Cast<DataRow>().Select(x => x.IsNull(destinationColumnName) ? null : (string)x[destinationColumnName]).ToList();
                Assert.That(myStringColumns, Is.EquivalentTo(new[] { "Excavate channels to lakes", "Excavate channels to lakes", null, null, "LCEP shp", "LCEP shp" }), "Should have gotten these values for MyStringColumn");
                
            }
            finally
            {
                // Cleanup
                // -------
                try
                {
                    ExecAdHocSql("drop table " + destinationTableName);
                }
                catch
                {
                    // ignored
                }
                try
                {
                    ExecAdHocSql("drop table spatial_ref_sys");
                }
                catch
                {
                    // ignored
                }
                try
                {
                    ExecAdHocSql("drop table geometry_columns");
                }
                catch
                {
                    // ignored
                }
            }
        }

        private void CreateOgrRequiredTables(string tableWithGeometryField, string tableWithGeometryField2)
        {
            const string createOgrRequiredTablesTemplate = @"
CREATE TABLE dbo.spatial_ref_sys(
	srid int NOT NULL,
	auth_name varchar(256) NULL,
	auth_srid int NULL,
	srtext varchar(2048) NULL,
	proj4text varchar(2048) NULL,
CONSTRAINT PK_spatial_ref_sys_srid PRIMARY KEY CLUSTERED 
(
	srid ASC
)
)


CREATE TABLE dbo.geometry_columns(
	f_table_catalog varchar(128) NOT NULL,
	f_table_schema varchar(128) NOT NULL,
	f_table_name varchar(256) NOT NULL,
	f_geometry_column varchar(256) NOT NULL,
	coord_dimension int NOT NULL,
	srid int NOT NULL,
	geometry_type varchar(30) NOT NULL,
CONSTRAINT PK_geometry_columns_f_table_catalog_f_table_schema_f_table_name_f_geometry_column PRIMARY KEY CLUSTERED
(
	f_table_catalog ASC,
	f_table_schema ASC,
	f_table_name ASC,
	f_geometry_column ASC
)
)";
            ExecAdHocSql(createOgrRequiredTablesTemplate);


            if (!string.IsNullOrWhiteSpace(tableWithGeometryField))
            {
                const string createTableSqlTemplate = @"
CREATE TABLE {0}
(
    ogr_fid int identity(1,1) NOT NULL,
    ogr_geometry geometry NOT NULL,
    attribute varchar(255) NULL,
    ProjectID int not null
)
";

                ExecAdHocSql(string.Format(createTableSqlTemplate, tableWithGeometryField));
                const string populateOgrGeometryTableTemplate = @"
insert into dbo.geometry_columns(f_table_catalog, f_table_schema, f_table_name, f_geometry_column, coord_dimension, srid, geometry_type)
values('tempdb', 'dbo',	'{0}', 'Ogr_Geometry', 2, 4326, 'MULTIPOLYGON')";

                ExecAdHocSql(string.Format(populateOgrGeometryTableTemplate, tableWithGeometryField));
            }

            if (!string.IsNullOrWhiteSpace(tableWithGeometryField2))
            {
                const string createTableSqlTemplate2 = @"
CREATE TABLE {0}
(
    ogr_fid int NOT NULL,
    ogr_geometry geometry NOT NULL,
    attribute varchar(255) NULL
)
";
                ExecAdHocSql(string.Format(createTableSqlTemplate2, tableWithGeometryField2));
                const string populateOgrGeometryTableTemplate = @"
insert into dbo.geometry_columns(f_table_catalog, f_table_schema, f_table_name, f_geometry_column, coord_dimension, srid, geometry_type)
values('tempdb', 'dbo',	'{0}', 'Ogr_Geometry', 2, 4326, 'MULTIPOLYGON')";

                ExecAdHocSql(string.Format(populateOgrGeometryTableTemplate, tableWithGeometryField2));
            }

        }

    }
}

