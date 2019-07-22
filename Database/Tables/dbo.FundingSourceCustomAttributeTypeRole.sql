SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingSourceCustomAttributeTypeRole](
	[FundingSourceCustomAttributeTypeRoleID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeRolePermissionTypeID] [int] NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeTypeRoleID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeTypeRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID] FOREIGN KEY([FundingSourceCustomAttributeTypeID])
REFERENCES [dbo].[FundingSourceCustomAttributeType] ([FundingSourceCustomAttributeTypeID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID] FOREIGN KEY([FundingSourceCustomAttributeTypeID], [TenantID])
REFERENCES [dbo].[FundingSourceCustomAttributeType] ([FundingSourceCustomAttributeTypeID], [TenantID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeTypeRolePermissionType_FundingSourceCustomAttributeTypeRoleP] FOREIGN KEY([FundingSourceCustomAttributeTypeRolePermissionTypeID])
REFERENCES [dbo].[FundingSourceCustomAttributeTypeRolePermissionType] ([FundingSourceCustomAttributeTypeRolePermissionTypeID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeTypeRolePermissionType_FundingSourceCustomAttributeTypeRoleP]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_Role_RoleID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_Tenant_TenantID]