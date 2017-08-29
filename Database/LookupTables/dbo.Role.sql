delete from dbo.Role
go

insert into dbo.Role(RoleID, RoleName, RoleDisplayName, RoleDescription) 
values 
(1, 'Admin', 'Administrator', ''),
(2, 'Normal', 'Normal User', 'Users with this role can propose new EIP projects, update existing EIP projects where their organization is the Lead Implementer, and view almost every page within the EIP Tracker.'),
(7, 'Unassigned', 'Unassigned', ''),
(8, 'SitkaAdmin', 'Sitka Administrator', ''),
(9, 'ProjectSteward', 'Project Steward', 'Users with this role can approve Project Proposals, create new Projects, approve Project Updates, and create Funding Sources for their Organization.')