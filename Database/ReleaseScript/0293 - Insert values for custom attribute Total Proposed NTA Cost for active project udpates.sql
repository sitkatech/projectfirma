DECLARE @pcaTypeID int;
Select @pcaTypeID = ProjectCustomAttributeTypeID from ProjectCustomAttributeType where ProjectCustomAttributeTypeName = 'Total Proposed NTA Cost';

if @pcaTypeID > 0
BEGIN 

insert into dbo.ProjectCustomAttributeUpdate (TenantID, ProjectUpdateBatchID, ProjectCustomAttributeTypeID) 
select pu.TenantID, pu.ProjectUpdateBatchID, @pcaTypeID
from dbo.ProjectUpdateBatch pu where pu.TenantID = 11

--get custom attribute value from ProjectCustomAttribute for the ProjectID associates with the ProjectUpdateBatchID
insert into dbo.ProjectCustomAttributeUpdateValue (TenantID, ProjectCustomAttributeUpdateID, AttributeValue)
select pcau.TenantID, pcau.ProjectCustomAttributeUpdateID, pcav.AttributeValue
from  dbo.ProjectCustomAttributeUpdate pcau join dbo.ProjectUpdateBatch pub on pub.ProjectUpdateBatchID = pcau.ProjectUpdateBatchID and pub.TenantID = pcau.TenantID
join dbo.Project p on p.ProjectID = pub.ProjectID and p.TenantID = pub.TenantID
join dbo.ProjectCustomAttribute pca on pca.ProjectID = p.ProjectID and pca.TenantID = p.TenantID and pca.ProjectCustomAttributeTypeID = @pcaTypeID
join dbo.ProjectCustomAttributeValue pcav on pcav.ProjectCustomAttributeID = pca.ProjectCustomAttributeID
where pcau.TenantID = 11 and pcau.ProjectCustomAttributeTypeID = @pcaTypeID

END