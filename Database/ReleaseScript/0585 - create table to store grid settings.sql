





create table dbo.PersonGridSetting (
	PersonGridSettingID int identity(1,1) not null constraint PK_PersonGridSetting_PersonGridSettingID primary key,
	TenantID int not null constraint FK_PersonGridSetting_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	PersonID int not null constraint FK_PersonGridSetting_Person_PersonID foreign key references dbo.Person(PersonID),
	GridName varchar(250) not null,
	FilterState nvarchar(max),
	ColumnState nvarchar(max)

)



alter table dbo.PersonGridSetting add constraint FK_PersonGridSetting_Person_PersonID_TenantID foreign key (PersonID, TenantID) references dbo.Person(PersonID, TenantID)

ALTER TABLE dbo.PersonGridSetting   
ADD CONSTRAINT AK_PersonGrisSetting_TenantID_PersonID_GridName UNIQUE (TenantID, PersonID, GridName);  