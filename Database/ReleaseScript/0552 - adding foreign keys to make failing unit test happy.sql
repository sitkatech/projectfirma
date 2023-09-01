

alter table dbo.ExternalMapLayer 
add constraint FK_ExternalMapLayer_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID foreign key (MapLegendImageFileResourceInfoID, TenantID) references dbo.FileResourceInfo(FileResourceInfoID, TenantID)


alter table dbo.GeospatialAreaType add constraint FK_GeospatialAreaType_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID foreign key (MapLegendImageFileResourceInfoID, TenantID) references dbo.FileResourceInfo(FileResourceInfoID, TenantID)


alter table dbo.ProjectCustomGridConfiguration add constraint FK_ProjectCustomGridConfiguration_ClassificationSystem_ClassificationSystemID_TenantID foreign key (ClassificationSystemID, TenantID) references dbo.ClassificationSystem(ClassificationSystemID, TenantID)




