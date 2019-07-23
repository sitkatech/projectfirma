SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttribute](
	[ProjectCustomAttributeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[ProjectCustomAttributeTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectCustomAttribute_ProjectCustomAttributeID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttribute_ProjectCustomAttributeID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectCustomAttributeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttribute_TenantID_ProjectID_ProjectCustomAttributeTypeID] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC,
	[ProjectID] ASC,
	[ProjectCustomAttributeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttribute_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectCustomAttribute] CHECK CONSTRAINT [FK_ProjectCustomAttribute_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttribute_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttribute] CHECK CONSTRAINT [FK_ProjectCustomAttribute_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID] FOREIGN KEY([ProjectCustomAttributeTypeID])
REFERENCES [dbo].[ProjectCustomAttributeType] ([ProjectCustomAttributeTypeID])
GO
ALTER TABLE [dbo].[ProjectCustomAttribute] CHECK CONSTRAINT [FK_ProjectCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID]
GO
ALTER TABLE [dbo].[ProjectCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID] FOREIGN KEY([ProjectCustomAttributeTypeID], [TenantID])
REFERENCES [dbo].[ProjectCustomAttributeType] ([ProjectCustomAttributeTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttribute] CHECK CONSTRAINT [FK_ProjectCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttribute_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttribute] CHECK CONSTRAINT [FK_ProjectCustomAttribute_Tenant_TenantID]