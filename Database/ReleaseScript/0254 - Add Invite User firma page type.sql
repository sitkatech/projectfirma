insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(59, 'InviteUser', 'Invite User', 1)

insert into dbo.FirmaPage(FirmaPageTypeID, TenantID)
select 59 as FirmaPageTypeID, TenantID
from dbo.Tenant