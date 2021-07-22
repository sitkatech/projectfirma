SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastSQLServerDatabaseBackup](
	[LastSQLServerDatabaseBackupID] [int] IDENTITY(1,1) NOT NULL,
	[BackupName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ServerName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DatabaseName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DatabaseVersion] [int] NULL,
	[DatabaseCreationDate] [datetime] NULL,
	[BackupSize] [numeric](20, 0) NULL,
	[BackupStartDate] [datetime] NULL,
	[BackupFinishDate] [datetime] NULL,
	[MachineName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Collation] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CompressedBackupSize] [bigint] NULL,
 CONSTRAINT [PK_LastSQLServerDatabaseBackup_LastSQLServerDatabaseBackupID] PRIMARY KEY NONCLUSTERED 
(
	[LastSQLServerDatabaseBackupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
