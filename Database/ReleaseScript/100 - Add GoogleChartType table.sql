create table dbo.GoogleChartType
(
	GoogleChartTypeID int not null constraint PK_GoogleChartType_GoogleChartTypeID primary key,
	GoogleChartTypeName varchar(50) not null constraint AK_GoogleChartType_GoogleChartTypeName unique,
	GoogleChartTypeDisplayName varchar(50) not null constraint AK_GoogleChartType_GoogleChartTypeDisplayName unique,
	SeriesDataDisplayType varchar(50) null
)

ALTER TABLE dbo.PerformanceMeasureSubcategory ADD GoogleChartTypeID int null
Alter table dbo.PerformanceMeasureSubcategory ADD constraint FK_PerformanceMeasureSubcategory_GoogleChartType_GoogleChartTypeID foreign key (GoogleChartTypeID) references dbo.GoogleChartType(GoogleChartTypeID)

GO

insert into dbo.GoogleChartType(GoogleChartTypeID, GoogleChartTypeName, GoogleChartTypeDisplayName, SeriesDataDisplayType)
values
(1, 'ColumnChart', 'ColumnChart', 'bars'),
(2, 'LineChart', 'LineChart', 'line'),
(3, 'ComboChart', 'ComboChart', null),
(4, 'AreaChart', 'AreaChart', 'area'),
(5, 'PieChart', 'PieChart', 'pie'),
(6, 'ImageChart', 'ImageChart', null),
(7, 'BarChart', 'BarChart', 'bars'),
(8, 'Histogram', 'Histogram', 'histogram'),
(9, 'BubbleChart', 'BubbleChart', null),
(10, 'ScatterChart', 'ScatterChart', null),
(11, 'SteppedAreaChart', 'SteppedAreaChart', 'steppedArea')

update pmsc
set pmsc.GoogleChartTypeID = gct.GoogleChartTypeID
from dbo.PerformanceMeasureSubcategory pmsc
join dbo.GoogleChartType gct on pmsc.ChartType = gct.GoogleChartTypeDisplayName


alter table dbo.PerformanceMeasureSubcategory drop column ChartType