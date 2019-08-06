SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachmentRelationshipTypeFileResourceMimeType](
	[AttachmentRelationshipTypeFileResourceMimeTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[AttachmentRelationshipTypeID] [int] NOT NULL,
	[FileResourceMimeTypeID] [int] NOT NULL,
 CONSTRAINT [PK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipTypeFileResourceMimeTypeID] PRIMARY KEY CLUSTERED 
(
	[AttachmentRelationshipTypeFileResourceMimeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeFileResourceMimeType]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipType_AttachmentRelationshipTypeID] FOREIGN KEY([AttachmentRelationshipTypeID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeFileResourceMimeType] CHECK CONSTRAINT [FK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipType_AttachmentRelationshipTypeID]
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeFileResourceMimeType]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID] FOREIGN KEY([AttachmentRelationshipTypeID], [TenantID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID], [TenantID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeFileResourceMimeType] CHECK CONSTRAINT [FK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID]
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeFileResourceMimeType]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipTypeFileResourceMimeType_FileResourceMimeType_FileResourceMimeTypeID] FOREIGN KEY([FileResourceMimeTypeID])
REFERENCES [dbo].[FileResourceMimeType] ([FileResourceMimeTypeID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeFileResourceMimeType] CHECK CONSTRAINT [FK_AttachmentRelationshipTypeFileResourceMimeType_FileResourceMimeType_FileResourceMimeTypeID]
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeFileResourceMimeType]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipTypeFileResourceMimeType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeFileResourceMimeType] CHECK CONSTRAINT [FK_AttachmentRelationshipTypeFileResourceMimeType_Tenant_TenantID]