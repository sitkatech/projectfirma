update dbo.Project
set ProjectApprovalStatusID = 2, ApprovalDate = null, ReviewedByPersonID = null, ProjectStageID = 1
where TenantID = 2 and ProjectName like 'Lower Clackamas%'
and ProjectStageID = 2 and ReviewedByPersonID = 3137


delete al
from AuditLog al
where al.ProjectID in (49, 1065, 4264) and ColumnName in 
(
'ReviewedByPersonID',
'ApprovalDate',
'ProjectApprovalStatusID',
'ProjectStageID',
'ProjectID'
)
and AuditLogDate > '6/25/2018'
and AuditLogEventTypeID = 3