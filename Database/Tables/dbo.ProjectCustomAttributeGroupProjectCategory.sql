SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttributeGroupProjectCategory](
	[ProjectCustomAttributeGroupProjectCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectCustomAttributeGroupID] [int] NOT NULL,
	[ProjectCategoryID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectCustomAttributeGroupProjectCategory_ProjectCustomAttributeGroupProjectCategoryID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeGroupProjectCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroupProjectCategory_ProjectCategory_ProjectCategoryID] FOREIGN KEY([ProjectCategoryID])
REFERENCES [dbo].[ProjectCategory] ([ProjectCategoryID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectCategory] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroupProjectCategory_ProjectCategory_ProjectCategoryID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroupProjectCategory_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID] FOREIGN KEY([ProjectCustomAttributeGroupID])
REFERENCES [dbo].[ProjectCustomAttributeGroup] ([ProjectCustomAttributeGroupID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectCategory] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroupProjectCategory_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroupProjectCategory_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID_TenantID] FOREIGN KEY([ProjectCustomAttributeGroupID], [TenantID])
REFERENCES [dbo].[ProjectCustomAttributeGroup] ([ProjectCustomAttributeGroupID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectCategory] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroupProjectCategory_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroupProjectCategory_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectCategory] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroupProjectCategory_Tenant_TenantID]