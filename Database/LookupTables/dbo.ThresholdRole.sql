delete from dbo.ThresholdRole
go

insert into dbo.ThresholdRole(ThresholdRoleID, ThresholdRoleName, ThresholdRoleDisplayName, ThresholdRoleDescription, LTInfoAreaID) 
values 
(1, 'Admin', 'Administrator', '', 5),
(2, 'Normal', 'Normal User', 'Users with this role can''t do anything special - they are functionally equivalent to anonymous users, but this could change over time as we add functionality to the Thresholds Dashboard.', 5),
(3, 'Unassigned', 'Unassigned', '', 5)