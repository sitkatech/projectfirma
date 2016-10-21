using ApprovalTests;
using ApprovalTests.Reporters;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class CheckPrimaryNaturalAndForeignKeysTest : DatabaseDirectAccessTestFixtureBase
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureEachTableHasPrimaryKeyOrAlternateKey()
        {
            const string sqlQueryString = @"
                        select *
                        from INFORMATION_SCHEMA.TABLES t 
                             left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS c on t.TABLE_NAME = c.TABLE_NAME and c.CONSTRAINT_TYPE in ('primary key', 'unique')
                        where t.TABLE_TYPE = 'BASE TABLE' and c.CONSTRAINT_TYPE is null
                        order by t.TABLE_CATALOG, t.TABLE_SCHEMA, t.TABLE_NAME";
            var result = ExecAdHocSql(sqlQueryString);
            Approvals.Verify(result.TableToHumanReadableString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureNoMissingForeignKeys()
        {
            const string sql = @"      select *
                        from
                        (
                            select c.TABLE_NAME as TableName, c.COLUMN_NAME as ColumnName
                            from INFORMATION_SCHEMA.COLUMNS c
                            join INFORMATION_SCHEMA.TABLES t on c.TABLE_NAME = t.TABLE_NAME
                            where c.COLUMN_NAME like '%ID' 
                            and t.table_type = 'BASE TABLE'
                            and c.TABLE_NAME + 'ID' != c.COLUMN_NAME
                            and c.COLUMN_NAME not like 'pisces%' and c.COLUMN_NAME not like '%OBJECTID'
                            and t.TABLE_NAME not in ('sysdiagrams', 'spatial_ref_sys', 'geometry_columns')
                            and c.COLUMN_NAME not like '%guid'
                        ) nonpkcolumns
                        left join 
                        (
                            select a.ParentTableName, a.ChildTableName, a.ConstraintName, right(ParentColumns, LEN(ParentColumns) - 1) as ParentColumnName, right(ChildColumns, LEN(childcolumns) - 1) as ChildColumnName
                            from
                            (
                                select  rt.name as ParentTableName, pt.name as ChildTableName, fk.name as ConstraintName,
                                        (         
                                            SELECT  '_' + pc.name AS [text()]
                                            from sys.foreign_key_columns fkcparent
                                            join sys.columns			 pc		on pc.object_id = fkcparent.parent_object_id and pc.column_id = fkcparent.parent_column_id
                                            WHERE   fkcparent.constraint_object_id = fk.object_id
                                            ORDER BY fkcparent.constraint_column_id
                                            FOR XML PATH(''), TYPE
                                        ).value('/', 'NVARCHAR(MAX)') as ParentColumns,
                                        (         
                                            SELECT  '_' + rc.name AS [text()]
                                            from sys.foreign_key_columns fkcchild
                                            join sys.columns			 rc		on rc.object_id = fkcchild.referenced_object_id and rc.column_id = fkcchild.referenced_column_id
                                            WHERE   fkcchild.constraint_object_id = fk.object_id
                                            ORDER BY fkcchild.constraint_column_id
                                            FOR XML PATH(''), TYPE         
                                        ).value('/', 'NVARCHAR(MAX)') as ChildColumns
                                from sys.foreign_keys		 fk
                                join sys.tables				 pt on pt.object_id = fk.parent_object_id
                                join sys.tables				 rt on rt.object_id = fk.referenced_object_id
                            ) a
                        ) existingfks on nonpkcolumns.TableName = existingfks.ChildTableName and nonpkcolumns.ColumnName  = existingfks.ParentColumnName
                        where existingfks.ParentTableName is null
                        order by TableName, ColumnName";
            var result = ExecAdHocSql(sql);
            Approvals.Verify(result.TableToHumanReadableString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureThatForeignKeyNamesMatchNamingStandard()
        {
            const string sql = @"
                    declare @maxNameLength int
                    set @maxNameLength = 128

                    if object_id('tempdb.dbo.#IdealConstraintName') is not null drop table #IdealConstraintName


                    select b.ParentTableName,
                            b.ChildTableName,
                            b.ConstraintName,
                            b.IdealNewConstraintName,
                            SUBSTRING(b.IdealNewConstraintName, 1,  @maxNameLength) as TruncatedConstraintName,     
                            -- We are attempting to work around collisions in names once truncated. This is a decent solution for the present time, but it will
                            -- break down potentially. We don't expect this to happen, but the real solution should be done in C# anyhow.
                            ROW_NUMBER() over (partition by SUBSTRING(b.IdealNewConstraintName, 1,  @maxNameLength) order by b.IdealNewConstraintName ASC) as TruncatedRank,
                            COUNT(IdealNewConstraintName) over (partition by SUBSTRING(b.IdealNewConstraintName, 1,  @maxNameLength))  as TruncatedRankCount
                    into #IdealConstraintName
                    from
                    (        
                        select a.ParentTableName, 
                                a.ChildTableName, 
                                a.ConstraintName,
                                'FK_' + a.ChildTableName + '_' + a.ParentTableName + case when a.ParentColumns = a.ChildColumns then a.ParentColumns else a.ParentColumns + a.ChildColumns end as IdealNewConstraintName
                        from
                        (
                            select  rt.name as ParentTableName, pt.name as ChildTableName, fk.name as ConstraintName,
                                    (         
                                        SELECT  '_' + pc.name AS [text()]
                                        from sys.foreign_key_columns fkcparent
                                        join sys.columns			 pc		on pc.object_id = fkcparent.parent_object_id and pc.column_id = fkcparent.parent_column_id
                                        WHERE   fkcparent.constraint_object_id = fk.object_id
                                        ORDER BY fkcparent.constraint_column_id
                                        FOR XML PATH(''), TYPE
                                    ).value('/', 'NVARCHAR(MAX)') as ParentColumns,
                                    (         
                                        SELECT  '_' + rc.name AS [text()]
                                        from sys.foreign_key_columns fkcchild
                                        join sys.columns			 rc		on rc.object_id = fkcchild.referenced_object_id and rc.column_id = fkcchild.referenced_column_id
                                        WHERE   fkcchild.constraint_object_id = fk.object_id
                                        ORDER BY fkcchild.constraint_column_id
                                        FOR XML PATH(''), TYPE         
                                    ).value('/', 'NVARCHAR(MAX)') as ChildColumns
                            from sys.foreign_keys		 fk
                            join sys.tables				 pt on pt.object_id = fk.parent_object_id
                            join sys.tables				 rt on rt.object_id = fk.referenced_object_id
                        ) as a
                    ) as b

                    select db_name() as DatabaseName, c.ChildTableName as TableName, c.ConstraintName as ConstraintName, c.IdealNewConstraintName,
                           'exec sp_rename ''' + c.ConstraintName + ''', ''' + IdealNewConstraintName + ''', ''OBJECT''' AS QueryToRenameConstraint
                    from
                    (
                        select x.ParentTableName, x.ChildTableName, x.ConstraintName,
                                case 
                                    when x.TruncatedRankCount = 1 then x.TruncatedConstraintName
                                    else substring(x.TruncatedConstraintName, 1, @maxNameLength - datalength(cast(x.TruncatedRank as varchar(25)))) + cast(x.TruncatedRank as varchar(25))
                                end as IdealNewConstraintName
                        from #IdealConstraintName x
                    ) as c
                    where c.ConstraintName != c.IdealNewConstraintName
                    order by c.ParentTableName, c.ChildTableName, IdealNewConstraintName
                ";
            var result = ExecAdHocSql(sql);
            Approvals.Verify(result.TableToHumanReadableString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureThatPrimaryKeyColumnMatchNamingStandard()
        {
            const string sql = @"
                select a.TableName, a.PrimaryKeyName, 'exec sp_rename ''' + a.TableName + '.' + a.PrimaryKeyName + ''', ''' + NewPrimaryKeyName + '''' AS QueryToRenameConstraint
                from
                (
                    SELECT	t.TABLE_NAME as TableName, 
                            substring(                            (         
                                SELECT  cols.COLUMN_NAME AS [text()]       
                                from INFORMATION_SCHEMA.KEY_COLUMN_USAGE cols
                                WHERE   cols.CONSTRAINT_NAME = c.CONSTRAINT_NAME
                                ORDER BY cols.ORDINAL_POSITION   
                                FOR XML PATH(''), TYPE         
                                ).value('/', 'NVARCHAR(MAX)'), 1, 128) as PrimaryKeyName,
                                t.TABLE_NAME + 'ID' as NewPrimaryKeyName
                    from INFORMATION_SCHEMA.TABLES t 
                    join INFORMATION_SCHEMA.TABLE_CONSTRAINTS c on t.TABLE_NAME = c.TABLE_NAME
                                                                and c.CONSTRAINT_TYPE in ('primary key')
                    where t.TABLE_TYPE = 'BASE TABLE'
                    and t.TABLE_NAME not in ('sysdiagrams', 'DatabaseMigration')
                ) a 
                where a.PrimaryKeyName != a.NewPrimaryKeyName
                order by a.TableName, a.PrimaryKeyName";
            var result = ExecAdHocSql(sql);
            Approvals.Verify(result.TableToHumanReadableString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureThatPrimaryAndAlternateKeyNamesMatchNamingStandard()
        {
            const string sql = @"
                select a.TableName, a.ConstraintName, 'exec sp_rename ''' + a.ConstraintName + ''', ''' + NewConstraintName + ''', ''OBJECT''' AS QueryToRenameConstraint
                from
                (
                    SELECT	t.TABLE_NAME as TableName, c.CONSTRAINT_NAME as ConstraintName
                            , substring(case when c.CONSTRAINT_TYPE = 'unique' then 'AK' else 'PK' end + '_' + c.TABLE_NAME + 
                            (         
                                SELECT  '_' + cols.COLUMN_NAME AS [text()]       
                                from INFORMATION_SCHEMA.KEY_COLUMN_USAGE cols
                                WHERE   cols.CONSTRAINT_NAME = c.CONSTRAINT_NAME
                                ORDER BY cols.ORDINAL_POSITION   
                                FOR XML PATH(''), TYPE         
                                ).value('/', 'NVARCHAR(MAX)'), 1, 128) as NewConstraintName
                    from INFORMATION_SCHEMA.TABLES t 
                    join INFORMATION_SCHEMA.TABLE_CONSTRAINTS c on t.TABLE_NAME = c.TABLE_NAME
                                                                and c.CONSTRAINT_TYPE in ('primary key', 'unique')
                    where t.TABLE_TYPE = 'BASE TABLE'
                    and t.TABLE_NAME not in ('sysdiagrams')
                ) a 
                where a.ConstraintName != a.NewConstraintName
                order by a.TableName, a.ConstraintName";
            var result = ExecAdHocSql(sql);
            Approvals.Verify(result.TableToHumanReadableString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureThatThereAreNoIndexesAlreadyDefinedByPrimaryOrAlternateKey()
        {
            const string sql = @"
                select consts.TableNameFull, consts.ConstraintName, inds.IndexName, 'drop index ' + inds.IndexName + ' on ' + consts.TableNameFull as DropToRun
                from
                (
                    SELECT	t.TABLE_SCHEMA as TableSchema, t.TABLE_NAME as TableName, t.TABLE_SCHEMA + '.' + t.TABLE_NAME as TableNameFull
                            , c.CONSTRAINT_NAME as ConstraintName, 'IX' + RIGHT(c.CONSTRAINT_NAME, len(c.CONSTRAINT_NAME) - 2) as IndexName
                    from INFORMATION_SCHEMA.TABLES t 
                    join INFORMATION_SCHEMA.TABLE_CONSTRAINTS c on t.TABLE_NAME = c.TABLE_NAME
                                                                and c.CONSTRAINT_TYPE in ('unique', 'primary')
                    where t.TABLE_TYPE = 'BASE TABLE'
                ) consts
                join
                (
                    select ind.name as IndexName
                    from sys.indexes ind
                    join sys.tables t on ind.object_id = t.object_id
                    where ind.is_primary_key = 0 
                    and ind.is_unique = 0 
                    and ind.is_unique_constraint = 0
                    and t.is_ms_shipped = 0
                    and ind.type_desc != 'heap'                        
                ) inds on consts.IndexName = inds.IndexName";
            Approvals.Verify(ExecAdHocSql(sql).TableToHumanReadableString());
        }

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
    }
}