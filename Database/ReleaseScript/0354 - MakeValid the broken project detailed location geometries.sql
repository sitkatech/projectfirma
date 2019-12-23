/* 

select 
    pl.ProjectLocationID,
    pl.ProjectLocationID as PrimaryKey,
    pl.ProjectID,
    p.ProjectName,
    pl.ProjectLocationGeometry.STIsValid(),
    pl.ProjectLocationGeometry,
    pl.TenantID,
    t.TenantName

from dbo.ProjectLocation pl
join dbo.Project p on pl.ProjectID = p.ProjectID 
join dbo.Tenant t on pl.TenantID = t.TenantID
where pl.ProjectLocationGeometry.STIsValid() = 0
*/

-- RCDProjectTracker Project#6292
update dbo.ProjectLocation 
set ProjectLocationGeometry = ProjectLocationGeometry.MakeValid()
where ProjectLocationID = 7333

-- IdahoAssociatonOfSoilConservationDistricts Project#12446
update dbo.ProjectLocation 
set ProjectLocationGeometry = ProjectLocationGeometry.MakeValid()
where ProjectLocationID = 7361

-- RCDProjectTracker Project#13453
update dbo.ProjectLocation 
set ProjectLocationGeometry = ProjectLocationGeometry.MakeValid()
where ProjectLocationID = 7703