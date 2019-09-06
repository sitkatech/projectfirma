SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAttachment](
	[ProjectAttachmentID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[AttachmentID] [int] NOT NULL,
	[AttachmentRelationshipTypeID] [int] NOT NULL,
	[DisplayName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ProjectAttachment_ProjectAttachmentID] PRIMARY KEY CLUSTERED 
(
	[ProjectAttachmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectAttachment_ProjectAttachmentID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectAttachmentID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID] FOREIGN KEY([AttachmentRelationshipTypeID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID])
GO
ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID]
GO
ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID] FOREIGN KEY([AttachmentRelationshipTypeID], [TenantID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_FileResource_AttachmentID_FileResourceID] FOREIGN KEY([AttachmentID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_FileResource_AttachmentID_FileResourceID]
GO
ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_FileResource_AttachmentID_TenantID_FileResourceID_TenantID] FOREIGN KEY([AttachmentID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_FileResource_AttachmentID_TenantID_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_Tenant_TenantID]