-- To allow tenants to continue to steward projects by Organization under the new system
Create Table dbo.PersonStewardOrganization(
PersonStewardOrganizationID int not null identity(1,1) constraint PK_PersonStewardOrganization_PersonStewardOrganizationID primary key,
TenantID int not null constraint FK_PersonStewardOrganization_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
PersonID int not null constraint FK_PersonStewardOrganization_Person_PersonID foreign key references dbo.Person(PersonID),
OrganizationID int not null constraint FK_PersonStewardOrganization_Organization_OrganizationID foreign key references dbo.Organization(OrganizationID),
constraint AK_PersonStewardOrganization_PersonStewardOrganizationID_TenantID unique (PersonStewardOrganizationID, TenantID),
constraint FK_PersonStewardOrganization_Person_PersonID_TenantID foreign key (PersonID, TenantID) references dbo.Person(PersonID,TenantID),
constraint FK_PersonStewardOrganization_OrganizationID_TenantID foreign key (OrganizationID, TenantID) references dbo.Organization(OrganizationID, TenantID)
)

-- To enable tenants to steward projects by Taxonomy Branch
Create Table dbo.PersonStewardTaxonomyBranch(
PersonStewardTaxonomyBranchID int not null identity(1,1) constraint PK_PersonStewardTaxonomyBranch_PersonStewardTaxonomyBranchID primary key,
TenantID int not null constraint FK_PersonStewardTaxonomyBranch_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
PersonID int not null constraint FK_PersonStewardTaxonomyBranch_Person_PersonID foreign key references dbo.Person(PersonID),
TaxonomyBranchID int not null constraint FK_PersonStewardTaxonomyBranch_TaxonomyBranch_TaxonomyBranchID foreign key references dbo.TaxonomyBranch(TaxonomyBranchID),
constraint AK_PersonStewardTaxonomyBranch_PersonStewardTaxonomyBranchID_TenantID unique (PersonStewardTaxonomyBranchID, TenantID),
constraint FK_PersonStewardTaxonomyBranch_Person_PersonID_TenantID foreign key (PersonID, TenantID) references dbo.Person(PersonID,TenantID),
constraint FK_PersonStewardTaxonomyBranch_TaxonomyBranchID_TenantID foreign key (TaxonomyBranchID, TenantID) references dbo.TaxonomyBranch(TaxonomyBranchID, TenantID)
)

Create Table dbo.PersonStewardWatershed(
PersonStewardWatershedID int not null identity(1,1) constraint PK_PersonStewardWatershed_PersonStewardWatershedID primary key,
TenantID int not null constraint FK_PersonStewardWatershed_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
PersonID int not null constraint FK_PersonStewardWatershed_Person_PersonID foreign key references dbo.Person(PersonID),
WatershedID int not null constraint FK_PersonStewardWatershed_Watershed_WatershedID foreign key references dbo.Watershed(WatershedID),
constraint AK_PersonStewardWatershed_PersonStewardWatershedID_TenantID unique (PersonStewardWatershedID, TenantID),
constraint FK_PersonStewardWatershed_Person_PersonID_TenantID foreign key (PersonID, TenantID) references dbo.Person(PersonID,TenantID),
constraint FK_PersonStewardWatershed_WatershedID_TenantID foreign key (WatershedID, TenantID) references dbo.Watershed(WatershedID, TenantID)
)

GO

-- migrate existing stewardships
Insert into dbo.PersonStewardOrganization (TenantID, PersonID, OrganizationID)
select TenantID, PersonID, OrganizationID
from dbo.Person where RoleID = 9 -- Project Steward Role ID

-- lookup table tenant config
Create Table dbo.ProjectStewardshipAreaType(
ProjectStewardshipAreaTypeID int not null constraint PK_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeID primary key,
ProjectStewardshipAreaTypeName varchar(50) not null constraint AK_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeName unique,
ProjectStewardshipAreaTypeDisplayName varchar(50) not null constraint AK_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeDisplayName unique,
)
GO

Insert Into dbo.ProjectStewardshipAreaType (ProjectStewardshipAreaTypeID, ProjectStewardshipAreaTypeName, ProjectStewardshipAreaTypeDisplayName)
Values
(1,'ProjectStewardingOrganizations', 'Project Stewarding Organizations'),
(2,'TaxonomyBranches', 'Taxonomy Branches'),
(3,'Watershed', 'Watersheds')
GO

-- add Tenant Attributes and prepopulate
Alter Table dbo.TenantAttribute
Add ProjectStewardshipAreaTypeID int null
Go

Alter Table dbo.TenantAttribute
Add Constraint FK_TenantAttribute_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeID foreign key (ProjectStewardshipAreaTypeID) references dbo.ProjectStewardshipAreaType(ProjectStewardshipAreaTypeID)

Update dbo.TenantAttribute
set ProjectStewardshipAreaTypeID = 1 where TenantID = 3

Update dbo.TenantAttribute
set ProjectStewardshipAreaTypeID = 3 where TenantID = 10