insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(51, 'AccomplishmentsDashboardButtonAccomplishments', 'Accomplishments Dashboard Button Accomplishments', 1),
(52, 'AccomplishmentsDashboardButtonExpenditures', 'Accomplishments Dashboard Button Expenditures', 1),
(53, 'AccomplishmentsDashboardButtonOrganizations', 'Accomplishments Dashboard Button Organizations', 1)

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select
	TenantID,
	FirmaPageTypeID = 51, -- AccomplishmentsDashboardButtonAccomplishments
	FirmaPageContent = case when TenantName = 'RCDProjectTracker' then 'What type of work do<br/>RCDs do?' else null end
from dbo.Tenant

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select
	TenantID,
	FirmaPageTypeID = 52, -- AccomplishmentsDashboardButtonExpenditures
	FirmaPageContent = case when TenantName = 'RCDProjectTracker' then 'Where does RCD funding<br/>come from?' else null end
from dbo.Tenant

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select
	TenantID,
	FirmaPageTypeID = 53, -- AccomplishmentsDashboardButtonOrganizations
	FirmaPageContent = case when TenantName = 'RCDProjectTracker' then 'Who do RCDs<br/>work with?' else null end
from dbo.Tenant

