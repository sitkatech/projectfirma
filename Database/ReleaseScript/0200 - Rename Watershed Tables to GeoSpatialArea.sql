update dbo.TenantAttribute
set WatershedLayerName = REPLACE(WatershedLayerName, 'Watershed', 'GeospatialArea')

exec sp_rename 'dbo.AK_Watershed_WatershedName_TenantID', 'AK_GeospatialArea_GeospatialAreaName_TenantID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershed_Project_ProjectID', 'FK_ProjectGeospatialArea_Project_ProjectID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershed_Project_ProjectID_TenantID', 'FK_ProjectGeospatialArea_Project_ProjectID_TenantID', 'OBJECT';
exec sp_rename 'dbo.PK_ProjectWatershed_ProjectWatershedID', 'PK_ProjectGeospatialArea_ProjectGeospatialAreaID', 'OBJECT';
exec sp_rename 'dbo.AK_ProjectWatershed_ProjectID_WatershedID', 'AK_ProjectGeospatialArea_ProjectID_GeospatialAreaID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershed_Tenant_TenantID', 'FK_ProjectGeospatialArea_Tenant_TenantID', 'OBJECT';
exec sp_rename 'dbo.PK_ProjectWatershedUpdate_ProjectWatershedUpdateID', 'PK_ProjectGeospatialAreaUpdate_ProjectGeospatialAreaUpdateID', 'OBJECT';
exec sp_rename 'dbo.AK_ProjectWatershedUpdate_ProjectUpdateBatchID_WatershedID', 'AK_ProjectGeospatialAreaUpdate_ProjectUpdateBatchID_GeospatialAreaID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershedUpdate_Tenant_TenantID', 'FK_ProjectGeospatialAreaUpdate_Tenant_TenantID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID', 'FK_ProjectGeospatialAreaUpdate_ProjectUpdateBatch_ProjectUpdateBatchID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershedUpdate_Watershed_WatershedID', 'FK_ProjectGeospatialAreaUpdate_GeospatialArea_GeospatialAreaID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID', 'FK_ProjectGeospatialAreaUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershedUpdate_Watershed_WatershedID_TenantID', 'FK_ProjectGeospatialAreaUpdate_GeospatialArea_GeospatialAreaID_TenantID', 'OBJECT';
exec sp_rename 'dbo.PK_PersonStewardWatershed_PersonStewardWatershedID', 'PK_PersonStewardGeospatialArea_PersonStewardGeospatialAreaID', 'OBJECT';
exec sp_rename 'dbo.AK_PersonStewardWatershed_PersonStewardWatershedID_TenantID', 'AK_PersonStewardGeospatialArea_PersonStewardGeospatialAreaID_TenantID', 'OBJECT';
exec sp_rename 'dbo.FK_PersonStewardWatershed_Tenant_TenantID', 'FK_PersonStewardGeospatialArea_Tenant_TenantID', 'OBJECT';
exec sp_rename 'dbo.FK_PersonStewardWatershed_Person_PersonID', 'FK_PersonStewardGeospatialArea_Person_PersonID', 'OBJECT';
exec sp_rename 'dbo.FK_PersonStewardWatershed_Watershed_WatershedID', 'FK_PersonStewardGeospatialArea_GeospatialArea_GeospatialAreaID', 'OBJECT';
exec sp_rename 'dbo.FK_PersonStewardWatershed_Person_PersonID_TenantID', 'FK_PersonStewardGeospatialArea_Person_PersonID_TenantID', 'OBJECT';
exec sp_rename 'dbo.FK_PersonStewardWatershed_WatershedID_TenantID', 'FK_PersonStewardGeospatialArea_GeospatialAreaID_TenantID', 'OBJECT';
exec sp_rename 'dbo.PK_Watershed_WatershedID', 'PK_GeospatialArea_GeospatialAreaID', 'OBJECT';
exec sp_rename 'dbo.AK_Watershed_WatershedID_TenantID', 'AK_GeospatialArea_GeospatialAreaID_TenantID', 'OBJECT';
exec sp_rename 'dbo.FK_Watershed_Tenant_TenantID', 'FK_GeospatialArea_Tenant_TenantID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershed_Watershed_WatershedID', 'FK_ProjectGeospatialArea_GeospatialArea_GeospatialAreaID', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectWatershed_Watershed_WatershedID_TenantID', 'FK_ProjectGeospatialArea_GeospatialArea_GeospatialAreaID_TenantID', 'OBJECT';
exec sp_rename 'dbo.ProjectWatershed.ProjectWatershedID', 'ProjectGeospatialAreaID', 'COLUMN';
exec sp_rename 'dbo.ProjectWatershed.WatershedID', 'GeospatialAreaID', 'COLUMN';
exec sp_rename 'dbo.ProjectWatershedUpdate.ProjectWatershedUpdateID', 'ProjectGeospatialAreaUpdateID', 'COLUMN';
exec sp_rename 'dbo.ProjectWatershedUpdate.WatershedID', 'GeospatialAreaID', 'COLUMN';
exec sp_rename 'dbo.PersonStewardWatershed.PersonStewardWatershedID', 'PersonStewardGeospatialAreaID', 'COLUMN';
exec sp_rename 'dbo.PersonStewardWatershed.WatershedID', 'GeospatialAreaID', 'COLUMN';
exec sp_rename 'dbo.TenantAttribute.WatershedLayerName', 'GeospatialAreaLayerName', 'COLUMN';
exec sp_rename 'dbo.Watershed.WatershedFeature', 'GeospatialAreaFeature', 'COLUMN';
exec sp_rename 'dbo.Watershed.WatershedID', 'GeospatialAreaID', 'COLUMN';
exec sp_rename 'dbo.Watershed.WatershedName', 'GeospatialAreaName', 'COLUMN';
exec sp_rename 'dbo.ProjectUpdateBatch.WatershedComment', 'GeospatialAreaComment', 'COLUMN';
exec sp_rename 'dbo.Project.ProjectWatershedNotes', 'ProjectGeospatialAreaNotes', 'COLUMN';
exec sp_rename 'dbo.ProjectUpdate.ProjectWatershedNotes', 'ProjectGeospatialAreaNotes', 'COLUMN';
exec sp_rename 'dbo.ProjectWatershed', 'ProjectGeospatialArea';
exec sp_rename 'dbo.ProjectWatershedUpdate', 'ProjectGeospatialAreaUpdate';
exec sp_rename 'dbo.PersonStewardWatershed', 'PersonStewardGeospatialArea';
exec sp_rename 'dbo.Watershed', 'GeospatialArea';

update fdd
set fdd.FieldDefinitionLabel = 'Watershed'
from dbo.FieldDefinition fd
join dbo.FieldDefinitionData fdd on fd.FieldDefinitionID = fdd.FieldDefinitionID
where fd.FieldDefinitionID = 48 and fdd.TenantID != 10

insert into dbo.FieldDefinitionData(FieldDefinitionID, TenantID, FieldDefinitionLabel)
select a.FieldDefinitionID,
a.TenantID,
'Watershed'	
from
(
	select *
	from dbo.FieldDefinition fd
	cross join dbo.Tenant t
	where fd.FieldDefinitionID = 48
) a
left join dbo.FieldDefinitionData fdd on a.FieldDefinitionID = fdd.FieldDefinitionID and a.TenantID = fdd.TenantID
where fdd.TenantID is null
order by TenantID