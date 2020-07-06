SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationImage](
	[OrganizationImageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[FileResourceInfoID] [int] NOT NULL,
 CONSTRAINT [PK_OrganizationImage_OrganizationImageID] PRIMARY KEY CLUSTERED 
(
	[OrganizationImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_OrganizationImage_OrganizationImageID_FileResourceInfoID] UNIQUE NONCLUSTERED 
(
	[OrganizationImageID] ASC,
	[FileResourceInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrganizationImage]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationImage_FileResourceInfo_FileResourceInfoID] FOREIGN KEY([FileResourceInfoID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID])
GO
ALTER TABLE [dbo].[OrganizationImage] CHECK CONSTRAINT [FK_OrganizationImage_FileResourceInfo_FileResourceInfoID]
GO
ALTER TABLE [dbo].[OrganizationImage]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationImage_FileResourceInfo_FileResourceInfoID_TenantID] FOREIGN KEY([FileResourceInfoID], [TenantID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID], [TenantID])
GO
ALTER TABLE [dbo].[OrganizationImage] CHECK CONSTRAINT [FK_OrganizationImage_FileResourceInfo_FileResourceInfoID_TenantID]
GO
ALTER TABLE [dbo].[OrganizationImage]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationImage_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[OrganizationImage] CHECK CONSTRAINT [FK_OrganizationImage_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[OrganizationImage]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationImage_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[OrganizationImage] CHECK CONSTRAINT [FK_OrganizationImage_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[OrganizationImage]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[OrganizationImage] CHECK CONSTRAINT [FK_OrganizationImage_Tenant_TenantID]