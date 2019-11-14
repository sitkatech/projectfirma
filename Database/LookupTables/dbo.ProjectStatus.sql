
delete from dbo.ProjectStatus

insert dbo.ProjectStatus (ProjectStatusID, ProjectStatusColor, ProjectStatusName, ProjectStatusDisplayName, ProjectStatusSortOrder) values 
(1, '#dbbdff', 'Green', 'Green',5),
(2, '#80B2FF', 'Yellow', 'Yellow', 20),
(3, '#1975FF', 'Red', 'Red', 30),
(4, '#000066', 'OnHold', 'On Hold', 50)
