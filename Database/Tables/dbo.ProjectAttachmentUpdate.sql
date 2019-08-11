SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAttachmentUpdate](
	[ProjectAttachmentUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[AttachmentID] [int] NOT NULL,
	[AttachmentRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectAttachmentUpdate_ProjectAttachmentUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectAttachmentUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectAttachmentUpdate_ProjectAttachmentUpdateID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectAttachmentUpdateID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID] FOREIGN KEY([AttachmentRelationshipTypeID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID])
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID]
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID] FOREIGN KEY([AttachmentRelationshipTypeID], [TenantID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_FileResource_AttachmentID_FileResourceID] FOREIGN KEY([AttachmentID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_FileResource_AttachmentID_FileResourceID]
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_FileResource_AttachmentID_TenantID_FileResourceID_TenantID] FOREIGN KEY([AttachmentID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_FileResource_AttachmentID_TenantID_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_Tenant_TenantID]