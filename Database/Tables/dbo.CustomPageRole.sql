SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomPageRole](
	[CustomPageRoleID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[CustomPageID] [int] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_CustomPageRole_CustomPageRoleID] PRIMARY KEY CLUSTERED 
(
	[CustomPageRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CustomPageRole]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageRole_CustomPage_CustomPageID] FOREIGN KEY([CustomPageID])
REFERENCES [dbo].[CustomPage] ([CustomPageID])
GO
ALTER TABLE [dbo].[CustomPageRole] CHECK CONSTRAINT [FK_CustomPageRole_CustomPage_CustomPageID]
GO
ALTER TABLE [dbo].[CustomPageRole]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageRole_CustomPage_CustomPageID_TenantID] FOREIGN KEY([CustomPageID], [TenantID])
REFERENCES [dbo].[CustomPage] ([CustomPageID], [TenantID])
GO
ALTER TABLE [dbo].[CustomPageRole] CHECK CONSTRAINT [FK_CustomPageRole_CustomPage_CustomPageID_TenantID]
GO
ALTER TABLE [dbo].[CustomPageRole]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageRole_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[CustomPageRole] CHECK CONSTRAINT [FK_CustomPageRole_Role_RoleID]
GO
ALTER TABLE [dbo].[CustomPageRole]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageRole_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[CustomPageRole] CHECK CONSTRAINT [FK_CustomPageRole_Tenant_TenantID]