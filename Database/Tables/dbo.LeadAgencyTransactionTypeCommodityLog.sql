SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadAgencyTransactionTypeCommodityLog](
	[LeadAgencyTransactionTypeCommodityLogID] [int] IDENTITY(1,1) NOT NULL,
	[LeadAgencyID] [int] NOT NULL,
	[TransactionTypeCommodityID] [int] NOT NULL,
	[LeadAgencyTransactionTypeCommodityLogChangeTypeID] [int] NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LeadAgencyTransactionTypeCommodityLog_LeadAgencyTransactionTypeCommodityLogID] PRIMARY KEY CLUSTERED 
(
	[LeadAgencyTransactionTypeCommodityLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodityLog]  WITH CHECK ADD  CONSTRAINT [FK_LeadAgencyTransactionTypeCommodityLog_LeadAgency_LeadAgencyID] FOREIGN KEY([LeadAgencyID])
REFERENCES [dbo].[LeadAgency] ([LeadAgencyID])
GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodityLog] CHECK CONSTRAINT [FK_LeadAgencyTransactionTypeCommodityLog_LeadAgency_LeadAgencyID]
GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodityLog]  WITH CHECK ADD  CONSTRAINT [FK_LeadAgencyTransactionTypeCommodityLog_LeadAgencyTransactionTypeCommodityLogChangeType_LeadAgencyTransactionTypeCommodityLogCh] FOREIGN KEY([LeadAgencyTransactionTypeCommodityLogChangeTypeID])
REFERENCES [dbo].[LeadAgencyTransactionTypeCommodityLogChangeType] ([LeadAgencyTransactionTypeCommodityLogChangeTypeID])
GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodityLog] CHECK CONSTRAINT [FK_LeadAgencyTransactionTypeCommodityLog_LeadAgencyTransactionTypeCommodityLogChangeType_LeadAgencyTransactionTypeCommodityLogCh]
GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodityLog]  WITH CHECK ADD  CONSTRAINT [FK_LeadAgencyTransactionTypeCommodityLog_TransactionTypeCommodity_TransactionTypeCommodityID] FOREIGN KEY([TransactionTypeCommodityID])
REFERENCES [dbo].[TransactionTypeCommodity] ([TransactionTypeCommodityID])
GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodityLog] CHECK CONSTRAINT [FK_LeadAgencyTransactionTypeCommodityLog_TransactionTypeCommodity_TransactionTypeCommodityID]