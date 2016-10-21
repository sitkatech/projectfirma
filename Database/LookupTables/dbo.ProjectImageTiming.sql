delete from dbo.ProjectImageTiming
go

insert into dbo.ProjectImageTiming(ProjectImageTimingID, ProjectImageTimingName, ProjectImageTimingDisplayName, SortOrder) values (1, 'After', 'After', 30)
insert into dbo.ProjectImageTiming(ProjectImageTimingID, ProjectImageTimingName, ProjectImageTimingDisplayName, SortOrder) values (2, 'Before', 'Before', 10)
insert into dbo.ProjectImageTiming(ProjectImageTimingID, ProjectImageTimingName, ProjectImageTimingDisplayName, SortOrder) values (3, 'During', 'During', 20)
insert into dbo.ProjectImageTiming(ProjectImageTimingID, ProjectImageTimingName, ProjectImageTimingDisplayName, SortOrder) values (4, 'Unknown', 'Unknown', 40)
