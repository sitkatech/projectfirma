CREATE TABLE [dbo].[ProjectFundingSourceRequestUpdate](
	[ProjectFundingSourceRequestUpdateID] [int] IDENTITY(1,1) NOT NULL,
	TenantID int not null,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[SecuredAmount] [money] NOT NULL,
	[UnsecuredAmount] [money] NOT NULL,
 CONSTRAINT [PK_ProjectFundingSourceRequestUpdate_ProjectFundingSourceRequestUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectFundingSourceRequestUpdateID] ASC
),
 CONSTRAINT [AK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatchID_FundingSourceID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[FundingSourceID] ASC
)
)

Alter Table dbo.[ProjectFundingSourceRequestUpdate] Add Constraint FK_ProjectFundingSourceRequestUpdate_Tenant_TenantID Foreign Key (TenantID) References dbo.Tenant (TenantID)

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID]
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [CK_ProjectFundingSourceRequestUpdate_SecuredUnsecuredAmountBothCannotBeZero] CHECK  (([SecuredAmount]<>(0) OR [UnsecuredAmount]<>(0)))
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [CK_ProjectFundingSourceRequestUpdate_SecuredUnsecuredAmountBothCannotBeZero]
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [CK_ProjectFundingSourceRequestUpdate_UnsecuredAmountWholeDollarOnlyNoCents] CHECK  (([SecuredAmount]%(1)=(0.0)))
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [CK_ProjectFundingSourceRequestUpdate_UnsecuredAmountWholeDollarOnlyNoCents]
GO

Alter Table dbo.ProjectUpdateBatch Add ExpectedFundingComment varchar(1000) null
Alter Table dbo.ProjectUpdateBatch Add ExpectedFundingDiffLog varchar(max) null