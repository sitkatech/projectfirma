SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingSourceCustomAttribute](
	[FundingSourceCustomAttributeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeID] [int] NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttribute_FundingSourceCustomAttributeID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingSourceCustomAttribute_FundingSourceCustomAttributeID_TenantID] UNIQUE NONCLUSTERED 
(
	[FundingSourceCustomAttributeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingSourceCustomAttribute_TenantID_FundingSourceID_FundingSourceCustomAttributeTypeID] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC,
	[FundingSourceID] ASC,
	[FundingSourceCustomAttributeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSource_FundingSourceID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSource_FundingSourceID_TenantID] FOREIGN KEY([FundingSourceID], [TenantID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID], [TenantID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSource_FundingSourceID_TenantID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID] FOREIGN KEY([FundingSourceCustomAttributeTypeID])
REFERENCES [dbo].[FundingSourceCustomAttributeType] ([FundingSourceCustomAttributeTypeID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID] FOREIGN KEY([FundingSourceCustomAttributeTypeID], [TenantID])
REFERENCES [dbo].[FundingSourceCustomAttributeType] ([FundingSourceCustomAttributeTypeID], [TenantID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_Tenant_TenantID]