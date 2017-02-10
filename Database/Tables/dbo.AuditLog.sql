SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLog](
	[AuditLogID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[AuditLogDate] [datetime] NOT NULL,
	[AuditLogEventTypeID] [int] NOT NULL,
	[TableName] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RecordID] [int] NOT NULL,
	[ColumnName] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[OriginalValue] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NewValue] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AuditDescription] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectID] [int] NULL,
	[ProposedProjectID] [int] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_AuditLog_AuditLogID] PRIMARY KEY CLUSTERED 
(
	[AuditLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[AuditLog]  WITH CHECK ADD  CONSTRAINT [FK_AuditLog_AuditLogEventType_AuditLogEventTypeID] FOREIGN KEY([AuditLogEventTypeID])
REFERENCES [dbo].[AuditLogEventType] ([AuditLogEventTypeID])
GO
ALTER TABLE [dbo].[AuditLog] CHECK CONSTRAINT [FK_AuditLog_AuditLogEventType_AuditLogEventTypeID]
GO
ALTER TABLE [dbo].[AuditLog]  WITH CHECK ADD  CONSTRAINT [FK_AuditLog_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[AuditLog] CHECK CONSTRAINT [FK_AuditLog_Person_PersonID]
GO
ALTER TABLE [dbo].[AuditLog]  WITH CHECK ADD  CONSTRAINT [FK_AuditLog_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[AuditLog] CHECK CONSTRAINT [FK_AuditLog_Tenant_TenantID]