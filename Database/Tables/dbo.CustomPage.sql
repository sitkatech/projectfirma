SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomPage](
	[CustomPageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[CustomPageDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CustomPageVanityUrl] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CustomPageContent] [dbo].[html] NULL,
	[DocumentLibraryID] [int] NULL,
	[FirmaMenuItemID] [int] NOT NULL,
 CONSTRAINT [PK_CustomPage_CustomPageID] PRIMARY KEY CLUSTERED 
(
	[CustomPageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CustomPage_CustomPageDisplayName_TenantID] UNIQUE NONCLUSTERED 
(
	[CustomPageDisplayName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CustomPage_CustomPageID_TenantID] UNIQUE NONCLUSTERED 
(
	[CustomPageID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CustomPage_CustomPageVanityUrl_TenantID] UNIQUE NONCLUSTERED 
(
	[CustomPageVanityUrl] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[CustomPage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPage_DocumentLibrary_DocumentLibraryID] FOREIGN KEY([DocumentLibraryID])
REFERENCES [dbo].[DocumentLibrary] ([DocumentLibraryID])
GO
ALTER TABLE [dbo].[CustomPage] CHECK CONSTRAINT [FK_CustomPage_DocumentLibrary_DocumentLibraryID]
GO
ALTER TABLE [dbo].[CustomPage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPage_DocumentLibrary_DocumentLibraryID_TenantID] FOREIGN KEY([DocumentLibraryID], [TenantID])
REFERENCES [dbo].[DocumentLibrary] ([DocumentLibraryID], [TenantID])
GO
ALTER TABLE [dbo].[CustomPage] CHECK CONSTRAINT [FK_CustomPage_DocumentLibrary_DocumentLibraryID_TenantID]
GO
ALTER TABLE [dbo].[CustomPage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPage_FirmaMenuItem_FirmaMenuItemID] FOREIGN KEY([FirmaMenuItemID])
REFERENCES [dbo].[FirmaMenuItem] ([FirmaMenuItemID])
GO
ALTER TABLE [dbo].[CustomPage] CHECK CONSTRAINT [FK_CustomPage_FirmaMenuItem_FirmaMenuItemID]
GO
ALTER TABLE [dbo].[CustomPage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[CustomPage] CHECK CONSTRAINT [FK_CustomPage_Tenant_TenantID]