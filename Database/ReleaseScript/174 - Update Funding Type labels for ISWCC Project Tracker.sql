update dbo.FundingTypeData SET FundingTypeDisplayName = 'One-time', FundingTypeShortName = 'One-time' 
WHERE TenantID = 9 AND FundingTypeID = 1;

update dbo.FundingTypeData SET FundingTypeDisplayName = 'Ongoing', FundingTypeShortName = 'Ongoing' 
WHERE TenantID = 9 AND FundingTypeID = 2;