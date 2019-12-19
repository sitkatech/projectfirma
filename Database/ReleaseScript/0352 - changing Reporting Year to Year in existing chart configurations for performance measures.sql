

update dbo.PerformanceMeasureSubcategory set ChartConfigurationJson = REPLACE(ChartConfigurationJson, '"Reporting Year"', '"Year"');

update dbo.PerformanceMeasureSubcategory set CumulativeChartConfigurationJson = REPLACE(CumulativeChartConfigurationJson, '"Reporting Year"', '"Year"');
