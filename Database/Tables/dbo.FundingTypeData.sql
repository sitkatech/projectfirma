SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingTypeData](
	[FundingTypeDataID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FundingTypeID] [int] NOT NULL,
	[FundingTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FundingTypeShortName] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_FundingTypeData_FundingTypeDataID] PRIMARY KEY CLUSTERED 
(
	[FundingTypeDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingTypeData_FundingTypeDisplayName_TenantID] UNIQUE NONCLUSTERED 
(
	[FundingTypeDisplayName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingTypeData_FundingTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[FundingTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingTypeData_FundingTypeShortName_TenantID] UNIQUE NONCLUSTERED 
(
	[FundingTypeShortName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FundingTypeData]  WITH CHECK ADD  CONSTRAINT [FK_FundingTypeData_FundingType_FundingTypeID] FOREIGN KEY([FundingTypeID])
REFERENCES [dbo].[FundingType] ([FundingTypeID])
GO
ALTER TABLE [dbo].[FundingTypeData] CHECK CONSTRAINT [FK_FundingTypeData_FundingType_FundingTypeID]
GO
ALTER TABLE [dbo].[FundingTypeData]  WITH CHECK ADD  CONSTRAINT [FK_FundingTypeData_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FundingTypeData] CHECK CONSTRAINT [FK_FundingTypeData_Tenant_TenantID]