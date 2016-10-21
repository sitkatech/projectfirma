SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TdrTransactionStateHistory](
	[TdrTransactionStateHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[TdrTransactionID] [int] NOT NULL,
	[TransactionStateID] [int] NOT NULL,
	[UpdatePersonID] [int] NOT NULL,
	[TransitionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TdrTransactionStateHistory_TdrTransactionStateHistoryID] PRIMARY KEY CLUSTERED 
(
	[TdrTransactionStateHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TdrTransactionStateHistory]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionStateHistory_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TdrTransactionStateHistory] CHECK CONSTRAINT [FK_TdrTransactionStateHistory_Person_UpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[TdrTransactionStateHistory]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionStateHistory_TdrTransaction_TdrTransactionID] FOREIGN KEY([TdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[TdrTransactionStateHistory] CHECK CONSTRAINT [FK_TdrTransactionStateHistory_TdrTransaction_TdrTransactionID]
GO
ALTER TABLE [dbo].[TdrTransactionStateHistory]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionStateHistory_TransactionState_TransactionStateID] FOREIGN KEY([TransactionStateID])
REFERENCES [dbo].[TransactionState] ([TransactionStateID])
GO
ALTER TABLE [dbo].[TdrTransactionStateHistory] CHECK CONSTRAINT [FK_TdrTransactionStateHistory_TransactionState_TransactionStateID]