
delete from dbo.ResidentialAllocationType

insert into dbo.ResidentialAllocationType (ResidentialAllocationTypeID, ResidentialAllocationTypeName, ResidentialAllocationTypeCode, Description)
values 
(1, 'Original', 'O', 'Original'),
(2, 'Reissued', 'R', 'Reissued'),
(3, 'LitigationSettlement', 'LS', 'Litigation Settlement'),
(4, 'AllocationPool', 'AP', 'Allocation Pool')