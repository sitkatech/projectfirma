alter table dbo.ProjectFundingSourceExpenditure
drop constraint CK_ProjectFundingSourceExpenditure_ExpenditureAmountWholeDollarOnlyNoCents

alter table dbo.ProjectFundingSourceExpenditureUpdate
drop constraint CK_ProjectFundingSourceExpenditureUpdate_ExpenditureAmountWholeDollarOnlyNoCents

alter table dbo.ProjectFundingSourceRequest
drop constraint CK_ProjectFundingSourceRequest_UnsecuredAmountWholeDollarOnlyNoCents

alter table dbo.ProjectFundingSourceRequestUpdate
drop constraint CK_ProjectFundingSourceRequestUpdate_UnsecuredAmountWholeDollarOnlyNoCents

ALTER TABLE [dbo].[Project] DROP CONSTRAINT [CK_Project_EstimatedTotalCostWholeDollarOnlyNoCents]
GO


ALTER TABLE [dbo].[Project] DROP CONSTRAINT [CK_Project_TotalOrAnnualCostNotBoth]
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [CK_Project_AnnualCostForOperationsProjectsOnly]
GO

Alter Table [dbo].project
Alter column EstimatedAnnualOperatingCost money null

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_AnnualCostForOperationsProjectsOnly] CHECK  (([FundingTypeID]=(2) OR [EstimatedAnnualOperatingCost] IS NULL))
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_TotalOrAnnualCostNotBoth] CHECK  (([EstimatedAnnualOperatingCost] IS NOT NULL AND [EstimatedTotalCost] IS NULL OR [EstimatedAnnualOperatingCost] IS NULL AND [EstimatedTotalCost] IS NOT NULL OR [EstimatedAnnualOperatingCost] IS NULL AND [EstimatedTotalCost] IS NULL))
GO

ALTER TABLE [dbo].[ProjectUpdate] DROP CONSTRAINT [CK_ProjectUpdate_EstimatedTotalCostWholeDollarOnlyNoCents]
GO

