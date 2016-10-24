delete from dbo.Role
go

insert into dbo.Role(RoleID, RoleName, RoleDisplayName, RoleDescription) 
values 
(1, 'Admin', 'Administrator', ''),
(2, 'Normal', 'Normal User', 'Users with this role can propose new EIP projects, update existing EIP projects where their organization is the Lead Implementer, and view almost every page within the EIP Tracker.'),
(3, 'ReadOnlyAdmin', 'Read-only Administrator User', ''),
(4, 'ReadOnlyNormal', 'Read-only Normal User', ''),
(5, 'Approver', 'Approver', ''),
(6, 'TMPOManager', 'TMPO Manager', ''),
(7, 'Unassigned', 'Unassigned', ''),
(8, 'SitkaAdmin', 'Sitka Administrator', '')