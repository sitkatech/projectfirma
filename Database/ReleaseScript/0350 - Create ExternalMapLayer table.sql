
-- New table for External Map Layers
create table dbo.ExternalMapLayer(
	ExternalMapLayerID int not null identity(1,1) constraint PK_ExternalMapLayer_ExternalMapLayerID primary key,
	TenantID int not null constraint FK_ExternalMapLayer_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	DisplayName varchar(75) not null,
	LayerUrl varchar(500) not null,
	LayerDescription varchar(2000) null,
	FeatureNameField varchar(100) null,
	DisplayOnAllProjectMaps bit not null,
	LayerIsOnByDefault bit not null,
	IsActive bit not null,
	IsTiledMapService bit not null
);
go

alter table dbo.ExternalMapLayer
add constraint AK_ExternalMapLayer_TenantID_DisplayName unique(TenantID, DisplayName)

alter table dbo.ExternalMapLayer
add constraint AK_ExternalMapLayer_TenantID_LayerUrl unique(TenantID, LayerUrl)

-- Add Firma Page content to External map layers page
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(70, 'ExternalMapLayers', 'External Map Layers', 1)

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(1, 70, '<p>External map layers to add to maps.</p>'),
(2, 70, '<p>External map layers to add to maps.</p>'),
(3, 70, '<p>External map layers to add to maps.</p>'),
(4, 70, '<p>External map layers to add to maps.</p>'),
(5, 70, '<p>External map layers to add to maps.</p>'),
(6, 70, '<p>External map layers to add to maps.</p>'),
(7, 70, '<p>External map layers to add to maps.</p>'),
(8, 70, '<p>External map layers to add to maps.</p>'),
(9, 70, '<p>External map layers to add to maps.</p>'),
(11, 70, '<p>External map layers to add to maps.</p>'),
(12, 70, '<p>External map layers to add to maps.</p>')

select * from FirmaPage order by FirmaPageID desc

