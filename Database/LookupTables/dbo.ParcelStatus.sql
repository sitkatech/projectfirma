
delete from dbo.ParcelStatus

insert into dbo.ParcelStatus(ParcelStatusID, ParcelStatusName, ParcelStatusDisplayName)
values
(1, 'Active', 'Active'),
(2, 'Inactive', 'Inactive'),
(3, 'Pending', 'Pending'),
(4, 'NotInAccela', 'Not in Accela')
