
create table dbo.MatchmakerOrganizationTaxonomyBranch (
	MatchmakerOrganizationTaxonomyBranchID int identity(1,1) not null constraint PK_MatchmakerOrganizationTaxonomyBranch_MatchmakerOrganizationTaxonomyBranchID primary key,
	TenantID int not null constraint FK_MatchmakerOrganizationTaxonomyBranch_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	OrganizationID int not null constraint FK_MatchmakerOrganizationTaxonomyBranch_Organization_OrganizationID foreign key references dbo.Organization(OrganizationID),
	TaxonomyBranchID int not null constraint FK_MatchmakerOrganizationTaxonomyBranch_TaxonomyBranch_TaxonomyBranchID foreign key references dbo.TaxonomyBranch(TaxonomyBranchID),
	IsActive bit not null
)

alter table dbo.MatchmakerOrganizationTaxonomyBranch add constraint AK_MatchmakerOrganizationTaxonomyBranch_MatchmakerOrganizationTaxonomyBranchID_TenantID unique (MatchmakerOrganizationTaxonomyBranchID, TenantID) 
alter table dbo.MatchmakerOrganizationTaxonomyBranch add constraint FK_MatchmakerOrganizationTaxonomyBranch_Organization_OrganizationID_TenantID foreign key (OrganizationID, TenantID) references dbo.Organization(OrganizationID, TenantID)
alter table dbo.MatchmakerOrganizationTaxonomyBranch add constraint FK_MatchmakerOrganizationTaxonomyBranch_TaxonomyBranch_TaxonomyBranchID_TenantID foreign key (TaxonomyBranchID, TenantID) references dbo.TaxonomyBranch(TaxonomyBranchID, TenantID)

create table dbo.MatchmakerOrganizationTaxonomyTrunk (
	MatchmakerOrganizationTaxonomyTrunkID int identity(1,1) not null constraint PK_MatchmakerOrganizationTaxonomyTrunk_MatchmakerOrganizationTaxonomyTrunkID primary key,
	TenantID int not null constraint FK_MatchmakerOrganizationTaxonomyTrunk_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	OrganizationID int not null constraint FK_MatchmakerOrganizationTaxonomyTrunk_Organization_OrganizationID foreign key references dbo.Organization(OrganizationID),
	TaxonomyTrunkID int not null constraint FK_MatchmakerOrganizationTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID foreign key references dbo.TaxonomyTrunk(TaxonomyTrunkID),
	IsActive bit not null
)

alter table dbo.MatchmakerOrganizationTaxonomyTrunk add constraint AK_MatchmakerOrganizationTaxonomyTrunk_MatchmakerOrganizationTaxonomyTrunkID_TenantID unique (MatchmakerOrganizationTaxonomyTrunkID, TenantID) 
alter table dbo.MatchmakerOrganizationTaxonomyTrunk add constraint FK_MatchmakerOrganizationTaxonomyTrunk_Organization_OrganizationID_TenantID foreign key (OrganizationID, TenantID) references dbo.Organization(OrganizationID, TenantID)
alter table dbo.MatchmakerOrganizationTaxonomyTrunk add constraint FK_MatchmakerOrganizationTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID foreign key (TaxonomyTrunkID, TenantID) references dbo.TaxonomyTrunk(TaxonomyTrunkID, TenantID)

create table dbo.MatchmakerOrganizationTaxonomyLeaf (
	MatchmakerOrganizationTaxonomyLeafID int identity(1,1) not null constraint PK_MatchmakerOrganizationTaxonomyLeaf_MatchmakerOrganizationTaxonomyLeafID primary key,
	TenantID int not null constraint FK_MatchmakerOrganizationTaxonomyLeaf_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	OrganizationID int not null constraint FK_MatchmakerOrganizationTaxonomyLeaf_Organization_OrganizationID foreign key references dbo.Organization(OrganizationID),
	TaxonomyLeafID int not null constraint FK_MatchmakerOrganizationTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID foreign key references dbo.TaxonomyLeaf(TaxonomyLeafID),
	IsActive bit not null
)

alter table dbo.MatchmakerOrganizationTaxonomyLeaf add constraint AK_MatchmakerOrganizationTaxonomyLeaf_MatchmakerOrganizationTaxonomyLeafID_TenantID unique (MatchmakerOrganizationTaxonomyLeafID, TenantID) 
alter table dbo.MatchmakerOrganizationTaxonomyLeaf add constraint FK_MatchmakerOrganizationTaxonomyLeaf_Organization_OrganizationID_TenantID foreign key (OrganizationID, TenantID) references dbo.Organization(OrganizationID, TenantID)
alter table dbo.MatchmakerOrganizationTaxonomyLeaf add constraint FK_MatchmakerOrganizationTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID_TenantID foreign key (TaxonomyLeafID, TenantID) references dbo.TaxonomyLeaf(TaxonomyLeafID, TenantID)

