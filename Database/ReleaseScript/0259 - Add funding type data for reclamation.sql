insert into dbo.FundingTypeData(TenantID, FundingTypeID, FundingTypeDisplayName, FundingTypeShortName, SortOrder)
SELECT 12 as TenantID
	  ,FundingTypeID
	  ,FundingTypeDisplayName
	  ,FundingTypeShortName
	  ,SortOrder
FROM dbo.FundingTypeData
where TenantID = 4