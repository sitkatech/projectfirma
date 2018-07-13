
INSERT dbo.FundingSource ([TenantID], [FundingSourceName], [OrganizationID], [IsActive])
SELECT o.TenantID, 'District Funds' as FundingSourceName, o.OrganizationID, 1 as IsActive 
FROM dbo.Organization AS O
left JOIN dbo.FundingSource AS fs ON O.OrganizationID = fs.OrganizationID  and fs.FundingSourceName = 'District Funds'
WHERE O.TenantID = 9 and o.OrganizationTypeID = 57 and fs.FundingSourceID is null 
