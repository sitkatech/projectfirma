SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachmentTypeRole](
	[AttachmentTypeRoleID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[AttachmentTypeID] [int] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_AttachmentTypeRole_AttachmentTypeRoleID] PRIMARY KEY CLUSTERED 
(
	[AttachmentTypeRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AttachmentTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentTypeRole_AttachmentType_AttachmentTypeID] FOREIGN KEY([AttachmentTypeID])
REFERENCES [dbo].[AttachmentType] ([AttachmentTypeID])
GO
ALTER TABLE [dbo].[AttachmentTypeRole] CHECK CONSTRAINT [FK_AttachmentTypeRole_AttachmentType_AttachmentTypeID]
GO
ALTER TABLE [dbo].[AttachmentTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentTypeRole_AttachmentType_AttachmentTypeID_TenantID] FOREIGN KEY([AttachmentTypeID], [TenantID])
REFERENCES [dbo].[AttachmentType] ([AttachmentTypeID], [TenantID])
GO
ALTER TABLE [dbo].[AttachmentTypeRole] CHECK CONSTRAINT [FK_AttachmentTypeRole_AttachmentType_AttachmentTypeID_TenantID]
GO
ALTER TABLE [dbo].[AttachmentTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentTypeRole_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[AttachmentTypeRole] CHECK CONSTRAINT [FK_AttachmentTypeRole_Role_RoleID]
GO
ALTER TABLE [dbo].[AttachmentTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentTypeRole_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[AttachmentTypeRole] CHECK CONSTRAINT [FK_AttachmentTypeRole_Tenant_TenantID]