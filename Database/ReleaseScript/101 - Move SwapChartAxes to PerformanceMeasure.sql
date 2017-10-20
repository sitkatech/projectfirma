alter table dbo.PerformanceMeasure add SwapChartAxes bit null;

go

update dbo.PerformanceMeasure set SwapChartAxes = 0 

update dbo.PerformanceMeasure 
set SwapChartAxes = 1 
where PerformanceMeasureID in (
select PerformanceMeasureID 
from dbo.PerformanceMeasureSubcategory
where SwapChartAxes = 1)

go

alter table dbo.PerformanceMeasure alter column SwapChartAxes bit not null;
alter table dbo.PerformanceMeasureSubcategory drop column SwapChartAxes;

-- CanCalculateTotal
alter table dbo.PerformanceMeasure add CanCalculateTotal bit null;

go

update dbo.PerformanceMeasure 
set CanCalculateTotal = 1

go

alter table dbo.PerformanceMeasure alter column CanCalculateTotal bit not null;

