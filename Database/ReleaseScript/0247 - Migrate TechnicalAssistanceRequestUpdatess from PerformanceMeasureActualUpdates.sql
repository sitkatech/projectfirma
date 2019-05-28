delete from TechnicalAssistanceRequestUpdate
go

-- Temp table
select pma.TenantID,
pma.ProjectUpdateBatchID,
pma.CalendarYear FiscalYear,
pma.PerformanceMeasureID,
pma.PerformanceMeasureActualUpdateID,
pms.PerformanceMeasureSubcategoryDisplayName,
pmso.PerformanceMeasureSubcategoryID,
pmso.PerformanceMeasureSubcategoryOptionName,
pmso.PerformanceMeasureSubcategoryOptionID,
pma.ActualValue,
tat.TechnicalAssistanceTypeID
into #temp
from dbo.PerformanceMeasureActualUpdate pma
join dbo.PerformanceMeasureActualSubcategoryOptionUpdate pmaso on pma.PerformanceMeasureActualUpdateID = pmaso.PerformanceMeasureActualUpdateID
join dbo.PerformanceMeasureSubcategory pms on pmaso.PerformanceMeasureSubcategoryID = pms.PerformanceMeasureSubcategoryID
join dbo.PerformanceMeasureSubcategoryOption pmso on pmaso.PerformanceMeasureSubcategoryOptionID = pmso.PerformanceMeasureSubcategoryOptionID 
left join dbo.TechnicalAssistanceType tat on pmso.PerformanceMeasureSubcategoryOptionName LIKE CONCAT(tat.TechnicalAssistanceTypeDisplayName, '%')
where pma.PerformanceMeasureID = 2147

select * from #temp

insert into TechnicalAssistanceRequestUpdate (TenantID, ProjectUpdateBatchID, FiscalYear, TechnicalAssistanceTypeID, HoursRequested, HoursAllocated, HoursProvided)
select 9 as TenantID,
b.ProjectUpdateBatchID, b.FiscalYear, b.TechnicalAssistanceTypeID,
max(b.HoursRequested) as HoursRequested,
max(b.HoursAllocated) as HoursAllocated,
max(b.HoursProvided) as HoursProvided
from
(
	select 
	taRecords.ProjectUpdateBatchID,
	taRecords.FiscalYear,
	taRecords.PersonID,
	taRecords.TechnicalAssistanceTypeID,
	hoursReq.HoursRequested,
	hoursAlloc.HoursAllocated,
	hoursProv.HoursProvided
	from  -- technical assistance
	(
		select  distinct
		temp.ProjectUpdateBatchID,
		temp.FiscalYear,
		null PersonID,
		temp.TechnicalAssistanceTypeID,
		temp.PerformanceMeasureActualUpdateID
		from #temp temp
		where temp.TechnicalAssistanceTypeID is not null
	) taRecords
	left join -- Hours Requested
	(
		select temp.ProjectUpdateBatchID,
		temp.FiscalYear,
		null PersonID,
		temp.PerformanceMeasureActualUpdateID,
		temp.ActualValue HoursRequested
		from #temp temp
		where temp.PerformanceMeasureSubcategoryOptionID = 2937
	) hoursReq on taRecords.PerformanceMeasureActualUpdateID = hoursReq.PerformanceMeasureActualUpdateID
	left join -- Hours Allocated
	(
		select temp.ProjectUpdateBatchID,
		temp.FiscalYear,
		null PersonID,
		temp.PerformanceMeasureActualUpdateID,
		temp.ActualValue HoursAllocated
		from #temp temp
		where temp.PerformanceMeasureSubcategoryOptionID = 2936
	) hoursAlloc on taRecords.PerformanceMeasureActualUpdateID = hoursAlloc.PerformanceMeasureActualUpdateID
	left join -- Hours Provided 
	(
		select temp.ProjectUpdateBatchID,
		temp.FiscalYear,
		null PersonID,
		temp.PerformanceMeasureActualUpdateID,
		temp.ActualValue HoursProvided
		from #temp temp
		where temp.PerformanceMeasureSubcategoryOptionID = 2935
	) hoursProv on taRecords.PerformanceMeasureActualUpdateID = hoursProv.PerformanceMeasureActualUpdateID
) b
group by b.ProjectUpdateBatchID, b.FiscalYear, b.TechnicalAssistanceTypeID
order  by b.ProjectUpdateBatchID, b.FiscalYear, b.TechnicalAssistanceTypeID

drop table #temp