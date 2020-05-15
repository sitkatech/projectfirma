SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentLibraryDocumentRole](
	[DocumentLibraryDocumentRoleID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[DocumentLibraryDocumentID] [int] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_DocumentLibraryDocumentRole_DocumentLibraryDocumentRoleID] PRIMARY KEY CLUSTERED 
(
	[DocumentLibraryDocumentRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DocumentLibraryDocumentRole]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocumentRole_DocumentLibraryDocument_DocumentLibraryDocumentID] FOREIGN KEY([DocumentLibraryDocumentID])
REFERENCES [dbo].[DocumentLibraryDocument] ([DocumentLibraryDocumentID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentRole] CHECK CONSTRAINT [FK_DocumentLibraryDocumentRole_DocumentLibraryDocument_DocumentLibraryDocumentID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentRole]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocumentRole_DocumentLibraryDocument_DocumentLibraryDocumentID_TenantID] FOREIGN KEY([DocumentLibraryDocumentID], [TenantID])
REFERENCES [dbo].[DocumentLibraryDocument] ([DocumentLibraryDocumentID], [TenantID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentRole] CHECK CONSTRAINT [FK_DocumentLibraryDocumentRole_DocumentLibraryDocument_DocumentLibraryDocumentID_TenantID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentRole]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocumentRole_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentRole] CHECK CONSTRAINT [FK_DocumentLibraryDocumentRole_Role_RoleID]
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentRole]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLibraryDocumentRole_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[DocumentLibraryDocumentRole] CHECK CONSTRAINT [FK_DocumentLibraryDocumentRole_Tenant_TenantID]