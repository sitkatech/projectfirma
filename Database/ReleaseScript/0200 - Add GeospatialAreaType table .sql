 
CREATE TABLE dbo.GeospatialAreaType(
	GeospatialAreaTypeID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_GeospatialAreaType_GeospatialAreaTypeID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_GeospatialAreaType_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),
	GeospatialAreaTypeName varchar(200) NOT NULL,
	GeospatialAreaTypeNamePluralized varchar(200) NOT NULL,
	GeospatialAreaIntroContent dbo.html null,
	GeospatialAreaTypeDefinition dbo.html null
	CONSTRAINT AK_GeospatialAreaType_GeospatialAreaTypeID_TenantID UNIQUE (GeospatialAreaTypeID, TenantID),
	CONSTRAINT AK_GeospatialAreaType_GeospatialAreaTypeName_TenantID UNIQUE (GeospatialAreaTypeName, TenantID),
	CONSTRAINT AK_GeospatialAreaType_GeospatialAreaTypeNamePluralized_TenantID UNIQUE (GeospatialAreaTypeNamePluralized, TenantID)
)

alter table dbo.GeospatialArea add GeospatialAreaTypeID int null
alter table dbo.GeospatialArea add constraint FK_GeospatialArea_GeospatialAreaType_GeospatialAreaTypeID foreign key (GeospatialAreaTypeID) references dbo.GeospatialAreaType(GeospatialAreaTypeID)
alter table dbo.GeospatialArea add constraint FK_GeospatialArea_GeospatialAreaType_GeospatialAreaTypeID_TenantID foreign key (GeospatialAreaTypeID, TenantID) references dbo.GeospatialAreaType(GeospatialAreaTypeID, TenantID)
GO

INSERT INTO dbo.GeospatialAreaType (TenantID, GeospatialAreaTypeName, GeospatialAreaTypeNamePluralized, GeospatialAreaIntroContent)
Select fp.TenantID,
'Watershed' as GeospatialAreaTypeName,
'Watersheds' as GeospatialAreaTypeNamePluralized, 
fp.FirmaPageContent as GeospatialAreaIntroContent
from dbo.FirmaPage fp
where fp.FirmaPageTypeID = 17

update  gat
set gat.GeospatialAreaTypeDefinition = fdd.FieldDefinitionDataValue
from dbo.GeospatialAreaType gat
join FieldDefinitionData fdd on gat.TenantID = fdd.TenantID
where fdd.FieldDefinitionID = 48

update ga
set ga.GeospatialAreaTypeID = gat.GeospatialAreaTypeID
from dbo.GeospatialArea ga
join dbo.GeospatialAreaType gat on ga.TenantID = gat.TenantID and gat.GeospatialAreaTypeName = 'Watershed'

alter table dbo.GeospatialArea alter column GeospatialAreaTypeID int not null

delete from dbo.FieldDefinitionData 
where FieldDefinitionID = 48

delete from dbo.FirmaPage
where FirmaPageTypeID = 17