--begin tran

update dbo.ProjectImage
set IsKeyPhoto = 1 where ProjectImageID in (
select 
    min(pi.ProjectImageID) as ProjectImageIDForKeyPhoto
from dbo.Project p 
    left join dbo.ProjectImage pi on pi.ProjectID = p.ProjectID 
group by p.ProjectID
having sum(case when pi.IsKeyPhoto = 1 then 1 else 0 end) = 0 and count(pi.ProjectImageID) > 0
)


--rollback tran