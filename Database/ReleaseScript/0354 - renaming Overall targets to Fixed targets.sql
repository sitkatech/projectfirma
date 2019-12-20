

--Rename GeospatialArea overall targets
--rename table
EXEC sp_rename 'dbo.GeospatialAreaPerformanceMeasureOverallTarget', 'GeospatialAreaPerformanceMeasureFixedTarget';
--rename ID column
EXEC sp_rename 'dbo.GeospatialAreaPerformanceMeasureFixedTarget.GeospatialAreaPerformanceMeasureOverallTargetID', 'GeospatialAreaPerformanceMeasureFixedTargetID', 'COLUMN';

--rename keys
EXEC sp_rename 'dbo.PK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialAreaPerformanceMeasureOverallTargetID', 'PK_GeospatialAreaPerformanceMeasureFixedTarget_GeospatialAreaPerformanceMeasureFixedTargetID';
EXEC sp_rename 'dbo.FK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialArea_GeospatialAreaID', 'FK_GeospatialAreaPerformanceMeasureFixedTarget_GeospatialArea_GeospatialAreaID';
EXEC sp_rename 'dbo.FK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialArea_GeospatialAreaID_TenantID', 'FK_GeospatialAreaPerformanceMeasureFixedTarget_GeospatialArea_GeospatialAreaID_TenantID';
EXEC sp_rename 'dbo.FK_GeospatialAreaPerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID', 'FK_GeospatialAreaPerformanceMeasureFixedTarget_PerformanceMeasure_PerformanceMeasureID';
EXEC sp_rename 'dbo.FK_GeospatialAreaPerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID_TenantID', 'FK_GeospatialAreaPerformanceMeasureFixedTarget_PerformanceMeasure_PerformanceMeasureID_TenantID';
EXEC sp_rename 'dbo.FK_GeospatialAreaPerformanceMeasureOverallTarget_Tenant_TenantID', 'FK_GeospatialAreaPerformanceMeasureFixedTarget_Tenant_TenantID';
EXEC sp_rename 'dbo.AK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialAreaPerformanceMeasureOverallTargetID_TenantID', 'AK_GeospatialAreaPerformanceMeasureFixedTarget_GeospatialAreaPerformanceMeasureFixedTargetID_TenantID';
EXEC sp_rename 'dbo.AK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialAreaID_PerformanceMeasureID', 'AK_GeospatialAreaPerformanceMeasureFixedTarget_GeospatialAreaID_PerformanceMeasureID';



--Rename PerformanceMeasure overall targets
--rename table
EXEC sp_rename 'dbo.PerformanceMeasureOverallTarget', 'PerformanceMeasureFixedTarget';
--rename ID column
EXEC sp_rename 'dbo.PerformanceMeasureFixedTarget.PerformanceMeasureOverallTargetID', 'PerformanceMeasureFixedTargetID', 'COLUMN';

--rename keys
EXEC sp_rename 'dbo.PK_PerformanceMeasureOverallTarget_PerformanceMeasureOverallTargetID', 'PK_PerformanceMeasureFixedTarget_PerformanceMeasureFixedTargetID';
EXEC sp_rename 'dbo.AK_PerformanceMeasureOverallTarget_PerformanceMeasureOverallTargetID_TenantID', 'AK_PerformanceMeasureFixedTarget_PerformanceMeasureFixedTargetID_TenantID';
EXEC sp_rename 'dbo.FK_PerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID', 'FK_PerformanceMeasureFixedTarget_PerformanceMeasure_PerformanceMeasureID';
EXEC sp_rename 'dbo.FK_PerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID_TenantID', 'FK_PerformanceMeasureFixedTarget_PerformanceMeasure_PerformanceMeasureID_TenantID';
EXEC sp_rename 'dbo.FK_PerformanceMeasureOverallTarget_Tenant_TenantID', 'FK_PerformanceMeasureFixedTarget_Tenant_TenantID';





--SELECT name, SCHEMA_NAME(schema_id) AS schema_name, type_desc, type  
--FROM sys.objects  
--WHERE parent_object_id = (OBJECT_ID('dbo.PerformanceMeasureOverallTarget'))   
--AND type IN ('C','F', 'PK', 'UQ');   
--GO  