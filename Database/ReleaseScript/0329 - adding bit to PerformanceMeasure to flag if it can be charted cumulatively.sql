

alter table dbo.PerformanceMeasure
add CanBeChartedCumulatively bit
go

update dbo.PerformanceMeasure set CanBeChartedCumulatively = 0 where CanBeChartedCumulatively is null;

alter table dbo.PerformanceMeasure
alter column CanBeChartedCumulatively bit not null


alter table dbo.PerformanceMeasureSubcategory
add CumulativeChartConfigurationJson varchar(max) null,
CumulativeGoogleChartTypeID int null constraint FK_PerformanceMeasureSubcategory_GoogleChartType_CumulativeGoogleChartTypeID_GoogleChartTypeID foreign key references dbo.GoogleChartType(GoogleChartTypeID)
--,CumulativeShowOnChart bit;
go

--update dbo.PerformanceMeasureSubcategory set CumulativeShowOnChart = 0 where CumulativeShowOnChart is null;

--alter table dbo.PerformanceMeasureSubcategory
--alter column CumulativeShowOnChart bit not null;