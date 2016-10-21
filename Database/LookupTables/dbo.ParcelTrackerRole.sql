delete from dbo.ParcelTrackerRole
go

insert into dbo.ParcelTrackerRole(ParcelTrackerRoleID, ParcelTrackerRoleName, ParcelTrackerRoleDisplayName, ParcelTrackerRoleDescription, LTInfoAreaID) 
values 
(1, 'Admin', 'Administrator', '', 4),
(2, 'Power', 'Power User', '', 4),
(3, 'Normal', 'Normal User', 'Users with this role can draft and submit commodities transactions but are limited to transaction types based on their affiliated organization (Lead Agency). They can also delete draft transactions that they created.', 4),
(4, 'ReadOnly', 'Read-only User', '', 4),
(6, 'ParcelEditor', 'Parcel Editor', 'Users with this role have same permissions as Normal Users, but can also add parcels, update parcel information, add land capability records, and bank commodities.', 4),
(7, 'Unassigned', 'Unassigned', '', 4)