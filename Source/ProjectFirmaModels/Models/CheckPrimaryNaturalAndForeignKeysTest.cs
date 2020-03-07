/*-----------------------------------------------------------------------
<copyright file="CheckPrimaryNaturalAndForeignKeysTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using ProjectFirmaModels.UnitTestCommon;

namespace ProjectFirmaModels.Models
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
                            select
                            c.TABLE_SCHEMA as TableSchema,
                            c.TABLE_NAME as TableName, 
                            c.COLUMN_NAME as ColumnName
                            from INFORMATION_SCHEMA.COLUMNS as c
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
                        order by TableSchema, TableName, ColumnName";
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

                    select  b.ParentSchemaName,
                            b.ParentTableName,
                            b.ChildSchemaName,
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
                        select  a.ParentSchemaName,
                                a.ParentTableName,
                                a.ChildSchemaName,
                                a.ChildTableName,
                                a.ConstraintName,
                                'FK_' + a.ChildTableName + '_' + a.ParentTableName + case when a.ParentColumns = a.ChildColumns then a.ParentColumns else a.ParentColumns + a.ChildColumns end as IdealNewConstraintName
                        from
                        (
                            select
                                   rsc.name as ParentSchemaName,
                                   rt.name as ParentTableName,
                                   psc.name as ChildSchemaName,
                                   pt.name as ChildTableName,
                                   fk.name as ConstraintName,
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
                            from sys.foreign_keys        fk
                            join sys.tables              pt on pt.object_id = fk.parent_object_id
                            join sys.tables              rt on rt.object_id = fk.referenced_object_id
                            join sys.schemas             psc on psc.schema_id = pt.schema_id
                            join sys.schemas             rsc on rsc.schema_id = rt.schema_id
                        ) as a
                    ) as b

                    select db_name() as DatabaseName,
                           c.ChildSchemaName as SchemaName,
                           c.ChildTableName as TableName,
                           c.ConstraintName as ConstraintName,
                           c.IdealNewConstraintName,
                           'exec sp_rename ''' + c.ChildSchemaName + '.' + c.ConstraintName + ''', ''' + IdealNewConstraintName + ''', ''OBJECT''' AS QueryToRenameConstraint
                    from
                    (
                        select x.ParentSchemaName, x.ParentTableName, x.ChildSchemaName, x.ChildTableName, x.ConstraintName,
                                case 
                                    when x.TruncatedRankCount = 1 then x.TruncatedConstraintName
                                    else substring(x.TruncatedConstraintName, 1, @maxNameLength - datalength(cast(x.TruncatedRank as varchar(25)))) + cast(x.TruncatedRank as varchar(25))
                                end as IdealNewConstraintName
                        from #IdealConstraintName x
                    ) as c
                    where c.ConstraintName != c.IdealNewConstraintName
                    order by c.ParentSchemaName, c.ParentTableName, c.ChildSchemaName, c.ChildTableName, IdealNewConstraintName
             ";
            var result = ExecAdHocSql(sql);
            Approvals.Verify(result.TableToHumanReadableString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureThatPrimaryKeyColumnMatchNamingStandard()
        {
            const string sql = @"
                select a.SchemaName, a.TableName, a.PrimaryKeyName, 'exec sp_rename ''' + a.SchemaName + '.' + a.TableName + '.' + a.PrimaryKeyName + ''', ''' + NewPrimaryKeyName + '''' AS QueryToRenameConstraint
                from
                (
                    SELECT
                            t.TABLE_SCHEMA as SchemaName,
                            t.TABLE_NAME as TableName,
                            substring( (
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
                order by a.SchemaName, a.TableName, a.PrimaryKeyName";
            var result = ExecAdHocSql(sql);
            Approvals.Verify(result.TableToHumanReadableString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureThatPrimaryAndAlternateKeyNamesMatchNamingStandard()
        {
            const string sql = @"
                select a.TableName, a.ConstraintName, 'exec sp_rename ''' + a.TableSchema + '.' + a.ConstraintName + ''', ''' + NewConstraintName + ''', ''OBJECT''' AS QueryToRenameConstraint
                from
                (
                    SELECT	t.TABLE_NAME as TableName, c.CONSTRAINT_NAME as ConstraintName, t.TABLE_SCHEMA as TableSchema
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

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureThatEveryChildTableHasADualForeignKeyWithTenantID()
        {
            const string sql = @"
if object_id('tempdb.dbo.#SingleColumnKeyConstraints') is not null drop table #SingleColumnKeyConstraints
select tc.table_schema, tc.table_name, tc.constraint_schema, tc.constraint_name, tc.constraint_type
into #SingleColumnKeyConstraints
from information_schema.key_column_usage kcu
     join information_schema.table_constraints tc on kcu.constraint_schema = tc.constraint_schema and kcu.constraint_name = tc.constraint_name
group by tc.table_schema, tc.table_name, tc.constraint_schema, tc.constraint_name, tc.constraint_type
having count(*) = 1

if object_id('tempdb.dbo.#fk') is not null drop table #fk;
select  kcu.table_schema, kcu.table_name, kcu.column_name,  ftc.constraint_schema as foreign_table_schema, ftc.table_name as foreign_table_name, fccu.COLUMN_NAME as foreign_column_name
into #fk
from information_schema.key_column_usage kcu
     join #SingleColumnKeyConstraints pk on kcu.constraint_schema = pk.constraint_schema and kcu.constraint_name = pk.constraint_name
     join information_schema.referential_constraints rc on kcu.constraint_schema = rc.constraint_schema  and kcu.constraint_name = rc.constraint_name
     join information_schema.table_constraints ftc on rc.unique_constraint_schema = ftc.CONSTRAINT_SCHEMA and rc.unique_constraint_name = ftc.constraint_name
     join information_schema.CONSTRAINT_COLUMN_USAGE fccu on ftc.CONSTRAINT_SCHEMA = fccu.CONSTRAINT_SCHEMA and ftc.constraint_name = fccu.CONSTRAINT_NAME
where pk.CONSTRAINT_TYPE = 'FOREIGN KEY'

if object_id('tempdb.dbo.#tenantIDTables') is not null drop table #tenantIDTables;
select t.table_schema,
    t.table_name,
    c.column_name,
    c.Data_type
into #tenantIDTables
from information_schema.columns c
     join information_schema.tables t on c.table_schema = t.table_schema and c.table_name = t.table_name
     join #fk on c.table_schema = #fk.table_schema and c.table_name = #fk.table_name and #fk.COLUMN_NAME = 'TenantID'
where t.table_type = 'BASE TABLE'
AND OBJECTPROPERTY(OBJECT_ID( QUOTENAME(t.TABLE_SCHEMA) + N'.' + QUOTENAME(t.TABLE_NAME)), 'IsMSShipped') = 0 --Filter out Microsoft tables like sysdiagrams
and t.table_name not in ('geometry_columns', 'spatial_ref_sys', 'sysdiagrams')
order by t.table_schema, t.table_name, c.ordinal_position

select 
    rts.name as ParentTableSchemaName,
    rt.name as ParentTableName,
    rc.Name ParentKeyColumnName,
    pts.name as ChildTableSchemaName,
    pt.Name ChildTableName,
    pc.Name ChildKeyColumnName,
    pc.is_nullable as ChildKeyColumnIsNullable,
    ttdk.KeyName,
    concat('alter table ', pts.name, '.', pt.name, ' add constraint FK_', pt.name, '_', rt.name, '_', pc.name + '_TenantID foreign key (', pc.name, ', TenantID) references ', rts.name, '.', rt.name, '(', rc.name, ', TenantID)') as ForeignKeySql
from sys.foreign_keys		 fk
join sys.tables				 pt		on pt.object_id = fk.parent_object_id
join sys.schemas             pts    on pt.schema_id = pts.schema_id
join sys.tables				 rt		on rt.object_id = fk.referenced_object_id
join sys.schemas             rts    on rt.schema_id = rts.schema_id
join sys.foreign_key_columns fkc	on fkc.constraint_object_id = fk.object_id
join sys.columns			 rc		on rc.object_id = fkc.referenced_object_id and rc.column_id = fkc.referenced_column_id
join sys.columns			 pc		on pc.object_id = fkc.parent_object_id and pc.column_id = fkc.parent_column_id--
join
(
    -- Only do this for single-column foreign keys
    select constraint_object_id
    from sys.foreign_key_columns
    group by constraint_object_id
    having COUNT(*) = 1
) SingleColumnKey on SingleColumnKey.constraint_object_id = fk.object_id
join #tenantIDTables tt on rts.name = tt.TABLE_SCHEMA and rt.name = tt.TABLE_NAME and rc.name = tt.COLUMN_NAME
left join
(
    select 
        rts.name as ParentTableSchemaName,
        rt.name as ParentTableName,
        rc.Name ParentKeyColumnName,
        pts.name as ChildTableSchemaName,
        pt.Name ChildTableName,
        pc.Name ChildKeyColumnName,
        pc.is_nullable as ChildKeyColumnIsNullable,
        fk.name as KeyName
    from sys.foreign_keys		 fk
    join sys.tables				 pt		on pt.object_id = fk.parent_object_id
    join sys.schemas             pts    on pt.schema_id = pts.schema_id
    join sys.tables				 rt		on rt.object_id = fk.referenced_object_id
    join sys.schemas             rts    on rt.schema_id = rts.schema_id
    join sys.foreign_key_columns fkc on fkc.constraint_object_id = fk.object_id
    join sys.columns			 rc		on rc.object_id = fkc.referenced_object_id and rc.column_id = fkc.referenced_column_id
    join sys.columns			 pc		on pc.object_id = fkc.parent_object_id and pc.column_id = fkc.parent_column_id
    join
    (
        select fkc.constraint_object_id
        from sys.foreign_key_columns fkc
        join sys.columns			 rc		on rc.object_id = fkc.referenced_object_id and rc.column_id = fkc.referenced_column_id
        join
        (
            select fkc.constraint_object_id
            from sys.foreign_key_columns fkc
            join sys.columns			 rc		on rc.object_id = fkc.referenced_object_id and rc.column_id = fkc.referenced_column_id
            join sys.columns			 pc		on pc.object_id = fkc.parent_object_id and pc.column_id = fkc.parent_column_id
            group by constraint_object_id
            having COUNT(*) = 2
        ) doublefks on fkc.constraint_object_id = doublefks.constraint_object_id
        where rc.name = 'TenantID'
    ) fkswithTenantID on fkc.constraint_object_id = fkswithTenantID.constraint_object_id
    where rc.name != 'TenantID'
) ttdk on pts.name = ttdk.ChildTableSchemaName and pt.name = ttdk.ChildTableName and pc.name = ttdk.ChildKeyColumnName

where rt.name != 'Tenant' and ttdk.KeyName is null
order by pt.Name, rt.name, rc.name, pc.Name";
            Approvals.Verify(ExecAdHocSql(sql).TableToHumanReadableString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AssureThatTenantIDIsAlwaysTheSecondColumn()
        {
            const string sql = @"
select t.table_schema,
    t.table_name,
    c.column_name,
    c.Data_type,
    c.ORDINAL_POSITION
from information_schema.columns c
     join information_schema.tables t on c.table_schema = t.table_schema and c.table_name = t.table_name
where t.table_type = 'BASE TABLE' and c.COLUMN_NAME = 'TenantID'
AND OBJECTPROPERTY(OBJECT_ID( QUOTENAME(t.TABLE_SCHEMA) + N'.' + QUOTENAME(t.TABLE_NAME)), 'IsMSShipped') = 0 --Filter out Microsoft tables like sysdiagrams
and t.table_name not in ('geometry_columns', 'spatial_ref_sys', 'sysdiagrams', 'Tenant')
and c.ORDINAL_POSITION != 2
order by t.table_schema, t.table_name, c.ordinal_position";
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
