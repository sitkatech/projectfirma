SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommodityPool](
	[CommodityPoolID] [int] IDENTITY(1,1) NOT NULL,
	[CommodityPoolName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[JurisdictionID] [int] NOT NULL,
	[Comments] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsActive] [bit] NOT NULL,
	[InactivatedDate] [datetime] NULL,
	[InactivatedByPersonID] [int] NULL,
	[CommodityID] [int] NOT NULL,
 CONSTRAINT [PK_CommodityPool_CommodityPoolID] PRIMARY KEY CLUSTERED 
(
	[CommodityPoolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CommodityPool_CommodityID_CommodityPoolName] UNIQUE NONCLUSTERED 
(
	[CommodityID] ASC,
	[CommodityPoolName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CommodityPool_CommodityPoolID_JurisdictionID] UNIQUE NONCLUSTERED 
(
	[CommodityPoolID] ASC,
	[JurisdictionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CommodityPool]  WITH CHECK ADD  CONSTRAINT [FK_CommodityPool_Commodity_CommodityID] FOREIGN KEY([CommodityID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[CommodityPool] CHECK CONSTRAINT [FK_CommodityPool_Commodity_CommodityID]
GO
ALTER TABLE [dbo].[CommodityPool]  WITH CHECK ADD  CONSTRAINT [FK_CommodityPool_Jurisdiction_JurisdictionID] FOREIGN KEY([JurisdictionID])
REFERENCES [dbo].[Jurisdiction] ([JurisdictionID])
GO
ALTER TABLE [dbo].[CommodityPool] CHECK CONSTRAINT [FK_CommodityPool_Jurisdiction_JurisdictionID]
GO
ALTER TABLE [dbo].[CommodityPool]  WITH CHECK ADD  CONSTRAINT [FK_CommodityPool_Person_InactivatedByPersonID_PersonID] FOREIGN KEY([InactivatedByPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CommodityPool] CHECK CONSTRAINT [FK_CommodityPool_Person_InactivatedByPersonID_PersonID]
GO
ALTER TABLE [dbo].[CommodityPool]  WITH CHECK ADD  CONSTRAINT [CK_Date_and_Person_Required_When_Inactive] CHECK  (([IsActive]=(1) OR [InactivatedDate]<>NULL AND [InactivatedByPersonID]<>NULL))
GO
ALTER TABLE [dbo].[CommodityPool] CHECK CONSTRAINT [CK_Date_and_Person_Required_When_Inactive]