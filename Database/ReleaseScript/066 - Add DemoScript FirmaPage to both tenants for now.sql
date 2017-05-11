insert into dbo.FirmaPage(FirmaPageTypeID, TenantID)
select 4 as FirmaPageTypeID, TenantID
from dbo.Tenant