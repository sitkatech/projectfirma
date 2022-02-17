-- delete the one project update for NCRP
delete from dbo.ProjectUpdate where ProjectUpdateBatchID = 10691
delete from dbo.ProjectOrganizationUpdate where ProjectUpdateBatchID = 10691
delete from dbo.ProjectUpdateHistory where ProjectUpdateBatchID = 10691
delete from dbo.ProjectFundingSourceExpenditureUpdate where ProjectUpdateBatchID = 10691
delete from dbo.ProjectContactUpdate where ProjectUpdateBatchID = 10691
delete from dbo.ProjectFundingSourceBudgetUpdate where ProjectUpdateBatchID = 10691
delete from dbo.ProjectUpdateBatch where ProjectUpdateBatchID = 10691

update dbo.Project set ProjectApprovalStatusID = 2, ProposingPersonID = 8223, ProposingDate = CURRENT_TIMESTAMP where TenantID = 4 and ProjectApprovalStatusID = 3