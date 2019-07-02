Update FirmaPage set FirmaPageContent = REPLACE(FirmaPageContent COLLATE Latin1_General_BIN, 'Expenditures', 'Financials')
where FirmaPageTypeID = 56
Update FirmaPage set FirmaPageContent = REPLACE(FirmaPageContent COLLATE Latin1_General_BIN, 'Expected Funding', 'Budget')
where TenantID = 11 and FirmaPageTypeID = 56
