create table dbo.FundingTypeData
(
	FundingTypeDataID int not null identity(1,1) constraint PK_FundingTypeData_FundingTypeDataID primary key,
	TenantID int not null constraint FK_FundingTypeData_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	FundingTypeID int not null constraint FK_FundingTypeData_FundingType_FundingTypeID foreign key references dbo.FundingType (FundingTypeID),
	FundingTypeDisplayName varchar(100) not null,
	FundingTypeShortName varchar(20) not null,
	SortOrder int not null,
	constraint AK_FundingTypeData_FundingTypeID_TenantID unique (FundingTypeID, TenantID),
	constraint AK_FundingTypeData_FundingTypeDisplayName_TenantID unique (FundingTypeDisplayName, TenantID),
	constraint AK_FundingTypeData_FundingTypeShortName_TenantID unique (FundingTypeShortName, TenantID)
)
GO

insert into dbo.FundingTypeData(TenantID, FundingTypeID, FundingTypeDisplayName, FundingTypeShortName, SortOrder)
select t.TenantID, ft.FundingTypeID, ft.FundingTypeDisplayName, ft.FundingTypeShortName, ft.SortOrder
from dbo.FundingType ft
cross join dbo.Tenant t

update dbo.FundingTypeData
set FundingTypeDisplayName = 'One-time', FundingTypeShortName = 'One-time'
where TenantID = 3 and FundingTypeID = 1

update dbo.FundingTypeData
set FundingTypeDisplayName = 'Multi-year', FundingTypeShortName = 'Multi-year'
where TenantID = 3 and FundingTypeID = 2


alter table dbo.FundingType drop column FundingTypeShortName
alter table dbo.FundingType drop column SortOrder
alter table dbo.FundingType add constraint AK_FundingType_FundingTypeName unique (FundingTypeName)
alter table dbo.FundingType add constraint AK_FundingType_FundingTypeDisplayName unique (FundingTypeDisplayName)
