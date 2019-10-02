IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pGeospatialAreaIndexGridData'))
    drop procedure dbo.pGeospatialAreaIndexGridData
go
create procedure dbo.pGeospatialAreaIndexGridData
(
    @geospatialAreaTypeID int,
    @projectIdListViewableByUser dbo.IDList readonly
)
as
    select gsa.GeospatialAreaID,
           gsa.GeospatialAreaName,
           count(*) - 1 as ProjectCount
    from GeoSpatialArea gsa
    left join ProjectGeoSpatialArea pgsa on pgsa.GeospatialAreaID = gsa.GeospatialAreaID and pgsa.ProjectID IN (select ID from @projectIdListViewableByUser)
    where GeospatialAreaTypeID = @geospatialAreaTypeID
    group by gsa.GeospatialAreaID, gsa.GeospatialAreaName
go

/*
declare @geospatialAreaTypeID int;
set @geospatialAreaTypeID = 20;

-- Bulk load of ALL projects for Alevin tenant. This is more than we need, but a good test of data size.
declare  @projectIdListViewableByUser dbo.IDList;
insert into @projectIdListViewableByUser (ID) select p.ProjectID from dbo.Project as p where TenantID = 12

exec pGeospatialAreaIndexGridData @geospatialAreaTypeID, @projectIdListViewableByUser

*/







