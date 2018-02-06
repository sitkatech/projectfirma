insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values (49, 'Training','Training',2)

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID as TenantID,
49 as FirmaPageTypeID,
'' as FirmaPageContent
from Tenant