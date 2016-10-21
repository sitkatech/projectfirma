delete from dbo.Commodity
go

insert into dbo.Commodity(CommodityID, CommodityName, CommodityDisplayName, CommodityUnitTypeID, IsCoverage, CanHaveLandCapability, CommodityShortName, SortOrder, CanHaveCommodityPool) 
values 
(1, 'CommercialFloorArea', 'Commercial Floor Area (CFA)', 2, 0, 1, 'CFA', 7, 1),
(2, 'CoverageHard', 'Coverage (hard)', 2, 1, 1, 'Hard Cover.', 1, 0),
(3, 'CoverageSoft', 'Coverage (soft)', 2, 1, 1, 'Soft Cover.', 2, 0),
(4, 'CoveragePotential', 'Coverage (potential)', 2, 1, 1, 'Pot. Cover.', 3, 0),
(5, 'ExistingResidentialUnit', 'Existing Residential Unit (ERU)', 1, 0, 1, 'ERU', 4, 0),
(6, 'PersonsAtOneTime', 'Persons-at-one-time (PAOT)', 1, 0, 0, 'PAOT', 10, 1),
(7, 'ResidentialDevelopmentRight', 'Residential Development Right (RDR)', 1, 0, 0, 'RDR', 11, 0),
(8, 'ResidentialAllocation', 'Residential Allocation', 1, 0, 0, 'Res. Alloc.', 12, 1),
(9, 'ResidentialBonusUnit', 'Residential Bonus Unit (RBU)', 1, 0, 1, 'RBU', 5, 1),
(10, 'RestorationCredit', 'Restoration Credit', 1, 0, 0, 'Rest. Cred.', 13, 0),
(11, 'TouristAccommodationUnit', 'Tourist Accommodation Unit (TAU)', 1, 0, 1, 'TAU', 6, 1),
(12, 'ResidentialFloorArea', 'Residential Floor Area (RFA)', 2, 0, 1, 'RFA', 8, 0),
(13, 'TouristFloorArea', 'Tourist Floor Area (TFA)', 2, 0, 1, 'TFA', 9, 0)