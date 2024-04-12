SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirmaHomePageImage](
	[FirmaHomePageImageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FileResourceInfoID] [int] NOT NULL,
	[Caption] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_FirmaHomePageImage_FirmaHomePageImageID] PRIMARY KEY CLUSTERED 
(
	[FirmaHomePageImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FirmaHomePageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaHomePageImage_FileResourceInfo_FileResourceInfoID] FOREIGN KEY([FileResourceInfoID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID])
GO
ALTER TABLE [dbo].[FirmaHomePageImage] CHECK CONSTRAINT [FK_FirmaHomePageImage_FileResourceInfo_FileResourceInfoID]
GO
ALTER TABLE [dbo].[FirmaHomePageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaHomePageImage_FileResourceInfo_FileResourceInfoID_TenantID] FOREIGN KEY([FileResourceInfoID], [TenantID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID], [TenantID])
GO
ALTER TABLE [dbo].[FirmaHomePageImage] CHECK CONSTRAINT [FK_FirmaHomePageImage_FileResourceInfo_FileResourceInfoID_TenantID]
GO
ALTER TABLE [dbo].[FirmaHomePageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaHomePageImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FirmaHomePageImage] CHECK CONSTRAINT [FK_FirmaHomePageImage_Tenant_TenantID]