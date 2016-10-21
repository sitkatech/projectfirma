delete from dbo.SustainabilityRole
go

insert into dbo.SustainabilityRole(SustainabilityRoleID, SustainabilityRoleName, SustainabilityRoleDisplayName, SustainabilityRoleDescription, LTInfoAreaID) 
values 
(1, 'Admin', 'Administrator', '', 2),
(2, 'Normal', 'Normal User', 'Users with this role can''t do anything special - they are functionally equivalent to anonymous users, but this could change over time as we add functionality to the Sustainability Dashboard.', 2),
(3, 'Unassigned', 'Unassigned', '', 2)