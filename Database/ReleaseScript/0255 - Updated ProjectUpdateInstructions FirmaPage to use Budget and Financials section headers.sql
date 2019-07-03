Update dbo.FirmaPage set FirmaPageContent = REPLACE(FirmaPageContent COLLATE Latin1_General_BIN, 'Expenditures', 'Financials')
where FirmaPageTypeID = 56 and TenantID != 11
Update dbo.FirmaPage set FirmaPageContent = REPLACE(FirmaPageContent, 'Expected Funding', 'Budget')
where TenantID = 11 and FirmaPageTypeID = 56
Update dbo.FirmaPage set FirmaPageContent = REPLACE(FirmaPageContent COLLATE Latin1_General_BIN, 'Expenditures (', 'Financials (')
where FirmaPageTypeID = 56 and TenantID != 11
