SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TdrTransaction](
	[TdrTransactionID] [int] IDENTITY(1,1) NOT NULL,
	[LeadAgencyID] [int] NOT NULL,
	[LeadAgencyAbbreviation] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TransactionTypeCommodityID] [int] NOT NULL,
	[TransactionTypeID] [int] NOT NULL,
	[TransactionTypeAbbreviation] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CommodityID] [int] NOT NULL,
	[DeallocatedRationale] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastUpdateDate] [datetime] NOT NULL,
	[LastUpdatePersonID] [int] NOT NULL,
	[ProjectNumber] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Comments] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TransactionStateID] [int] NOT NULL,
	[AccelaCAPRecordID] [int] NULL,
	[ApprovalDate] [datetime] NULL,
 CONSTRAINT [PK_TdrTransaction_TdrTransactionID] PRIMARY KEY CLUSTERED 
(
	[TdrTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_AccelaCAPRecord_AccelaCAPRecordID] FOREIGN KEY([AccelaCAPRecordID])
REFERENCES [dbo].[AccelaCAPRecord] ([AccelaCAPRecordID])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_AccelaCAPRecord_AccelaCAPRecordID]
GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_Commodity_CommodityID] FOREIGN KEY([CommodityID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_Commodity_CommodityID]
GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_LeadAgency_LeadAgencyID] FOREIGN KEY([LeadAgencyID])
REFERENCES [dbo].[LeadAgency] ([LeadAgencyID])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_LeadAgency_LeadAgencyID]
GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_LeadAgency_LeadAgencyID_LeadAgencyAbbreviation] FOREIGN KEY([LeadAgencyID], [LeadAgencyAbbreviation])
REFERENCES [dbo].[LeadAgency] ([LeadAgencyID], [LeadAgencyAbbreviation])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_LeadAgency_LeadAgencyID_LeadAgencyAbbreviation]
GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_Person_LastUpdatePersonID_PersonID] FOREIGN KEY([LastUpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_Person_LastUpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_TransactionState_TransactionStateID] FOREIGN KEY([TransactionStateID])
REFERENCES [dbo].[TransactionState] ([TransactionStateID])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_TransactionState_TransactionStateID]
GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_TransactionType_TransactionTypeID] FOREIGN KEY([TransactionTypeID])
REFERENCES [dbo].[TransactionType] ([TransactionTypeID])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_TransactionType_TransactionTypeID]
GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_TransactionType_TransactionTypeID_TransactionTypeAbbreviation] FOREIGN KEY([TransactionTypeID], [TransactionTypeAbbreviation])
REFERENCES [dbo].[TransactionType] ([TransactionTypeID], [TransactionTypeAbbreviation])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_TransactionType_TransactionTypeID_TransactionTypeAbbreviation]
GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_TransactionTypeCommodity_TransactionTypeCommodityID] FOREIGN KEY([TransactionTypeCommodityID])
REFERENCES [dbo].[TransactionTypeCommodity] ([TransactionTypeCommodityID])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_TransactionTypeCommodity_TransactionTypeCommodityID]
GO
ALTER TABLE [dbo].[TdrTransaction]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransaction_TransactionTypeCommodity_TransactionTypeCommodityID_TransactionTypeID_CommodityID] FOREIGN KEY([TransactionTypeCommodityID], [TransactionTypeID], [CommodityID])
REFERENCES [dbo].[TransactionTypeCommodity] ([TransactionTypeCommodityID], [TransactionTypeID], [CommodityID])
GO
ALTER TABLE [dbo].[TdrTransaction] CHECK CONSTRAINT [FK_TdrTransaction_TransactionTypeCommodity_TransactionTypeCommodityID_TransactionTypeID_CommodityID]