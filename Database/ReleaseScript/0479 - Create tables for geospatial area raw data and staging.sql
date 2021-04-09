
create table dbo.GeospatialAreaStaging(
	GeospatialAreaStagingID int not null identity(1,1) constraint PK_GeospatialAreaStaging_GeospatialAreaStagingID primary key,
	TenantID int not null constraint FK_GeospatialAreaStaging_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	Name varchar(100) not null constraint AK_GeospatialAreaStaging_Name_TenantID unique (Name, TenantID),
	ExternalID varchar(100) not null constraint AK_GeospatialAreaStaging_ExternalID_TenantID unique (ExternalID, TenantID),
	Geometry geometry not null
);

create table dbo.GeospatialAreaRawData(
	GeospatialAreaRawDataID int not null identity(1,1) constraint PK_GeospatialAreaRawData_GeospatialAreaRawDataID primary key,
	TenantID int not null constraint FK_GeospatialAreaRawData_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	GeospatialAreaTypeID int not null constraint FK_GeospatialAreaRawData_GeospatialAreaType_GeospatialAreaTypeID foreign key references dbo.GeospatialAreaType(GeospatialAreaTypeID),
	ResultJson varchar(max) null
);

alter table dbo.GeospatialAreaRawData
add constraint AK_GeospatialAreaRawData_GeospatialAreaTypeID_TenantID unique(GeospatialAreaTypeID, TenantID)

-- Add geometry columns to geometry_columns table
insert into dbo.geometry_columns(f_table_catalog, f_table_schema, f_table_name, f_geometry_column, coord_dimension, srid, geometry_type)
values
('ProjectFirma', 'dbo', 'GeospatialAreaStaging', 'Geometry', 2, 4326, 'MULTIPOLYGON'),
('ProjectFirma', 'dbo', 'GeospatialArea', 'GeospatialAreaFeature', 2, 4326, 'MULTIPOLYGON')