SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingSourceCustomAttributeValue](
	[FundingSourceCustomAttributeValueID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FundingSourceCustomAttributeID] [int] NOT NULL,
	[AttributeValue] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttributeValue_FundingSourceCustomAttributeValueID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeValue_FundingSourceCustomAttribute_FundingSourceCustomAttributeID] FOREIGN KEY([FundingSourceCustomAttributeID])
REFERENCES [dbo].[FundingSourceCustomAttribute] ([FundingSourceCustomAttributeID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeValue] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeValue_FundingSourceCustomAttribute_FundingSourceCustomAttributeID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeValue_FundingSourceCustomAttribute_FundingSourceCustomAttributeID_TenantID] FOREIGN KEY([FundingSourceCustomAttributeID], [TenantID])
REFERENCES [dbo].[FundingSourceCustomAttribute] ([FundingSourceCustomAttributeID], [TenantID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeValue] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeValue_FundingSourceCustomAttribute_FundingSourceCustomAttributeID_TenantID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeValue_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeValue] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeValue_Tenant_TenantID]