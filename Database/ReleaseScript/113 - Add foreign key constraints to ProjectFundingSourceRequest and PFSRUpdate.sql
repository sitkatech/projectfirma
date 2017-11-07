
ALTER TABLE [dbo].[ProjectFundingSourceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequest_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequest] CHECK CONSTRAINT [FK_ProjectFundingSourceRequest_Project_ProjectID_TenantID]
GO


ALTER TABLE [dbo].[ProjectFundingSourceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequest_FundingSource_FundingSourceID_TenantID] FOREIGN KEY([FundingSourceID], [TenantID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequest] CHECK CONSTRAINT [FK_ProjectFundingSourceRequest_FundingSource_FundingSourceID_TenantID]
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID_TenantID] FOREIGN KEY([FundingSourceID], [TenantID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID_TenantID]
GO



ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectFundingSourceRequestUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO

