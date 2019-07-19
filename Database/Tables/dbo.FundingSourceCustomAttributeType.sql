SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingSourceCustomAttributeType](
	[FundingSourceCustomAttributeTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FundingSourceCustomAttributeDataTypeID] [int] NOT NULL,
	[MeasurementUnitTypeID] [int] NULL,
	[IsRequired] [bit] NOT NULL,
	[FundingSourceCustomAttributeTypeDescription] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundingSourceCustomAttributeTypeOptionsSchema] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IncludeInFundingSourceGrid] [bit] NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[FundingSourceCustomAttributeTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeName] UNIQUE NONCLUSTERED 
(
	[FundingSourceCustomAttributeTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeType_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeID] FOREIGN KEY([FundingSourceCustomAttributeDataTypeID])
REFERENCES [dbo].[FundingSourceCustomAttributeDataType] ([FundingSourceCustomAttributeDataTypeID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeType] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeType_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeType_MeasurementUnitType_MeasurementUnitTypeID] FOREIGN KEY([MeasurementUnitTypeID])
REFERENCES [dbo].[MeasurementUnitType] ([MeasurementUnitTypeID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeType] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeType_MeasurementUnitType_MeasurementUnitTypeID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeType] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeType_Tenant_TenantID]
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [CK_FundingSourceCustomAttributeType_PickListTypeOptionSchemaNotNull] CHECK  ((NOT ([FundingSourceCustomAttributeDataTypeID]=(6) OR [FundingSourceCustomAttributeDataTypeID]=(5)) AND [FundingSourceCustomAttributeTypeOptionsSchema] IS NULL OR ([FundingSourceCustomAttributeDataTypeID]=(6) OR [FundingSourceCustomAttributeDataTypeID]=(5)) AND [FundingSourceCustomAttributeTypeOptionsSchema] IS NOT NULL))
GO
ALTER TABLE [dbo].[FundingSourceCustomAttributeType] CHECK CONSTRAINT [CK_FundingSourceCustomAttributeType_PickListTypeOptionSchemaNotNull]