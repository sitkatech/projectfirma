SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttributeGroupProjectType](
	[ProjectCustomAttributeGroupProjectTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectCustomAttributeGroupID] [int] NOT NULL,
	[ProjectTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectCustomAttributeGroupProjectType_ProjectCustomAttributeGroupProjectTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeGroupProjectTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroupProjectType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID] FOREIGN KEY([ProjectCustomAttributeGroupID])
REFERENCES [dbo].[ProjectCustomAttributeGroup] ([ProjectCustomAttributeGroupID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectType] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroupProjectType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroupProjectType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID_TenantID] FOREIGN KEY([ProjectCustomAttributeGroupID], [TenantID])
REFERENCES [dbo].[ProjectCustomAttributeGroup] ([ProjectCustomAttributeGroupID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectType] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroupProjectType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroupProjectType_ProjectType_ProjectTypeID] FOREIGN KEY([ProjectTypeID])
REFERENCES [dbo].[ProjectType] ([ProjectTypeID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectType] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroupProjectType_ProjectType_ProjectTypeID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroupProjectType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroupProjectType] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroupProjectType_Tenant_TenantID]