

CREATE TABLE [dbo].[ProjectInternalNote](
	[ProjectInternalNoteID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Note] [varchar](8000) NOT NULL,
	[CreatePersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ProjectInternalNote_ProjectInternalNoteID] PRIMARY KEY CLUSTERED 
(
	[ProjectInternalNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectInternalNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[ProjectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectInternalNote_Person_CreatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([CreatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectInternalNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[ProjectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectInternalNote_Person_UpdatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([UpdatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO


ALTER TABLE [dbo].[ProjectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectInternalNote_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO

ALTER TABLE [dbo].[ProjectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectInternalNote_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO


ALTER TABLE [dbo].[ProjectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectInternalNote_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

Insert into dbo.FieldDefinition
values
(268, N'ProjectInternalNote', N'Internal Note', N'<p>Any important information about a project that should only be visible to Administrators.</p>')

Insert into dbo.FieldDefinitionData([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
select 
TenantID,
268,
Null,
Null
from tenant