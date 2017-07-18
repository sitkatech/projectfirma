alter table dbo.Organization add OrganizationBoundary geometry null

create table dbo.OrganizationBoundaryStaging(
	OrganizationBoundaryStagingID int not null identity(1, 1) constraint PK_OrganizationBoundaryStaging_OrganizationBoundaryStagingID primary key,
	TenantID int not null constraint FK_OrganizationBoundaryStaging_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	OrganizationID int not null constraint FK_OrganizationBoundaryStaging_Organization_OrganizationID foreign key references dbo.Organization(OrganizationID),
	FeatureClassName varchar(255) not null,
	GeoJson varchar(max) not null,
	constraint FK_OrganizationBoundaryStaging_Organization_OrganizationID_TenantID foreign key (OrganizationID, TenantID) references dbo.Organization(OrganizationID, TenantID)
)
