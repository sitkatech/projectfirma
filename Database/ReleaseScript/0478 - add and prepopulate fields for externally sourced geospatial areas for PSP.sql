
-- Add field for optional ServiceUrl for externally-sourced geospatial area types
alter table dbo.GeospatialAreaType
add ServiceUrl varchar(1000) null
go

-- Prepopulate these for PSP
update dbo.GeospatialAreaType
set ServiceUrl = 'https://services7.arcgis.com/iAd79FjHxHKsLP0y/ArcGIS/rest/services/Legislative_Districts/FeatureServer/0/query?outFields=NAME%2C+GlobalID&where=1%3D1&f=geojson'
where GeospatialAreaTypeID = 13

update dbo.GeospatialAreaType
set ServiceUrl = 'https://services7.arcgis.com/iAd79FjHxHKsLP0y/ArcGIS/rest/services/Local_Areas/FeatureServer/0/query?outFields=NAME%2C+GlobalID&where=1%3D1&f=geojson'
where GeospatialAreaTypeID = 14

update dbo.GeospatialAreaType
set ServiceUrl = 'https://services7.arcgis.com/iAd79FjHxHKsLP0y/ArcGIS/rest/services/Lead_Entity_Area/FeatureServer/0/query?outFields=NAME%2C+GlobalID&where=1%3D1&f=geojson'
where GeospatialAreaTypeID = 18

update dbo.GeospatialAreaType
set ServiceUrl = 'https://services7.arcgis.com/iAd79FjHxHKsLP0y/ArcGIS/rest/services/Counties/FeatureServer/0/query?outFields=NAME%2C+GlobalID&where=1%3D1&f=geojson'
where GeospatialAreaTypeID = 19

--select * from GeospatialAreaType where TenantID = 11


-- Add an optional ExternalID field for externally-sourced Geospatial Areas to use as external foreign key
alter table dbo.GeospatialArea
add ExternalID varchar(100) null

-- Pre-populate ExternalID for PSP geospatialAreas
-- Create a temp table for reference
create table dbo.#galookup(
	GAName varchar(500) not null,
	ExternalID varchar(100) not null
)                       

-- Counties
insert into dbo.#galookup(GAName, ExternalID)
values 
('Clallam', '288a149c-0888-45ec-b7f9-5a87670ec9ab'),
('Island', '553081a5-fe5d-4bd3-93b6-35031fe42b96'),
('Jefferson', '0bb5e40c-4876-4842-a904-0d7757c381be'),
('King', '6843ce83-e92d-45b9-a20d-e225d4a622b0'),
('Kitsap', '32736173-1986-4781-84fc-d8a51a397e1f'),
('Lewis', '008a4647-612a-4d96-878f-b236b89172bf'),
('Mason', '57efff4f-ba73-40c2-a143-c4df52f0ca6d'),
('Pierce', '7b505519-771b-4d7b-8834-600953a910c4'),
('San Juan', '9300a5cc-40d2-42dc-a37b-74f9f4bee570'),
('Skagit', '1fccbf84-3bd5-45e0-a234-fd104499815b'),
('Snohomish', '02f51a0a-5587-4543-a10e-bc18ff2c53c0'),
('Thurston', '05312450-2505-46a4-b588-613546a533cf'),
('Whatcom', '6ca8aea0-1434-4800-ae1b-cd58d66977f5')


update dbo.GeospatialArea
set ExternalID = lu.ExternalID 
from GeospatialArea ga
join dbo.#galookup lu on ga.GeospatialAreaShortName = lu.GAName
where TenantID = 11 and GeospatialAreaTypeID = 19
go

--select * from dbo.GeospatialArea ga where TenantID = 11 and GeospatialAreaTypeID = 19

-- Lead Entity Areas
delete from dbo.#galookup

