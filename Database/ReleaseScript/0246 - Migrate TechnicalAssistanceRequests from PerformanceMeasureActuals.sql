
delete from TechnicalAssistanceRequest
go

-- Temp table
select pma.TenantID,
pma.ProjectID,
pma.CalendarYear FiscalYear,
pma.PerformanceMeasureID,
pma.PerformanceMeasureActualID,
pms.PerformanceMeasureSubcategoryDisplayName,
pmso.PerformanceMeasureSubcategoryID,
pmso.PerformanceMeasureSubcategoryOptionName,
pmso.PerformanceMeasureSubcategoryOptionID,
pma.ActualValue,
tat.TechnicalAssistanceTypeID
into #temp
from dbo.PerformanceMeasureActual pma
join dbo.PerformanceMeasureActualSubcategoryOption pmaso on pma.PerformanceMeasureActualID = pmaso.PerformanceMeasureActualID
join dbo.PerformanceMeasureSubcategory pms on pmaso.PerformanceMeasureSubcategoryID = pms.PerformanceMeasureSubcategoryID
join dbo.PerformanceMeasureSubcategoryOption pmso on pmaso.PerformanceMeasureSubcategoryOptionID = pmso.PerformanceMeasureSubcategoryOptionID 
left join dbo.TechnicalAssistanceType tat on pmso.PerformanceMeasureSubcategoryOptionName LIKE CONCAT(tat.TechnicalAssistanceTypeDisplayName, '%')
where pma.PerformanceMeasureID = 2147-- and pma.ProjectID = 6296

select * from #temp

insert into TechnicalAssistanceRequest (TenantID, ProjectID, FiscalYear, TechnicalAssistanceTypeID, HoursRequested, HoursAllocated, HoursProvided)
select 9 as TenantID,
b.ProjectID, b.FiscalYear, b.TechnicalAssistanceTypeID,
max(b.HoursRequested) as HoursRequested,
max(b.HoursAllocated) as HoursAllocated,
max(b.HoursProvided) as HoursProvided
from
(
	select 
	taRecords.ProjectID,
	taRecords.FiscalYear,
	taRecords.PersonID,
	taRecords.TechnicalAssistanceTypeID,
	hoursReq.HoursRequested,
	hoursAlloc.HoursAllocated,
	hoursProv.HoursProvided
	from  -- technical assistance
	(
		select  distinct
		temp.ProjectID,
		temp.FiscalYear,
		null PersonID,
		temp.TechnicalAssistanceTypeID,
		temp.PerformanceMeasureActualID
		from #temp temp
		where temp.TechnicalAssistanceTypeID is not null
	) taRecords
	left join -- Hours Requested
	(
		select temp.ProjectID,
		temp.FiscalYear,
		null PersonID,
		temp.PerformanceMeasureActualID,
		temp.ActualValue HoursRequested
		from #temp temp
		where temp.PerformanceMeasureSubcategoryOptionID = 2937
	) hoursReq on taRecords.PerformanceMeasureActualID = hoursReq.PerformanceMeasureActualID
	left join -- Hours Allocated
	(
		select temp.ProjectID,
		temp.FiscalYear,
		null PersonID,
		temp.PerformanceMeasureActualID,
		temp.ActualValue HoursAllocated
		from #temp temp
		where temp.PerformanceMeasureSubcategoryOptionID = 2936
	) hoursAlloc on taRecords.PerformanceMeasureActualID = hoursAlloc.PerformanceMeasureActualID
	left join -- Hours Provided 
	(
		select temp.ProjectID,
		temp.FiscalYear,
		null PersonID,
		temp.PerformanceMeasureActualID,
		temp.ActualValue HoursProvided
		from #temp temp
		where temp.PerformanceMeasureSubcategoryOptionID = 2935
	) hoursProv on taRecords.PerformanceMeasureActualID = hoursProv.PerformanceMeasureActualID
) b
group by b.ProjectID, b.FiscalYear, b.TechnicalAssistanceTypeID
order  by b.ProjectID, b.FiscalYear, b.TechnicalAssistanceTypeID

drop table #temp
