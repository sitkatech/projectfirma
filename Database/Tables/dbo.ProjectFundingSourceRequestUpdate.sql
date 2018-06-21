SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFundingSourceRequestUpdate](
	[ProjectFundingSourceRequestUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[SecuredAmount] [money] NULL,
	[UnsecuredAmount] [money] NULL,
 CONSTRAINT [PK_ProjectFundingSourceRequestUpdate_ProjectFundingSourceRequestUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectFundingSourceRequestUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatchID_FundingSourceID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[FundingSourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID_TenantID] FOREIGN KEY([FundingSourceID], [TenantID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID_TenantID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [CK_ProjectFundingSourceRequestUpdate_SecuredUnsecuredAmountBothCannotBeZero] CHECK  (([SecuredAmount]<>(0) OR [UnsecuredAmount]<>(0)))
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [CK_ProjectFundingSourceRequestUpdate_SecuredUnsecuredAmountBothCannotBeZero]
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [CK_ProjectFundingSourceRequestUpdate_UnsecuredAmountWholeDollarOnlyNoCents] CHECK  (([SecuredAmount]%(1)=(0.0)))
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [CK_ProjectFundingSourceRequestUpdate_UnsecuredAmountWholeDollarOnlyNoCents]