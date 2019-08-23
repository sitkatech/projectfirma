delete from dbo.ProjectCustomGridColumn
go

insert into dbo.ProjectCustomGridColumn(ProjectCustomGridColumnID, ProjectCustomGridColumnName, ProjectCustomGridColumnDisplayName)
values
(1, 'PerformanceMeasureCount', 'Performance Measure Count'),
(2, 'GeospatialAreaName', 'Geospatial Area Name'),
(3, 'CustomAttribute', 'Custom Attribute')