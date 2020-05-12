SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentLibraryDocumentCategory](
	[DocumentLibraryDocumentCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentLibraryID] [int] NOT NULL,
	[DocumentCategoryID] [int] NOT NULL,
 CONSTRAINT [PK_DocumentLibraryDocumentCategory_DocumentLibraryDocumentCategoryID] PRIMARY KEY CLUSTERED 
(
	[DocumentLibraryDocumentCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DocumentLibraryDocumentCategory]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocumentCategory_DocumentCategory_DocumentCategoryID] FOREIGN KEY([DocumentCategoryID])
REFERENCES [dbo].[DocumentCategory] ([DocumentCategoryID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentCategory] CHECK CONSTRAINT [FK_DocumentLibraryDocumentCategory_DocumentCategory_DocumentCategoryID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentCategory]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocumentCategory_DocumentLibrary_DocumentLibraryID] FOREIGN KEY([DocumentLibraryID])
REFERENCES [dbo].[DocumentLibrary] ([DocumentLibraryID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentCategory] CHECK CONSTRAINT [FK_DocumentLibraryDocumentCategory_DocumentLibrary_DocumentLibraryID]