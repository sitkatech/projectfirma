SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileResourceInfo](
	[FileResourceInfoID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FileResourceMimeTypeID] [int] NOT NULL,
	[OriginalBaseFilename] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[OriginalFileExtension] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FileResourceGUID] [uniqueidentifier] NOT NULL,
	[CreatePersonID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_FileResourceInfo_FileResourceInfoID] PRIMARY KEY CLUSTERED 
(
	[FileResourceInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FileResourceInfo_FileResourceGUID] UNIQUE NONCLUSTERED 
(
	[FileResourceGUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FileResourceInfo_FileResourceInfoID_TenantID] UNIQUE NONCLUSTERED 
(
	[FileResourceInfoID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FileResourceInfo]  WITH CHECK ADD  CONSTRAINT [FK_FileResourceInfo_FileResourceMimeType_FileResourceMimeTypeID] FOREIGN KEY([FileResourceMimeTypeID])
REFERENCES [dbo].[FileResourceMimeType] ([FileResourceMimeTypeID])
GO
ALTER TABLE [dbo].[FileResourceInfo] CHECK CONSTRAINT [FK_FileResourceInfo_FileResourceMimeType_FileResourceMimeTypeID]
GO
ALTER TABLE [dbo].[FileResourceInfo]  WITH CHECK ADD  CONSTRAINT [FK_FileResourceInfo_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[FileResourceInfo] CHECK CONSTRAINT [FK_FileResourceInfo_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[FileResourceInfo]  WITH CHECK ADD  CONSTRAINT [FK_FileResourceInfo_Person_CreatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([CreatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[FileResourceInfo] CHECK CONSTRAINT [FK_FileResourceInfo_Person_CreatePersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[FileResourceInfo]  WITH CHECK ADD  CONSTRAINT [FK_FileResourceInfo_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FileResourceInfo] CHECK CONSTRAINT [FK_FileResourceInfo_Tenant_TenantID]