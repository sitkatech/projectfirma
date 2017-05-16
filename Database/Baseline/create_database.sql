
use [master]
go

IF EXISTS( SELECT * FROM [master].[dbo].[sysdatabases] sdt WHERE sdt.[name] = '${db-name}' )
BEGIN
	IF ( ${db-overwrite} = 1 )
	BEGIN
		alter database ${db-name} set single_user with rollback immediate
		DROP DATABASE [${db-name}]
	END
	ELSE
	BEGIN
		RAISERROR( 'Database ''${db-name}'' exists on ''${db-server-ds}'' and the OverwriteDatabase property is false.' , 18 , 1 )
	END
END
GO

CREATE DATABASE [${db-name}]  ON (NAME = N'${db-name}', FILENAME = N'${data-file-path}' , SIZE = ${data-file-size}, FILEGROWTH = 10%) LOG ON (NAME = N'${db-name}_Log', FILENAME = N'${log-file-path}' , SIZE = ${log-file-size}, FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

use [${db-name}]
GO

exec sp_changedbowner 'sa'
GO

alter database [${db-name}] 
    set AUTO_CLOSE off,
    TORN_PAGE_DETECTION on,
    RECOVERY full,
    READ_WRITE,
    MULTI_USER,
    AUTO_SHRINK off,
    ANSI_null_default off,
    recursive_triggers off,
    ansi_nulls off,
    concat_null_yields_null off,
    cursor_close_on_commit off,
    cursor_default global,
    quoted_identifier off,
    ANSI_warnings off,
    auto_create_statistics on,
    auto_update_statistics on,    
    DB_CHAINING off
        
--exec sp_dboption N'${db-name}', N'autoclose', N'false'
--GO

-- RECOVERY full
--exec sp_dboption N'${db-name}', N'bulkcopy', N'false'
--GO

-- covered by  RECOVERY full
--exec sp_dboption N'${db-name}', N'trunc. log', N'false'
--GO

--exec sp_dboption N'${db-name}', N'torn page detection', N'true'
--GO

-- READ_WRITE
--exec sp_dboption N'${db-name}', N'read only', N'false'
--GO

-- MULTI_USER
--exec sp_dboption N'${db-name}', N'dbo use', N'false'
--GO

-- MULTI_USER
--exec sp_dboption N'${db-name}', N'single', N'false'
--GO

--exec sp_dboption N'${db-name}', N'autoshrink', N'false'
--GO

--exec sp_dboption N'${db-name}', N'ANSI null default', N'false'
--GO

--exec sp_dboption N'${db-name}', N'recursive triggers', N'false'
--GO

--exec sp_dboption N'${db-name}', N'ANSI nulls', N'false'
--GO

--exec sp_dboption N'${db-name}', N'concat null yields null', N'false'
--GO

--exec sp_dboption N'${db-name}', N'cursor close on commit', N'false'
--GO

--exec sp_dboption N'${db-name}', N'default to local cursor', N'false'
--GO

--exec sp_dboption N'${db-name}', N'quoted identifier', N'false'
--GO

--exec sp_dboption N'${db-name}', N'ANSI warnings', N'false'
--GO

--exec sp_dboption N'${db-name}', N'auto create statistics', N'true'
--GO

--exec sp_dboption N'${db-name}', N'auto update statistics', N'true'
--GO

--if( ( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) ) or ( (@@microsoftversion / power(2, 24) = 7) and (@@microsoftversion & 0xffff >= 1082) ) )
--	exec sp_dboption N'${db-name}', N'db chaining', N'false'
--GO

use master
