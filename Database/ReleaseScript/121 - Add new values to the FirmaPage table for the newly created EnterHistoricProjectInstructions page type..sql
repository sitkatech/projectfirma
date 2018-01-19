INSERT INTO dbo.FirmaPageType
values (47, 'EnterHistoricProjectInstructions', 'Enter Historic Project Instructions', 2)

INSERT INTO dbo.FirmaPage
(TenantID, FirmaPageTypeID, FirmaPageContent)
SELECT 
	TenantID as TenantID,
	47 as FirmaPageTypeID,
	NULL as FirmaPageContent
from dbo.Tenant 