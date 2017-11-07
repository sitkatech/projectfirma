CREATE TABLE [dbo].[ProjectFundingSourceRequest](
	[ProjectFundingSourceRequestID] [int] IDENTITY(1,1) NOT NULL,
	TenantID int not null,
	[ProjectID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[SecuredAmount] [money] NOT NULL,
	[UnsecuredAmount] [money] NOT NULL,
 CONSTRAINT [PK_ProjectFundingSourceRequest_ProjectFundingSourceRequestID] PRIMARY KEY CLUSTERED 
(
	[ProjectFundingSourceRequestID] ASC
),
 CONSTRAINT [AK_ProjectFundingSourceRequest_ProjectID_FundingSourceID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[FundingSourceID] ASC
)
)

Alter Table dbo.ProjectFundingSourceRequest Add Constraint FK_ProjectFundingSourceRequest_Tenant_TenantID Foreign Key (TenantID) References dbo.Tenant (TenantID)

ALTER TABLE [dbo].[ProjectFundingSourceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequest_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequest] CHECK CONSTRAINT [FK_ProjectFundingSourceRequest_FundingSource_FundingSourceID]
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequest_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequest] CHECK CONSTRAINT [FK_ProjectFundingSourceRequest_Project_ProjectID]
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequest]  WITH CHECK ADD  CONSTRAINT [CK_ProjectFundingSourceRequest_SecuredUnsecuredAmountBothCannotBeZero] CHECK  (([SecuredAmount]<>(0) OR [UnsecuredAmount]<>(0)))
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequest] CHECK CONSTRAINT [CK_ProjectFundingSourceRequest_SecuredUnsecuredAmountBothCannotBeZero]
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequest]  WITH CHECK ADD  CONSTRAINT [CK_ProjectFundingSourceRequest_UnsecuredAmountWholeDollarOnlyNoCents] CHECK  (([SecuredAmount]%(1)=(0.0)))
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequest] CHECK CONSTRAINT [CK_ProjectFundingSourceRequest_UnsecuredAmountWholeDollarOnlyNoCents]
GO