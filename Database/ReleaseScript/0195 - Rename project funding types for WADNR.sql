Update dbo.FundingTypeData
set FundingTypeDisplayName = 'One-time', FundingTypeShortName='One-time'
where TenantID = 10 AND FundingTypeID = 1

Update dbo.FundingTypeData
set FundingTypeDisplayName = 'Ongoing', FundingTypeShortName='Ongoing'
where TenantID = 10 AND FundingTypeID = 2