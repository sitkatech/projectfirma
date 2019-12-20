if exists (select * from dbo.sysobjects where id = object_id('dbo.vGeoServerProjectSimpleLocations'))
	drop view dbo.vGeoServerProjectSimpleLocations
go

create view [dbo].[vGeoServerProjectSimpleLocations]
as

select
	p.ProjectID,
    p.ProjectID as PrimaryKey,
    p.ProjectName,
    p.ProjectLocationPoint,
    p.TenantID,
    t.TenantName
from
	dbo.Project p
	join dbo.Tenant t on p.TenantID = t.TenantID
    where ProjectLocationPoint is not null