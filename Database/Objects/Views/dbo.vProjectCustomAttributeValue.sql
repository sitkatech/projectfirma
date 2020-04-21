if exists (select * from dbo.sysobjects where id = object_id('dbo.vProjectCustomAttributeValue'))
	drop view dbo.vProjectCustomAttributeValue
go
create view dbo.vProjectCustomAttributeValue
as
select pca.ProjectCustomAttributeID,
       pca.ProjectCustomAttributeID as PrimaryKey,
       pca.TenantID ,
       pca.ProjectID,
       pca.ProjectCustomAttributeTypeID,

              STUFF(
             (SELECT ', ' + cast(wse.AttributeValue as VARCHAR(1000))
              FROM dbo.ProjectCustomAttributeValue wse
              where wse.ProjectCustomAttributeID = pca.ProjectCustomAttributeID
              order by wse.AttributeValue
              FOR XML PATH ('')), 1, 1, '')  as ProjectCustomAttributeValuesConcatenated

from dbo.ProjectCustomAttribute pca

go

-- select * from dbo.vProjectCustomAttributeValue
