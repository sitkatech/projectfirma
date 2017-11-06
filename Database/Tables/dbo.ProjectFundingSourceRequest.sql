SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFundingSourceRequest](
	[ProjectFundingSourceRequestID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[SecuredAmount] [money] NOT NULL,
	[UnsecuredAmount] [money] NOT NULL,
 CONSTRAINT [PK_ProjectFundingSourceRequest_ProjectFundingSourceRequestID] PRIMARY KEY CLUSTERED 
(
	[ProjectFundingSourceRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFundingSourceRequest_ProjectID_FundingSourceID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[FundingSourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
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
ALTER TABLE [dbo].[ProjectFundingSourceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequest_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequest] CHECK CONSTRAINT [FK_ProjectFundingSourceRequest_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequest]  WITH CHECK ADD  CONSTRAINT [CK_ProjectFundingSourceRequest_SecuredUnsecuredAmountBothCannotBeZero] CHECK  (([SecuredAmount]<>(0) OR [UnsecuredAmount]<>(0)))
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequest] CHECK CONSTRAINT [CK_ProjectFundingSourceRequest_SecuredUnsecuredAmountBothCannotBeZero]
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequest]  WITH CHECK ADD  CONSTRAINT [CK_ProjectFundingSourceRequest_UnsecuredAmountWholeDollarOnlyNoCents] CHECK  (([SecuredAmount]%(1)=(0.0)))
GO
ALTER TABLE [dbo].[ProjectFundingSourceRequest] CHECK CONSTRAINT [CK_ProjectFundingSourceRequest_UnsecuredAmountWholeDollarOnlyNoCents]