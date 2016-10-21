delete from dbo.EIPRole
go

insert into dbo.EIPRole(EIPRoleID, EIPRoleName, EIPRoleDisplayName, EIPRoleDescription, LTInfoAreaID) 
values 
(1, 'Admin', 'Administrator', '', 1),
(2, 'Normal', 'Normal User', 'Users with this role can propose new EIP projects, update existing EIP projects where their organization is the Lead Implementer, and view almost every page within the EIP Tracker.', 1),
(3, 'ReadOnlyAdmin', 'Read-only Administrator User', '', 1),
(4, 'ReadOnlyNormal', 'Read-only Normal User', '', 1),
(5, 'Approver', 'Approver', '', 1),
(6, 'TMPOManager', 'TMPO Manager', '', 1),
(7, 'Unassigned', 'Unassigned', '', 1)