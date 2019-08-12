Alter Table dbo.GeospatialArea add GeospatialAreaDescriptionContent dbo.html null;

CREATE TABLE dbo.GeospatialAreaImage(
    GeospatialAreaImageID int not null identity(1,1) constraint PK_GeospatialAreaImage_GeospatialAreaImageID PRIMARY KEY,
    TenantID int not null constraint FK_GeospatialAreaImage_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
    GeospatialAreaID int not null constraint FK_GeospatialAreaImage_GeospatialArea_GeospatialAreaID foreign key references dbo.GeospatialArea(GeospatialAreaID),
    FileResourceID int not null constraint FK_GeospatialAreaImage_FileResource_FileResourceID foreign key references dbo.FileResource(FileResourceID),
    constraint AK_GeospatialAreaImage_GeospatialAreaImageID_FileResourceID unique(GeospatialAreaImageID, FileResourceID),
    constraint FK_GeospatialAreaImage_GeospatialArea_GeospatialAreaID_TenantID foreign key (GeospatialAreaID, TenantID) references dbo.GeospatialArea(GeospatialAreaID, TenantID),
    constraint [FK_GeospatialAreaImage_FileResource_FileResourceID_TenantID] foreign key (FileResourceID, TenantID) references dbo.FileResource(FileResourceID, TenantID),
);