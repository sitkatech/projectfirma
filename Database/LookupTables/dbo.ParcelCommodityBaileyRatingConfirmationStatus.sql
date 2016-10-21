delete from dbo.ParcelCommodityBaileyRatingConfirmationStatus
go

insert into dbo.ParcelCommodityBaileyRatingConfirmationStatus(ParcelCommodityBaileyRatingConfirmationStatusID, ParcelCommodityBaileyRatingConfirmationStatusName, DisplayName) 
values 
(1, 'ConfirmedComplete', 'Complete'),
(2, 'ConfirmedIncomplete', 'Incomplete'),
(3, 'UnconfirmedInventory', 'Unconfirmed')