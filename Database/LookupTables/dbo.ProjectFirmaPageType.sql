delete from dbo.ProjectFirmaPageType
go

insert into dbo.ProjectFirmaPageType(ProjectFirmaPageTypeID, ProjectFirmaPageTypeName, ProjectFirmaPageTypeDisplayName, PrimaryLTInfoAreaID, ProjectFirmaPageRenderTypeID)
values
(1, 'HomePage', 'Home Page', 1, 2),
(2, 'AboutClackamasPartnership', 'About Clackamas Partnership', 1, 2),
(3, 'Meetings', 'Meetings', 1, 2)