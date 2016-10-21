
delete from dbo.FundingType

insert dbo.FundingType (FundingTypeID, FundingTypeName, FundingTypeDisplayName, FundingTypeShortName, SortOrder) 
values 
(1, 'Capital', 'Capital', 'Capital', 10),
(2, 'OperationsAndMaintenance', 'Operations and Maintenance', 'O&M', 20)

