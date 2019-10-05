

alter table dbo.Project
add LastUpdatedDate Datetime
GO

update p
set p.LastUpdatedDate = als.LastUpdatedDate
from dbo.Project as p
join 
(
    select ProjectID, MAX(AuditLogDate) as LastUpdatedDate
    from dbo.AuditLog as al 
    group by ProjectID
) als on p.ProjectID = als.ProjectID
GO

alter table dbo.Project
alter column LastUpdatedDate Datetime not null
GO


