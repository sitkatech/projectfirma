drop table dbo.tmpGeospatial

CREATE TABLE [dbo].tmpGeospatial(
	[TenantID] [int] NOT NULL,
	[GeospatialAreaName] [varchar](100) NOT NULL,
	[GeospatialAreaFeature] [geometry] NULL,
	[GeospatialAreaTypeID] [int] NOT NULL,
	[GeospatialAreaDescriptionContent] [dbo].[html] NULL,
	[GeospatialAreaShortName] [varchar](200) NOT NULL,
	[ExternalID] [varchar](100) NULL,
	[LayerColor] [varchar](10) NULL
)

insert into dbo.tmpGeospatial (TenantID, GeospatialAreaName, GeospatialAreaFeature, GeospatialAreaTypeID, GeospatialAreaShortName)
select 
	14 as TenantID,
	'Not in a WUI Zone' as GeospatialAreaName,
	pr.GEOM as GeospatialAreaFeature,
	(select top 1 GeospatialAreaTypeID from dbo.GeospatialAreaType where TenantID = 14 and GeospatialAreaTypeName = 'WUI Zone') as GeospatialAreaTypeID,
	'Not in a WUI Zone' as GeospatialAreaShortName
from dbo.notInAWuiZone_Project as pr



select * from dbo.tmpGeospatial

/*


select * from dbo.GeospatialArea where GeospatialAreaTypeID = 28
select * from dbo.GeospatialAreaType

select * from dbo.Counties_Project
select * from dbo.Tenant

drop table dbo.Counties_Project

*/
