

alter table dbo.ExternalMapLayer
add MapLegendImageFileResourceInfoID int null foreign key references dbo.FileResourceInfo(FileResourceInfoID)


alter table dbo.GeospatialAreaType
add MapLegendImageFileResourceInfoID int null foreign key references dbo.FileResourceInfo(FileResourceInfoID)