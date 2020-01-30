SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttributeTypeRole](
	[ProjectCustomAttributeTypeRoleID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectCustomAttributeTypeID] [int] NOT NULL,
	[RoleID] [int] NULL,
	[ProjectCustomAttributeTypeRolePermissionTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeTypeRoleID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeTypeRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID] FOREIGN KEY([ProjectCustomAttributeTypeID])
REFERENCES [dbo].[ProjectCustomAttributeType] ([ProjectCustomAttributeTypeID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole] CHECK CONSTRAINT [FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID] FOREIGN KEY([ProjectCustomAttributeTypeID], [TenantID])
REFERENCES [dbo].[ProjectCustomAttributeType] ([ProjectCustomAttributeTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole] CHECK CONSTRAINT [FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeTypeRolePermissionType_ProjectCustomAttributeTypeRolePermissionTypeID] FOREIGN KEY([ProjectCustomAttributeTypeRolePermissionTypeID])
REFERENCES [dbo].[ProjectCustomAttributeTypeRolePermissionType] ([ProjectCustomAttributeTypeRolePermissionTypeID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole] CHECK CONSTRAINT [FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeTypeRolePermissionType_ProjectCustomAttributeTypeRolePermissionTypeID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeTypeRole_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole] CHECK CONSTRAINT [FK_ProjectCustomAttributeTypeRole_Role_RoleID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeTypeRole_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeTypeRole] CHECK CONSTRAINT [FK_ProjectCustomAttributeTypeRole_Tenant_TenantID]