SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttributeValue](
	[ProjectCustomAttributeValueID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectCustomAttributeID] [int] NOT NULL,
	[AttributeValue] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectCustomAttributeValue_ProjectCustomAttributeValueID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX [IDX_ProjectCustomAttributeValue_ProjectCustomAttribute] ON [dbo].[ProjectCustomAttributeValue]
(
	[ProjectCustomAttributeID] ASC
)
INCLUDE([TenantID]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ProjectCustomAttributeValue_Tenant] ON [dbo].[ProjectCustomAttributeValue]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeValue_ProjectCustomAttribute_ProjectCustomAttributeID] FOREIGN KEY([ProjectCustomAttributeID])
REFERENCES [dbo].[ProjectCustomAttribute] ([ProjectCustomAttributeID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeValue] CHECK CONSTRAINT [FK_ProjectCustomAttributeValue_ProjectCustomAttribute_ProjectCustomAttributeID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeValue_ProjectCustomAttribute_ProjectCustomAttributeID_TenantID] FOREIGN KEY([ProjectCustomAttributeID], [TenantID])
REFERENCES [dbo].[ProjectCustomAttribute] ([ProjectCustomAttributeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeValue] CHECK CONSTRAINT [FK_ProjectCustomAttributeValue_ProjectCustomAttribute_ProjectCustomAttributeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeValue_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeValue] CHECK CONSTRAINT [FK_ProjectCustomAttributeValue_Tenant_TenantID]