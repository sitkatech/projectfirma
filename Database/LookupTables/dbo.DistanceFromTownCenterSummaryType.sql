delete from dbo.DistanceFromTownCenterSummaryType
go

insert into dbo.DistanceFromTownCenterSummaryType(DistanceFromTownCenterSummaryTypeID, DistanceFromTownCenterSummaryTypeName, DistanceFromTownCenterSummaryTypeDisplayName) 
values 
(1, 'InsideTownCenter', 'Inside Town Center'),
(2, 'WithinQuarterMileOfTownCenterBoundary', 'Within quarter mile of Town Center Boundary'),
(3, 'OutsideTownCenter', 'Outside Town Center'),
(4, 'Unknown', 'Unknown')