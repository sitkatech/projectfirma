SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttributeGroup](
	[ProjectCustomAttributeGroupID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectCustomAttributeGroupName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SortOrder] [int] NULL,
 CONSTRAINT [PK_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectCustomAttributeGroupID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeGroup_TenantID_ProjectCustomAttributeGroupName] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC,
	[ProjectCustomAttributeGroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroup_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeGroup] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroup_Tenant_TenantID]