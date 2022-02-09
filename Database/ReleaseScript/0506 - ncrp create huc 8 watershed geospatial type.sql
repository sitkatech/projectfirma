

INSERT INTO [dbo].[GeospatialAreaType]
           ([TenantID]
           ,[GeospatialAreaTypeName]
           ,[GeospatialAreaTypeNamePluralized]
           ,[GeospatialAreaIntroContent]
           ,[GeospatialAreaTypeDefinition]
           ,[GeospatialAreaLayerName]
           ,[DisplayOnAllProjectMaps]
           ,[OnByDefaultOnProjectMap]
           ,[OnByDefaultOnOtherMaps]
           ,[ServiceUrl])
     VALUES
           (4
           ,'Watershed - HUC 8'
           ,'Watersheds - HUC 8'
           ,null
           ,null
           ,'NCRPProjectTracker:WatershedHuc8'
           ,1
           ,1
           ,1
           ,null)
GO


/*

select * from dbo.GeospatialAreaType where TenantID = 4

*/