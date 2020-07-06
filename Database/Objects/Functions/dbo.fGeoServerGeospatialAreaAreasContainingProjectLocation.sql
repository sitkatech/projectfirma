IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.fGeoServerGeospatialAreaAreasContainingProjectLocation'))
drop function dbo.fGeoServerGeospatialAreaAreasContainingProjectLocation
GO
CREATE FUNCTION dbo.fGeoServerGeospatialAreaAreasContainingProjectLocation
(
    @piProjectID int,
    @pbIsProject bit,
    @piGeospatialAreaTypeID int null
)
RETURNS @GeospatialAreaTable TABLE
(
    GeospatialAreaID int not null,
    PrimaryKey int not null primary key,
    GeospatialAreaShortName varchar(100) not null,
    GeospatialAreaTypeID int not null
)
AS
BEGIN

    declare @viGeometry geometry, @viTenantID int
    if(@pbIsProject = 1)
    begin
        set @viGeometry = (select p.ProjectLocationPoint from dbo.Project p where p.ProjectID = @piProjectID)
        set @viTenantID = (select p.TenantID from dbo.Project p where p.ProjectID = @piProjectID)
    end
    else
     begin
        set @viGeometry = (select pu.ProjectLocationPoint from dbo.ProjectUpdate pu where pu.ProjectUpdateID = @piProjectID)
        set @viTenantID = (select pu.TenantID from dbo.ProjectUpdate pu where pu.ProjectUpdateID = @piProjectID)
    end
    

	INSERT @GeospatialAreaTable

    select ga.GeospatialAreaID
    ,       ga.GeospatialAreaID as PrimaryKey
    ,       ga.GeospatialAreaShortName
    ,       ga.GeospatialAreaTypeID
     from dbo.GeospatialArea ga
     where ga.TenantID = @viTenantID 
     and ga.GeospatialAreaFeature.STContains(@viGeometry) = 1
     and (ga.GeospatialAreaTypeID = isnull(@piGeospatialAreaTypeID,-1) or @piGeospatialAreaTypeID is null)
	RETURN
END
go
