if exists (select * from dbo.sysobjects where id = object_id('dbo.vGeoServerProjectDetailedLocations'))
	drop view dbo.vGeoServerProjectDetailedLocations
go

create view [dbo].[vGeoServerProjectDetailedLocations]
as

select 
    pl.ProjectLocationID,
    pl.ProjectLocationID as PrimaryKey,
    pl.ProjectID,
    p.ProjectName,
    pl.ProjectLocationGeometry,
    pl.TenantID,
    t.TenantName

from dbo.ProjectLocation pl
join dbo.Project p on pl.ProjectID = p.ProjectID 
join dbo.Tenant t on pl.TenantID = t.TenantID