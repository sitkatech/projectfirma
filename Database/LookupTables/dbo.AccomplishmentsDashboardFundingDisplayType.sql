delete from dbo.AccomplishmentsDashboardFundingDisplayType
insert dbo.AccomplishmentsDashboardFundingDisplayType(AccomplishmentsDashboardFundingDisplayTypeID, AccomplishmentsDashboardFundingDisplayTypeName, AccomplishmentsDashboardFundingDisplayTypeDisplayName, SortOrder)
values
(1, 'AllFundingReceived', 'All Funding Received By An Organization', 10),
(2, 'OnlyFundingProvided', 'Only Funding Provided By An Organization', 20)
