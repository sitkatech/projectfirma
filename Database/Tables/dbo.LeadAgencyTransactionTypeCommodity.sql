SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadAgencyTransactionTypeCommodity](
	[LeadAgencyTransactionTypeCommodityID] [int] IDENTITY(1,1) NOT NULL,
	[LeadAgencyID] [int] NOT NULL,
	[TransactionTypeCommodityID] [int] NOT NULL,
 CONSTRAINT [PK_LeadAgencyTransactionTypeCommodity_LeadAgencyTransactionTypeCommodityID] PRIMARY KEY CLUSTERED 
(
	[LeadAgencyTransactionTypeCommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_LeadAgencyTransactionTypeCommodity_LeadAgencyID_TransactionTypeCommodityID] UNIQUE NONCLUSTERED 
(
	[LeadAgencyID] ASC,
	[TransactionTypeCommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_LeadAgencyTransactionTypeCommodity_LeadAgencyTransactionTypeCommodityID_LeadAgencyID_TransactionTypeCommodityID] UNIQUE NONCLUSTERED 
(
	[LeadAgencyTransactionTypeCommodityID] ASC,
	[LeadAgencyID] ASC,
	[TransactionTypeCommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodity]  WITH CHECK ADD  CONSTRAINT [FK_LeadAgencyTransactionTypeCommodity_LeadAgency_LeadAgencyID] FOREIGN KEY([LeadAgencyID])
REFERENCES [dbo].[LeadAgency] ([LeadAgencyID])
GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodity] CHECK CONSTRAINT [FK_LeadAgencyTransactionTypeCommodity_LeadAgency_LeadAgencyID]
GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodity]  WITH CHECK ADD  CONSTRAINT [FK_LeadAgencyTransactionTypeCommodity_TransactionTypeCommodity_TransactionTypeCommodityID] FOREIGN KEY([TransactionTypeCommodityID])
REFERENCES [dbo].[TransactionTypeCommodity] ([TransactionTypeCommodityID])
GO
ALTER TABLE [dbo].[LeadAgencyTransactionTypeCommodity] CHECK CONSTRAINT [FK_LeadAgencyTransactionTypeCommodity_TransactionTypeCommodity_TransactionTypeCommodityID]