SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUpdateCustomAttribute](
	[ProjectUpdateCustomAttributeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateID] [int] NOT NULL,
	[ProjectCustomAttributeTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectUpdateCustomAttribute_ProjectUpdateCustomAttributeID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateCustomAttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdateCustomAttribute_ProjectUpdateCustomAttributeID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateCustomAttributeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID] FOREIGN KEY([ProjectCustomAttributeTypeID])
REFERENCES [dbo].[ProjectCustomAttributeType] ([ProjectCustomAttributeTypeID])
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute] CHECK CONSTRAINT [FK_ProjectUpdateCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID]
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID] FOREIGN KEY([ProjectCustomAttributeTypeID], [TenantID])
REFERENCES [dbo].[ProjectCustomAttributeType] ([ProjectCustomAttributeTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute] CHECK CONSTRAINT [FK_ProjectUpdateCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateCustomAttribute_ProjectUpdate_ProjectUpdateID] FOREIGN KEY([ProjectUpdateID])
REFERENCES [dbo].[ProjectUpdate] ([ProjectUpdateID])
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute] CHECK CONSTRAINT [FK_ProjectUpdateCustomAttribute_ProjectUpdate_ProjectUpdateID]
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateCustomAttribute_ProjectUpdate_ProjectUpdateID_TenantID] FOREIGN KEY([ProjectUpdateID], [TenantID])
REFERENCES [dbo].[ProjectUpdate] ([ProjectUpdateID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute] CHECK CONSTRAINT [FK_ProjectUpdateCustomAttribute_ProjectUpdate_ProjectUpdateID_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateCustomAttribute_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttribute] CHECK CONSTRAINT [FK_ProjectUpdateCustomAttribute_Tenant_TenantID]