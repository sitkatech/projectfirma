delete from dbo.GoogleChartType
go

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