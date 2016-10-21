delete from dbo.ParcelLandCapabilityDeterminationType
go

insert into dbo.ParcelLandCapabilityDeterminationType(ParcelLandCapabilityDeterminationTypeID, ParcelLandCapabilityDeterminationTypeName, ParcelLandCapabilityDeterminationTypeDisplayName) 
values 
(1, 'Estimated', 'Estimated'),
(2, 'Verified', 'Verified')