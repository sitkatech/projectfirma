create table dbo.AccomplishmentsDashboardFundingDisplayType (
	AccomplishmentsDashboardFundingDisplayTypeID int not null constraint PK_AccomplishmentsDashboardFundingDisplayType_AccomplishmentsDashboardFundingDisplayTypeID primary key,
	AccomplishmentsDashboardFundingDisplayTypeName varchar(100) not null constraint AK_AccomplishmentsDashboardFundingDisplayType_AccomplishmentsDashboardFundingDisplayTypeName unique,
	AccomplishmentsDashboardFundingDisplayTypeDisplayName varchar(100) not null constraint AK_AccomplishmentsDashboardFundingDisplayType_AccomplishmentsDashboardFundingDisplayTypeDisplayName unique,
	SortOrder int not null
)

insert dbo.AccomplishmentsDashboardFundingDisplayType(AccomplishmentsDashboardFundingDisplayTypeID, AccomplishmentsDashboardFundingDisplayTypeName, AccomplishmentsDashboardFundingDisplayTypeDisplayName, SortOrder)
values
(1, 'AllFundingReceived', 'All Funding Received By An Organization', 10),
(2, 'OnlyFundingProvided', 'Only Funding Provided By An Organization', 20)

go

alter table dbo.TenantAttribute add AccomplishmentsDashboardFundingDisplayTypeID int null
alter table dbo.TenantAttribute add AccomplishmentsDashboardAccomplishmentsButtonText html null
alter table dbo.TenantAttribute add AccomplishmentsDashboardExpendituresButtonText html null
alter table dbo.TenantAttribute add AccomplishmentsDashboardOrganizationsButtonText html null

go

alter table dbo.TenantAttribute
add constraint FK_TenantAttribute_AccomplishmentsDashboardFundingDisplayType_AccomplishmentsDashboardFundingDisplayTypeID
foreign key (AccomplishmentsDashboardFundingDisplayTypeID) references dbo.AccomplishmentsDashboardFundingDisplayType(AccomplishmentsDashboardFundingDisplayTypeID)

update ta
set
	AccomplishmentsDashboardFundingDisplayTypeID = case
		when t.TenantName = 'PeaksToPeople'
			then 2
			else 1
		end
from dbo.TenantAttribute ta
	join dbo.Tenant t on ta.TenantID = t.TenantID

go

alter table dbo.TenantAttribute alter column AccomplishmentsDashboardFundingDisplayTypeID int not null

update ta
set
	AccomplishmentsDashboardAccomplishmentsButtonText = 'What type of work do<br/>RCDs do?',
	AccomplishmentsDashboardExpendituresButtonText = 'Where does RCD funding<br/>come from?',
	AccomplishmentsDashboardOrganizationsButtonText = 'Who do RCDs<br/>work with?'
from dbo.TenantAttribute ta
	join dbo.Tenant t on ta.TenantID = t.TenantID
where
	t.TenantName = 'RCDProjectTracker' 

