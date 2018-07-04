SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUpdateCustomAttributeValue](
	[ProjectUpdateCustomAttributeValueID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateCustomAttributeID] [int] NOT NULL,
	[AttributeValue] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectUpdateCustomAttributeValue_ProjectUpdateCustomAttributeValueID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateCustomAttributeValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateCustomAttributeValue_ProjectUpdateCustomAttribute_ProjectUpdateCustomAttributeID] FOREIGN KEY([ProjectUpdateCustomAttributeID])
REFERENCES [dbo].[ProjectUpdateCustomAttribute] ([ProjectUpdateCustomAttributeID])
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttributeValue] CHECK CONSTRAINT [FK_ProjectUpdateCustomAttributeValue_ProjectUpdateCustomAttribute_ProjectUpdateCustomAttributeID]
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateCustomAttributeValue_ProjectUpdateCustomAttribute_ProjectUpdateCustomAttributeID_TenantID] FOREIGN KEY([ProjectUpdateCustomAttributeID], [TenantID])
REFERENCES [dbo].[ProjectUpdateCustomAttribute] ([ProjectUpdateCustomAttributeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttributeValue] CHECK CONSTRAINT [FK_ProjectUpdateCustomAttributeValue_ProjectUpdateCustomAttribute_ProjectUpdateCustomAttributeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateCustomAttributeValue_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateCustomAttributeValue] CHECK CONSTRAINT [FK_ProjectUpdateCustomAttributeValue_Tenant_TenantID]