insert into dbo.#galookup(GAName, ExternalID)
values 
('North Olympic Peninsula', 'e36abea4-ee9d-483d-8a75-1cf53b3bce24'),
('Snohomish', 'ac741783-c321-4bb4-8bad-55663934c212'),
('Skagit', '8981ddb6-5d73-4f97-8258-ce643e30a1a4'),
('Pierce', '0ba650d4-3f55-4cb2-9c51-04598db818f3'),
('Deschutes', '13d58dd0-35a0-494d-ac5b-66138260c265'),
('Nisqually', '1f546f2f-64fe-4f96-86b2-d6552baba285'),
('Island', 'abd19eee-ff39-4889-b61d-8691c78e6cd6'),
('Cedar - Sammamish', '23a2330f-f877-4842-8795-8952355e6997'),
('West Sound', '2394dae8-6a1a-4bf2-b893-ff1ac2eb5be5'),
('Kennedy - Goldsborough', 'dbc9d3c1-1970-4b66-92cd-7383e161c101'),
('Duwamish - Green', '386b7c16-fddc-4791-8e42-b80df97e4f54'),
('San Juan', '47a9d3ac-d74e-477f-98dc-cd4ba5cba571'),
('Stillaguamish', '7e3c9593-fd5f-4631-b8cd-3ea24e6b2c85'),
('Nooksack', '448f9ca1-f4ea-4103-9265-f8d428d11d54'),
('Hood Canal', 'a77144bd-9e20-467d-a538-bba681b42708')
go

update dbo.GeospatialArea
set ExternalID = lu.ExternalID 
from GeospatialArea ga
join dbo.#galookup lu on ga.GeospatialAreaShortName = lu.GAName
where TenantID = 11 and GeospatialAreaTypeID = 18
go

--select * from dbo.GeospatialArea ga where TenantID = 11 and GeospatialAreaTypeID = 18

-- Legislative Districts
delete from dbo.#galookup

insert into dbo.#galookup(GAName, ExternalID)
values 
('Legislative District 01', '8b379c56-f84f-41cc-ac95-37e08f0c19f8'),
('Legislative District 02', 'fe72ac1a-3e39-49b5-8042-94d9cf3aa25b'),
('Legislative District 05', '3cc7469c-30bb-46b5-9445-51d08e3ca025'),
('Legislative District 10', '6b121ef5-b148-4961-95a3-4e29467098cc'),
('Legislative District 11', '160e3ea9-d761-4688-8513-048556834ba5'),
('Legislative District 20', 'b3b968f2-81a6-4f2a-9ac7-95d6ed12484f'),
('Legislative District 21', 'b2eaacd1-6a69-4850-bfeb-a092ab58e299'),
('Legislative District 22', '50342919-4c43-4047-b6d8-f05c45c132e6'),
('Legislative District 23', 'f5845904-61cc-4b5f-bc20-00d559e5f37e'),
('Legislative District 24', '3dd9cd6a-05aa-4d04-8446-7468ae40f6ec'),
('Legislative District 25', '2288dc26-f5d4-43c0-8b4c-f3cfc743d973'),
('Legislative District 26', '60b22a7c-dfbe-4a86-879b-b6dabc2e1998'),
('Legislative District 27', 'b4d83d75-b703-4222-8ce6-ade3d7ea5777'),
('Legislative District 28', 'e8bcb9d5-1ac1-4127-a198-e28ff2fd307e'),
('Legislative District 29', 'b69bf3e0-2ea7-4341-982f-7a8e17f517c6'),
('Legislative District 30', 'bb1ffe85-bd2e-4d5b-9bb7-7e97ddbdf785'),
('Legislative District 31', 'e940d6fb-379f-4689-b3c1-bd68de9cbf48'),
('Legislative District 32', '99ceee4f-72f6-4993-a43c-bd4330eead23'),
('Legislative District 33', '515aa445-23f0-4654-a01d-545a9cc1d6cc'),
('Legislative District 34', 'd9eea89e-52fd-4b6d-ab01-ab9375180238'),
('Legislative District 35', '8ebea7b8-99a9-4fbd-968c-a11296561eb4'),
('Legislative District 36', '49a925ef-9e67-47fb-bffd-5219c32fdd2f'), 
('Legislative District 37', 'ebe3b5f4-40d4-45cb-bcfb-94f28a0fcdcb'),
('Legislative District 38', 'd708934b-9288-4e1b-9f0d-db2c61b8e805'),
('Legislative District 39', 'e54d71e0-b6af-4b1e-b878-d7c6f36970d0'),
('Legislative District 40', 'e690c555-d46a-4d1e-a4c7-83d9502786b0'),
('Legislative District 41', 'b36f6548-eed9-49bc-93cd-8d422d966161'),
('Legislative District 42', 'f6336c89-27a8-450c-aa5d-2c6ae9799b3a'),
('Legislative District 43', '83d886eb-a12a-4e38-a389-cc28fef20bc0'),
('Legislative District 44', '4703e460-7208-4df3-b0a4-1c5599cad980'),
('Legislative District 45', '80ec0989-0555-4da4-83d3-8009bfc62123'),
('Legislative District 46', 'c5434658-aeaa-4df0-a9db-f4902b6407e2'),
('Legislative District 47', 'ae77cc08-911a-4428-acb5-e0093be86d7e'),
('Legislative District 48', 'f3473bf3-7a9d-4642-bd37-54f8f3ccc71d')

