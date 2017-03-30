SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDefinitionDataImage](
	[FieldDefinitionDataImageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FieldDefinitionDataID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_FieldDefinitionDataImage_FieldDefinitionDataImageID] PRIMARY KEY CLUSTERED 
(
	[FieldDefinitionDataImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FieldDefinitionDataImage]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionDataImage_FieldDefinitionData_FieldDefinitionDataID] FOREIGN KEY([FieldDefinitionDataID])
REFERENCES [dbo].[FieldDefinitionData] ([FieldDefinitionDataID])
GO
ALTER TABLE [dbo].[FieldDefinitionDataImage] CHECK CONSTRAINT [FK_FieldDefinitionDataImage_FieldDefinitionData_FieldDefinitionDataID]
GO
ALTER TABLE [dbo].[FieldDefinitionDataImage]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionDataImage_FieldDefinitionData_FieldDefinitionDataID_TenantID] FOREIGN KEY([FieldDefinitionDataID], [TenantID])
REFERENCES [dbo].[FieldDefinitionData] ([FieldDefinitionDataID], [TenantID])
GO
ALTER TABLE [dbo].[FieldDefinitionDataImage] CHECK CONSTRAINT [FK_FieldDefinitionDataImage_FieldDefinitionData_FieldDefinitionDataID_TenantID]
GO
ALTER TABLE [dbo].[FieldDefinitionDataImage]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionDataImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[FieldDefinitionDataImage] CHECK CONSTRAINT [FK_FieldDefinitionDataImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[FieldDefinitionDataImage]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionDataImage_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[FieldDefinitionDataImage] CHECK CONSTRAINT [FK_FieldDefinitionDataImage_FileResource_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[FieldDefinitionDataImage]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionDataImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FieldDefinitionDataImage] CHECK CONSTRAINT [FK_FieldDefinitionDataImage_Tenant_TenantID]