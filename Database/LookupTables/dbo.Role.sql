delete from dbo.Role
go

insert into dbo.Role(RoleID, RoleName, RoleDisplayName, RoleDescription) 
values 
(1, 'Admin', 'Administrator', ''),
(2, 'Normal', 'Normal User', 'Users with this role can propose new projects, update existing projects where their organization is the Lead Implementer, and view almost every page within Project Firma.'),
(7, 'Unassigned', 'Unassigned', ''),
(8, 'SitkaAdmin', 'Sitka Administrator', '')