update dbo.GeospatialArea
set ExternalID = lu.ExternalID 
from GeospatialArea ga
join dbo.#galookup lu on ga.GeospatialAreaShortName = lu.GAName
where TenantID = 11 and GeospatialAreaTypeID = 13
go

--select * from dbo.GeospatialArea ga where TenantID = 11 and GeospatialAreaTypeID = 13

-- Local Areas
delete from dbo.#galookup

insert into dbo.#galookup(GAName, ExternalID)
values 
('Hood Canal', 'b8d5ebb6-b312-44bf-9578-3482b8c2465b'),
('West Central', 'c7ff179c-7010-4140-b1ef-13a5e6ff25a3'),
('Whatcom', 'bf14099a-1238-41f1-bd87-50ae4861ca98'),
('South Central', '02854f35-d5bc-4e93-a63d-562c4280f107'),
('South Sound', 'd413fc19-5049-4cb5-b54c-734df4c65cda'),
('Strait of Juan de Fuca', 'cc008204-5aed-4c20-a2c1-f16b495cb1c1'),
('Skagit / Samish', 'e6cd0919-d540-43f7-b8b6-e9658b591fd2'),
('San Juan', 'b16b18ec-1e01-441d-bc27-5c631aba8fe2'),
('Island', '49a19288-b844-4ca2-814f-0d79cea519f9'),
('Snohomish / Stillaguamish', '794c6210-9f42-4323-a3ee-33fd1858f203'),
('Puyallup / White', 'feacf64b-e839-4f1a-a7f4-92abeec1aa8a')

update dbo.GeospatialArea
set ExternalID = lu.ExternalID 
from GeospatialArea ga
join dbo.#galookup lu on ga.GeospatialAreaShortName = lu.GAName
where TenantID = 11 and GeospatialAreaTypeID = 14
go

--select * from dbo.GeospatialArea ga where TenantID = 11 and GeospatialAreaTypeID = 14

drop table dbo.#galookup

-- Firma page for instructions
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(85, 'ExternallySourcedGeospatialAreasInstructions', 'Externally Sourced Geospatial Areas Instructions', 1)
go

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(1, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(2, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(3, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(4, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(5, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(6, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(7, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(8, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(9, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(11, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>'),
(12, 85, '<p>The below Geospatial Areas are sourced from external web services. Please provide a query url that will return the following for each Geospatial Area:</p><ul><li><p>NAME field</p></li><li><p>GlobalID field</p></li><li><p>Geometry for each feature</p></li></ul>')