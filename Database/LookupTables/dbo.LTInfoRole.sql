delete from dbo.LTInfoRole
go

insert into dbo.LTInfoRole(LTInfoRoleID, LTInfoRoleName, LTInfoRoleDisplayName, LTInfoRoleDescription, LTInfoAreaID) 
values 
(1, 'Admin', 'Administrator', '', 3),
(2, 'Normal', 'Normal User', 'Users with this role can view other user''s profile or summary pages; otherwise, they are functionally equivalent to anonymous users.', 3),
(3, 'Unassigned', 'Unassigned', '', 3),
(4, 'IndicatorEditor', 'Indicator Editor', '', 3)
