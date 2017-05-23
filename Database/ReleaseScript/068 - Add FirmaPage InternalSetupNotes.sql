insert into dbo.FirmaPage(FirmaPageTypeID, TenantID)
select 5 as FirmaPageTypeID, TenantID
from dbo.Tenant