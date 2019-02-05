insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(55, 'UsersList', 'Users List', 1)

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select t.TenantID, 55, '<p>Users listed here all have Single Sign On (SSO) accounts provisioned by <a href="https://keystone.sitkatech.com">Sitka''s Keystone service</a>. To create a new account, end users must <a href="https://keystone.sitkatech.com/Account/Register">request an account</a>.</p>'
from dbo.Tenant t