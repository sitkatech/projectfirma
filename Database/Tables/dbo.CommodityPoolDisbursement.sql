SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommodityPoolDisbursement](
	[CommodityPoolDisbursementID] [int] IDENTITY(1,1) NOT NULL,
	[CommodityPoolID] [int] NOT NULL,
	[CommodityPoolDisbursementTitle] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CommodityPoolDisbursementDate] [smalldatetime] NOT NULL,
	[CommodityPoolDisbursementAmount] [int] NOT NULL,
	[CommodityPoolDisbursementDescription] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatePersonID] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdatePersonID] [int] NULL,
 CONSTRAINT [PK_CommodityPoolDisbursement_CommodityPoolDisbursementID] PRIMARY KEY CLUSTERED 
(
	[CommodityPoolDisbursementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CommodityPoolDisbursement_CommodityPoolID_CommodityPoolDisbursementID] UNIQUE NONCLUSTERED 
(
	[CommodityPoolID] ASC,
	[CommodityPoolDisbursementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CommodityPoolDisbursement]  WITH CHECK ADD  CONSTRAINT [FK_CommodityPoolDisbursement_CommodityPool_CommodityPoolID] FOREIGN KEY([CommodityPoolID])
REFERENCES [dbo].[CommodityPool] ([CommodityPoolID])
GO
ALTER TABLE [dbo].[CommodityPoolDisbursement] CHECK CONSTRAINT [FK_CommodityPoolDisbursement_CommodityPool_CommodityPoolID]
GO
ALTER TABLE [dbo].[CommodityPoolDisbursement]  WITH CHECK ADD  CONSTRAINT [FK_CommodityPoolDisbursement_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CommodityPoolDisbursement] CHECK CONSTRAINT [FK_CommodityPoolDisbursement_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[CommodityPoolDisbursement]  WITH CHECK ADD  CONSTRAINT [FK_CommodityPoolDisbursement_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CommodityPoolDisbursement] CHECK CONSTRAINT [FK_CommodityPoolDisbursement_Person_UpdatePersonID_PersonID]