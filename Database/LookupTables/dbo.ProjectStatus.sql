
delete from dbo.ProjectStatus

insert dbo.ProjectStatus (ProjectStatusID, ProjectStatusColor, ProjectStatusName, ProjectStatusDisplayName, ProjectStatusSortOrder) values 
(1, '#04AF70', 'Green', 'Green',5),
(2, '#D0B001', 'Yellow', 'Yellow', 20),
(3, '#FF0000', 'Red', 'Red', 30),
(4, '#800080', 'OnHold', 'On Hold', 50)
