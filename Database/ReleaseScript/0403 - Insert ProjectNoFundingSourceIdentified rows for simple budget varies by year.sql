insert into dbo.ProjectNoFundingSourceIdentified (ProjectID, TenantID, NoFundingSourceIdentifiedYet)
select ProjectID, TenantID, NoFundingSourceIdentifiedYet
from dbo.Project
where NoFundingSourceIdentifiedYet is not null

alter table dbo.Project drop column NoFundingSourceIdentifiedYet


insert into dbo.ProjectNoFundingSourceIdentifiedUpdate (TenantID, ProjectUpdateBatchID, NoFundingSourceIdentifiedYet)
select TenantID, ProjectUpdateBatchID, NoFundingSourceIdentifiedYet
from dbo.ProjectUpdate
where NoFundingSourceIdentifiedYet is not null

alter table dbo.ProjectUpdate drop column NoFundingSourceIdentifiedYet
