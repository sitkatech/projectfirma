update FirmaPage
set FirmaPageContent = null
where FirmaPageContent like '<p>Users listed here all have Single Sign On (SSO)%'
GO