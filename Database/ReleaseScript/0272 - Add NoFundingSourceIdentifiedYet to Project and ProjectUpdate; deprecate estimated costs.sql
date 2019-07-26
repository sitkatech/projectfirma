ALTER TABLE dbo.Project ADD NoFundingSourceIdentifiedYet money null;
GO

-- FundingType 1
Update project SET project.NoFundingSourceIdentifiedYet = other.calculatedNFSIY
FROM dbo.Project as project
INNER JOIN (Select p.projectid, p.tenantid, EstimatedTotalCost - sum(IsNull(SecuredAmount,0)) - Sum(IsNull(TargetedAmount,0)) as calculatedNFSIY
from dbo.Project p left join dbo.ProjectFundingSourceBudget pfsb on pfsb.projectID = p.projectid and pfsb.tenantID = p.tenantID   
group by p.projectid, p.tenantid, EstimatedTotalCost) other ON other.ProjectID = project.ProjectID and other.TenantID = project.TenantID
where project.FundingTypeID = 1 and EstimatedTotalCost is not null

-- FundingType 2
Update project SET project.NoFundingSourceIdentifiedYet = other.calculatedNFSIY
FROM dbo.Project as project
INNER JOIN (Select p.projectid, p.tenantid, EstimatedAnnualOperatingCost - sum(IsNull(SecuredAmount,0)) - Sum(IsNull(TargetedAmount,0)) as calculatedNFSIY
from dbo.Project p left join dbo.ProjectFundingSourceBudget pfsb on pfsb.projectID = p.projectid and pfsb.tenantID = p.tenantID   
group by p.projectid, p.tenantid, EstimatedAnnualOperatingCost) other ON other.ProjectID = project.ProjectID and other.TenantID = project.TenantID
where project.FundingTypeID = 2 and EstimatedAnnualOperatingCost is not null


-- Add NoFundingSourceIdentifiedYet to Project Update
ALTER TABLE dbo.ProjectUpdate ADD NoFundingSourceIdentifiedYet money null;
GO

-- FundingType 1 (aka EstimatedTotalCost is not null and EstimatedAnnualOperatingCost is null)
Update projectUpdate SET projectUpdate.NoFundingSourceIdentifiedYet = other.calculatedNFSIY
FROM dbo.ProjectUpdate as projectUpdate
INNER JOIN (
Select pu.ProjectUpdateID, pu.tenantid, EstimatedTotalCost - sum(IsNull(SecuredAmount,0)) - Sum(IsNull(TargetedAmount,0)) as calculatedNFSIY
from dbo.ProjectUpdate pu left join dbo.ProjectFundingSourceBudgetUpdate pfsb on pfsb.ProjectUpdateBatchID = pu.ProjectUpdateBatchID and pfsb.tenantID = pu.tenantID   
group by pu.ProjectUpdateID, pu.tenantid, EstimatedTotalCost
) other ON other.ProjectUpdateID = projectUpdate.ProjectUpdateID and other.TenantID = projectUpdate.TenantID
where  EstimatedTotalCost is not null and EstimatedAnnualOperatingCost is null

-- FundingType 2 (aka EstimatedTotalCost is null and EstimatedAnnualOperatingCost is not null)
Update projectUpdate SET projectUpdate.NoFundingSourceIdentifiedYet = other.calculatedNFSIY
FROM dbo.ProjectUpdate as projectUpdate
INNER JOIN (
Select pu.ProjectUpdateID, pu.tenantid, EstimatedAnnualOperatingCost - sum(IsNull(SecuredAmount,0)) - Sum(IsNull(TargetedAmount,0)) as calculatedNFSIY
from dbo.ProjectUpdate pu left join dbo.ProjectFundingSourceBudgetUpdate pfsb on pfsb.ProjectUpdateBatchID = pu.ProjectUpdateBatchID and pfsb.tenantID = pu.tenantID   
group by pu.ProjectUpdateID, pu.tenantid, EstimatedAnnualOperatingCost
) other ON other.ProjectUpdateID = projectUpdate.ProjectUpdateID and other.TenantID = projectUpdate.TenantID
where  EstimatedTotalCost is null and EstimatedAnnualOperatingCost is not null


--rename EstimatedTotalCost and EstimatedAnnualOperatingCost columns to deprecate them
--drop constraints on Project
Alter Table dbo.Project DROP CONSTRAINT CK_Project_TotalCostForBudgetVariesByYearProjectsOnly
Alter Table dbo.Project DROP CONSTRAINT CK_Project_AnnualCostForBudgetSameEachYearProjectsOnly
Alter Table dbo.Project DROP CONSTRAINT CK_Project_TotalOrAnnualCostNotBoth
Exec sp_rename 'dbo.Project.EstimatedTotalCost', 'EstimatedTotalCostDeprecated', 'Column'
Exec sp_rename 'dbo.Project.EstimatedAnnualOperatingCost', 'EstimatedAnnualOperatingCostDeprecated', 'Column'
Exec sp_rename 'dbo.ProjectUpdate.EstimatedTotalCost', 'EstimatedTotalCostDeprecated', 'Column'
Exec sp_rename 'dbo.ProjectUpdate.EstimatedAnnualOperatingCost', 'EstimatedAnnualOperatingCostDeprecated', 'Column'

-- drop CK_ProjectFundingSourceBudget_SecuredTargetedAmountBothCannotBeZero because we want users to enter $0 not blanks now
Alter Table dbo.ProjectFundingSourceBudget DROP CONSTRAINT CK_ProjectFundingSourceBudget_SecuredTargetedAmountBothCannotBeZero
Alter Table dbo.ProjectFundingSourceBudgetUpdate DROP CONSTRAINT CK_ProjectFundingSourceBudgetUpdate_SecuredTargetedAmountBothCannotBeZero