update dbo.Project
set ProjectStageID = 1, ProjectApprovalStatusID = 5, ApprovalDate = null
where TenantID = 2 and ProjectStageID = 2 and ApprovalDate is not null


select *
from dbo.Project
where TenantID = 2 and ProjectStageID = 2 and ApprovalDate is null

select *
from ProjectApprovalStatus

select *
from ProjectStage


select *
from dbo.Project
where TenantID = 2 and ProjectStageID = 2