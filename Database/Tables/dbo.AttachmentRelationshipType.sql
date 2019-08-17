SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachmentRelationshipType](
	[AttachmentRelationshipTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[AttachmentRelationshipTypeName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AttachmentRelationshipTypeDescription] [varchar](360) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MaxFileSize] [int] NOT NULL,
	[NumberOfAllowedAttachments] [int] NULL,
 CONSTRAINT [PK_AttachmentRelationshipType_AttachmentRelationshipTypeID] PRIMARY KEY CLUSTERED 
(
	[AttachmentRelationshipTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[AttachmentRelationshipTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AttachmentRelationshipType_AttachmentRelationshipTypeName_TenantID] UNIQUE NONCLUSTERED 
(
	[AttachmentRelationshipTypeName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AttachmentRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipType] CHECK CONSTRAINT [FK_AttachmentRelationshipType_Tenant_TenantID]