insert into dbo.ProjectRelevantCostTypeUpdate (TenantID, ProjectUpdateBatchID, CostTypeID, ProjectRelevantCostTypeGroupID) 
select pfsbu.TenantID, pfsbu.ProjectUpdateBatchID, pfsbu.CostTypeID, 2 
from dbo.ProjectFundingSourceBudgetUpdate pfsbu left outer join dbo.ProjectRelevantCostTypeUpdate prctu on pfsbu.ProjectUpdateBatchID = prctu.ProjectUpdateBatchID 
where prctu.ProjectUpdateBatchID is null and pfsbu.CostTypeID is not null group by pfsbu.TenantID, pfsbu.ProjectUpdateBatchID, pfsbu.CostTypeID