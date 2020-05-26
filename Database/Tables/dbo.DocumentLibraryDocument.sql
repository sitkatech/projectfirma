SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentLibraryDocument](
	[DocumentLibraryDocumentID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[DocumentLibraryID] [int] NOT NULL,
	[DocumentCategoryID] [int] NOT NULL,
	[DocumentTitle] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DocumentDescription] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FileResourceInfoID] [int] NOT NULL,
	[SortOrder] [int] NULL,
	[LastUpdateDate] [datetime] NOT NULL,
	[LastUpdatePersonID] [int] NOT NULL,
 CONSTRAINT [PK_DocumentLibraryDocument_DocumentLibraryDocumentID] PRIMARY KEY CLUSTERED 
(
	[DocumentLibraryDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_DocumentLibraryDocument_DocumentLibraryDocumentID_TenantID] UNIQUE NONCLUSTERED 
(
	[DocumentLibraryDocumentID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DocumentLibraryDocument]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocument_DocumentCategory_DocumentCategoryID] FOREIGN KEY([DocumentCategoryID])
REFERENCES [dbo].[DocumentCategory] ([DocumentCategoryID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocument] CHECK CONSTRAINT [FK_DocumentLibraryDocument_DocumentCategory_DocumentCategoryID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocument]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocument_DocumentLibrary_DocumentLibraryID] FOREIGN KEY([DocumentLibraryID])
REFERENCES [dbo].[DocumentLibrary] ([DocumentLibraryID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocument] CHECK CONSTRAINT [FK_DocumentLibraryDocument_DocumentLibrary_DocumentLibraryID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocument]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocument_DocumentLibrary_DocumentLibraryID_TenantID] FOREIGN KEY([DocumentLibraryID], [TenantID])
REFERENCES [dbo].[DocumentLibrary] ([DocumentLibraryID], [TenantID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocument] CHECK CONSTRAINT [FK_DocumentLibraryDocument_DocumentLibrary_DocumentLibraryID_TenantID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocument]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocument_FileResourceInfo_FileResourceInfoID] FOREIGN KEY([FileResourceInfoID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocument] CHECK CONSTRAINT [FK_DocumentLibraryDocument_FileResourceInfo_FileResourceInfoID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocument]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocument_FileResourceInfo_FileResourceInfoID_TenantID] FOREIGN KEY([FileResourceInfoID], [TenantID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID], [TenantID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocument] CHECK CONSTRAINT [FK_DocumentLibraryDocument_FileResourceInfo_FileResourceInfoID_TenantID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocument]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocument_Person_LastUpdatePersonID_PersonID] FOREIGN KEY([LastUpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocument] CHECK CONSTRAINT [FK_DocumentLibraryDocument_Person_LastUpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocument]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocument_Person_LastUpdatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([LastUpdatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocument] CHECK CONSTRAINT [FK_DocumentLibraryDocument_Person_LastUpdatePersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocument]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocument_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocument] CHECK CONSTRAINT [FK_DocumentLibraryDocument_Tenant_TenantID]