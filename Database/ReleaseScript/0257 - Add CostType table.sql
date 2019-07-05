
create table dbo.CostType (
	CostTypeID int not null identity(1,1) constraint PK_CostType_CostTypeID primary key,
	TenantID int not null constraint FK_CostType_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	CostTypeName varchar(100) not null constraint AK_CostType_TenantID_CostTypeName unique(TenantID, CostTypeName)
);
