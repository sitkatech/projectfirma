alter table dbo.Watershed add IsHuc4 bit
GO

insert into dbo.Watershed(WatershedName, WatershedFeature, TenantID, IsHuc4)
select concat(h4.Name, ' (', h4.HUC8, ')') as WatershedName, h4.Shape as WatershedFeature, 9 as TenantID, 1 as IsHuc4
from GeoCentral.dbo.HUC4 h4
where h4.States like '%ID%'

select *
from dbo.Watershed w
where w.IsHuc4 = 1
order by w.WatershedName

select distinct pw.ProjectID, pw.TenantID, a.Huc4WatershedID as WatershedID
into #ProjectWatersheds
from dbo.ProjectWatershed pw
join
(
	select w.WatershedID as Huc6WatershedID, w.WatershedName as Huc6Name, w2.WatershedID as Huc4WatershedID, w2.WatershedName as Huc4WatershedName
	from dbo.Watershed w
	join
	(
		select concat(h6.Name, ' (', h6.HUC12, ')') as WatershedName, concat(h4.Name, ' (', h4.HUC8, ')') as Huc4WatershedName
		from GeoCentral.dbo.HUC6 h6
		join GeoCentral.dbo.HUC4 h4 on left(h6.HUC12, 8) = h4.HUC8 and h4.States like '%ID%'
		where h6.States like '%ID%'
	) w2w on w.WatershedName = w2w.WatershedName
	left join dbo.Watershed w2 on w2w.Huc4WatershedName = w2.WatershedName and w2.TenantID = 9
	where w.TenantID = 9
) a on pw.WatershedID = a.Huc6WatershedID
where pw.TenantID = 9

select distinct pw.ProjectUpdateBatchID, pw.TenantID, a.Huc4WatershedID as WatershedID
into #ProjectWatershedUpdates
from dbo.ProjectWatershedUpdate pw
join
(
	select w.WatershedID as Huc6WatershedID, w.WatershedName as Huc6Name, w2.WatershedID as Huc4WatershedID, w2.WatershedName as Huc4WatershedName
	from dbo.Watershed w
	join
	(
		select concat(h6.Name, ' (', h6.HUC12, ')') as WatershedName, concat(h4.Name, ' (', h4.HUC8, ')') as Huc4WatershedName
		from GeoCentral.dbo.HUC6 h6
		join GeoCentral.dbo.HUC4 h4 on left(h6.HUC12, 8) = h4.HUC8 and h4.States like '%ID%'
		where h6.States like '%ID%'
	) w2w on w.WatershedName = w2w.WatershedName
	left join dbo.Watershed w2 on w2w.Huc4WatershedName = w2.WatershedName and w2.TenantID = 9
	where w.TenantID = 9
) a on pw.WatershedID = a.Huc6WatershedID
where pw.TenantID = 9

delete from dbo.ProjectWatershed where TenantID = 9
insert into dbo.ProjectWatershed(ProjectID, WatershedID, TenantID)
select ProjectID, WatershedID, TenantID
from dbo.#ProjectWatersheds
order by ProjectID, WatershedID

delete from dbo.ProjectWatershedUpdate where TenantID = 9
insert into dbo.ProjectWatershedUpdate(ProjectUpdateBatchID, WatershedID, TenantID)
select ProjectUpdateBatchID, WatershedID, TenantID
from dbo.#ProjectWatershedUpdates
order by ProjectUpdateBatchID, WatershedID

delete from dbo.Watershed where TenantID = 9 and IsHuc4 is null

drop table #ProjectWatersheds
drop table #ProjectWatershedUpdates

alter table dbo.Watershed drop column IsHuc4