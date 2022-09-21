IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pGeospatial_SpatialIndexCreate'))
    drop procedure dbo.pGeospatial_SpatialIndexCreate
go
create procedure dbo.pGeospatial_SpatialIndexCreate(@applyChanges bit = 0, @databaseNameOptional sysname = null, @tableNameOptional sysname = null, @geometryColumnName sysname = null)
as
begin
	if OBJECT_ID('tempdb.dbo.#tmpIndexesToCreate') is not null drop table #tmpIndexesToCreate
	select c.TABLE_SCHEMA, c.TABLE_NAME, c.COLUMN_NAME into #tmpIndexesToCreate
    from INFORMATION_SCHEMA.COLUMNS c
    where 1 = 0

    declare @databaseName sysname
	set @databaseName = ISNULL(@databaseNameOptional, DB_NAME())

	DECLARE @stmt nvarchar(max)

    SET @stmt = 'USE ' + QUOTENAME(@databaseName) + ';
                 INSERT INTO #tmpIndexesToCreate(TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME)
			     SELECT c.TABLE_SCHEMA, c.TABLE_NAME, c.COLUMN_NAME
                     FROM INFORMATION_SCHEMA.COLUMNS c
                     JOIN INFORMATION_SCHEMA.TABLES t
                         ON c.TABLE_CATALOG = t.TABLE_CATALOG AND
                            c.TABLE_SCHEMA = t.TABLE_SCHEMA AND
                            c.TABLE_NAME = t.TABLE_NAME
	             WHERE c.DATA_TYPE = ''geometry'' AND
                       t.TABLE_TYPE = ''BASE TABLE'' AND
                       (@tableName IS NULL OR c.TABLE_NAME = @tableName) AND
                       (@geometryColumn IS NULL OR c.COLUMN_NAME = @geometryColumn)
                 ORDER BY c.TABLE_SCHEMA, c.TABLE_NAME, c.COLUMN_NAME'

    EXEC sp_executesql @stmt,
         @params=N'@tableName sysname, @geometryColumn sysname',
         @tableName=@tableNameOptional, @geometryColumn=@geometryColumnName
	
	declare @tableSchemaForCreate sysname, @tableNameForCreate sysname, @geometryColumnNameForCreate sysname
	
    -- turn off row counts so print outs are clean
    set nocount on

	while exists(select 1 from #tmpIndexesToCreate)
	begin
		select top 1 @tableSchemaForCreate = TABLE_SCHEMA,
		       @tableNameForCreate = TABLE_NAME,
		       @geometryColumnNameForCreate = COLUMN_NAME
		from #tmpIndexesToCreate
        order by TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME
		
		declare @indexNameForCreate sysname
		set @indexNameForCreate = 'SPATIAL_' + @tableNameForCreate + '_' + @geometryColumnNameForCreate
		
		declare @xMin float(53),
				@yMin float(53),
				@xMax float(53),
				@yMax float(53)

		SET @stmt = 'SELECT @xMinOut = min(GEOMETRYCOLUMN.STEnvelope().STPointN(1).STX),
			            @yMinOut = min(GEOMETRYCOLUMN.STEnvelope().STPointN(1).STY),
			            @xMaxOut = max(GEOMETRYCOLUMN.STEnvelope().STPointN(3).STX),
			            @yMaxOut = max(GEOMETRYCOLUMN.STEnvelope().STPointN(3).STY)
		             FROM ' +  QUOTENAME(@databasename) + '.' +  QUOTENAME(@tableSchemaForCreate) + '.' +  QUOTENAME(@tableNameForCreate) + '
                         WHERE GEOMETRYCOLUMN IS NOT NULL'

		SET @stmt = REPLACE(@stmt, 'GEOMETRYCOLUMN', QUOTENAME(@geometryColumnNameForCreate))

		EXEC sp_executesql @stmt,
		   @params=N'@xMinOut float(53) OUTPUT, 
					 @yMinOut float(53) OUTPUT,
					 @xMaxOut float(53) OUTPUT,
					 @yMaxOut float(53) OUTPUT',
		   @xMinOut = @xMin OUTPUT,
		   @yMinOut = @yMin OUTPUT,
		   @xMaxOut = @xMax OUTPUT,
		   @yMaxOut = @yMax OUTPUT
		   
		declare @xMinFloor float(53),
				@yMinFloor float(53),
				@xMaxCeiling float(53),
				@yMaxCeiling float(53)

        declare @positionToRoundTo float
        set @positionToRoundTo = 1.0
        
        declare @factor float
        set @factor = 1.0 / @positionToRoundTo

		select @xMinFloor = FLOOR(@xMin * @factor)/@factor,
			   @yMinFloor = FLOOR(@yMin * @factor)/@factor,
			   @xMaxCeiling = CEILING(@xMax * @factor)/@factor,
			   @yMaxCeiling = CEILING(@yMax * @factor)/@factor
    
        if(@xMinFloor is not null and @yMinFloor is not null and @xMaxCeiling is not null and @yMaxCeiling is not null)
        begin
		    set @stmt = N'IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = ''' + @indexNameForCreate  + ''')
                          create spatial index ' + QUOTENAME(@indexNameForCreate) + ' on ' +
                          QUOTENAME(@databaseName) + '.' + QUOTENAME(@tableSchemaForCreate) + '.' + QUOTENAME(@tableNameForCreate) + '(' + QUOTENAME(@geometryColumnNameForCreate) + ')' + '
                          with (BOUNDING_BOX=(XMIN, YMIN, XMAX, YMAX))'
		    set @stmt = REPLACE(@stmt, 'XMIN', convert(varchar(100), @xMinFloor))
		    set @stmt = REPLACE(@stmt, 'YMIN', convert(varchar(100), @yMinFloor))
		    set @stmt = REPLACE(@stmt, 'XMAX', convert(varchar(100), @xMaxCeiling))
		    set @stmt = REPLACE(@stmt, 'YMAX', convert(varchar(100), @yMaxCeiling))
		    print @STMT
		    if (@applyChanges = 1) exec sp_executesql @statement = @STMT
        end
        else
        begin
		    set @stmt = N'-- for ' + QUOTENAME(@databaseName) + '.' + QUOTENAME(@tableSchemaForCreate) + '.' + QUOTENAME(@tableNameForCreate) + '.' + QUOTENAME(@geometryColumnNameForCreate) + CHAR(13) + CHAR(10) +
                        N'    -- No rows in table, cannot suggest index bounds: ' + QUOTENAME(@indexNameForCreate)
            print @stmt
        end

		delete from #tmpIndexesToCreate
		where  TABLE_SCHEMA = @tableSchemaForCreate
		       and TABLE_NAME = @tableNameForCreate
		       and COLUMN_NAME = @geometryColumnNameForCreate
	end
	if OBJECT_ID('tempdb.dbo.#tmpIndexesToCreate') is not null drop table #tmpIndexesToCreate
end
go

-- exec dbo.pGeospatial_SpatialIndexCreate
