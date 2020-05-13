SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentLibrary](
	[DocumentLibraryID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[DocumentLibraryName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DocumentLibraryDescription] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DocumentLibrary_DocumentLibraryID] PRIMARY KEY CLUSTERED 
(
	[DocumentLibraryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DocumentLibrary]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibrary_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[DocumentLibrary] CHECK CONSTRAINT [FK_DocumentLibrary_Tenant_TenantID]