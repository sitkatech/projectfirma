using ApprovalTests;
using ApprovalTests.Reporters;
using LtInfo.Common;
using NUnit.Framework;
using ProjectFirmaModels.UnitTestCommon;
using DataTableExtensions = ProjectFirmaModels.UnitTestCommon.DataTableExtensions;

namespace ProjectFirmaModels.Models
{
    [TestFixture]
    public class GeometryTest : DatabaseDirectAccessTestFixtureBase
    {
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

        [Test, Description("All Geometries should be valid or spatial computations can fail such as intersections. Use the output to find and fix issues.")]
        [UseReporter(typeof(DiffReporter))]
        public void TestAllGeometriesAreValid()
        {
            // ReSharper disable StringLiteralTypo
            const string sql = @"
drop table if exists #geometryCol;

select c.TABLE_SCHEMA, c.TABLE_NAME, c.COLUMN_NAME
    , cast(null as varchar(1000)) as SqlQueryToTroubleshoot
    , cast(null as int) as AllFeatureCount
    , cast(null as int) as InvalidFeatureCount
    , cast(0 as bit) as HasProcessed
into #geometryCol
from
INFORMATION_SCHEMA.COLUMNS c 
join INFORMATION_SCHEMA.TABLES t on c.TABLE_CATALOG = t.TABLE_CATALOG and c.TABLE_SCHEMA = t.TABLE_SCHEMA and c.TABLE_NAME = t.TABLE_NAME
where t.TABLE_TYPE = 'BASE TABLE' and c.DATA_TYPE = 'geometry';

declare @tableSchema sysname, @tableName sysname, @columnName sysname;
declare @sqlQuery nvarchar(1000), @allFeatureCount int, @invalidFeatureCount int;
declare @sqlQueryToTroubleshoot varchar(1000)

while exists(select 1 from #geometryCol where HasProcessed = 0)
begin
    select top 1 @tableSchema = TABLE_SCHEMA, @tableName = TABLE_NAME, @columnName = COLUMN_NAME
    from #geometryCol 
    where HasProcessed = 0;

    set @sqlQuery = 'select
        @allFeatureCountOutput = (select count(*) from TABLE_SCHEMA.TABLE_NAME where COLUMN_NAME is not null),
        @invalidFeatureCountOutput = (select count(*) from TABLE_SCHEMA.TABLE_NAME where COLUMN_NAME.STIsValid() = 0)';

    set @sqlQuery = REPLACE(@sqlQuery, 'TABLE_SCHEMA', @tableSchema);
    set @sqlQuery = REPLACE(@sqlQuery, 'TABLE_NAME', @tableName);
    set @sqlQuery = REPLACE(@sqlQuery, 'COLUMN_NAME', @columnName);

    exec sp_executesql @sqlQuery, N'@allFeatureCountOutput int OUTPUT, @invalidFeatureCountOutput int OUTPUT', @allFeatureCountOutput = @allFeatureCount OUTPUT, @invalidFeatureCountOutput = @invalidFeatureCount OUTPUT;

    set @sqlQueryToTroubleshoot = 'select *, COLUMN_NAME.STAsText() as COLUMN_NAMEAsText, COLUMN_NAME.MakeValid().STAsText() as COLUMN_NAMEMakeValidAsText from TABLE_SCHEMA.TABLE_NAME where COLUMN_NAME.STIsValid() = 0';
    set @sqlQueryToTroubleshoot = REPLACE(@sqlQueryToTroubleshoot, 'TABLE_SCHEMA', @tableSchema);
    set @sqlQueryToTroubleshoot = REPLACE(@sqlQueryToTroubleshoot, 'TABLE_NAME', @tableName);
    set @sqlQueryToTroubleshoot = REPLACE(@sqlQueryToTroubleshoot, 'COLUMN_NAME', @columnName);

    update #geometryCol
    set HasProcessed = 1, AllFeatureCount = @allFeatureCount, InvalidFeatureCount = @invalidFeatureCount, SqlQueryToTroubleshoot = @sqlQueryToTroubleshoot
    where TABLE_SCHEMA = @tableSchema and TABLE_NAME = @tableName and COLUMN_NAME = @columnName;
end

select * from #geometryCol where InvalidFeatureCount > 0;
";
            // ReSharper restore StringLiteralTypo
            Approvals.Verify(DataTableExtensions.TableToHumanReadableString(ExecAdHocSql(sql)));
        }

        [Test, Description("All Geometries should be same SrID maps will not work correctly. Use output to find and fix issues.")]
        [UseReporter(typeof(DiffReporter))]
        public void TestAllGeometriesHaveProperSrid()
        {
            // ReSharper disable StringLiteralTypo
            string sql = $@"
drop table if exists #geometryWrongSrIdCol;

select c.TABLE_SCHEMA, c.TABLE_NAME, c.COLUMN_NAME
    , cast(null as varchar(1000)) as SqlQueryToTroubleshoot
    , cast(null as int) as AllFeatureCount
    , cast(null as int) as WrongSridFeatureCount
    , cast(0 as bit) as HasProcessed
into #geometryWrongSrIdCol
from
INFORMATION_SCHEMA.COLUMNS c 
join INFORMATION_SCHEMA.TABLES t on c.TABLE_CATALOG = t.TABLE_CATALOG and c.TABLE_SCHEMA = t.TABLE_SCHEMA and c.TABLE_NAME = t.TABLE_NAME
where t.TABLE_TYPE = 'BASE TABLE' and c.DATA_TYPE = 'geometry';

declare @tableSchema sysname, @tableName sysname, @columnName sysname;
declare @sqlQuery nvarchar(1000), @allFeatureCount int, @wrongSridFeatureCount int;
declare @sqlQueryToTroubleshoot varchar(1000)

while exists(select 1 from #geometryCol where HasProcessed = 0)
begin
    select top 1 @tableSchema = TABLE_SCHEMA, @tableName = TABLE_NAME, @columnName = COLUMN_NAME
    from #geometryCol 
    where HasProcessed = 0;

    set @sqlQuery = 'select
        @allFeatureCountOutput = (select count(*) from TABLE_SCHEMA.TABLE_NAME where COLUMN_NAME is not null),
        @wrongSridFeatureCountOutput = (select count(*) from TABLE_SCHEMA.TABLE_NAME where COLUMN_NAME.STSrid != {LtInfoGeometryConfiguration.DefaultCoordinateSystemId})';

    set @sqlQuery = REPLACE(@sqlQuery, 'TABLE_SCHEMA', @tableSchema);
    set @sqlQuery = REPLACE(@sqlQuery, 'TABLE_NAME', @tableName);
    set @sqlQuery = REPLACE(@sqlQuery, 'COLUMN_NAME', @columnName);

    exec sp_executesql @sqlQuery, N'@allFeatureCountOutput int OUTPUT, @wrongSridFeatureCountOutput int OUTPUT', @allFeatureCountOutput = @allFeatureCount OUTPUT, @wrongSridFeatureCountOutput = @wrongSridFeatureCount OUTPUT;

    set @sqlQueryToTroubleshoot = 'select *, COLUMN_NAME.STAsText() as COLUMN_NAMEAsText, ActualSrID COLUMN_NAME.STSrid, {LtInfoGeometryConfiguration.DefaultCoordinateSystemId} as ExpectedSrID from TABLE_SCHEMA.TABLE_NAME where COLUMN_NAME.STSrid != {LtInfoGeometryConfiguration.DefaultCoordinateSystemId}';
    set @sqlQueryToTroubleshoot = REPLACE(@sqlQueryToTroubleshoot, 'TABLE_SCHEMA', @tableSchema);
    set @sqlQueryToTroubleshoot = REPLACE(@sqlQueryToTroubleshoot, 'TABLE_NAME', @tableName);
    set @sqlQueryToTroubleshoot = REPLACE(@sqlQueryToTroubleshoot, 'COLUMN_NAME', @columnName);

    update #geometryWrongSrIdCol
    set HasProcessed = 1, AllFeatureCount = @allFeatureCount, WrongSridFeatureCount = @wrongSridFeatureCount, SqlQueryToTroubleshoot = @sqlQueryToTroubleshoot
    where TABLE_SCHEMA = @tableSchema and TABLE_NAME = @tableName and COLUMN_NAME = @columnName;
end

select * from #geometryWrongSrIdCol where WrongSridFeatureCount > 0;
";
            // ReSharper restore StringLiteralTypo
            Approvals.Verify(DataTableExtensions.TableToHumanReadableString(ExecAdHocSql(sql)));
        }
    }
}