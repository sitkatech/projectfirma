select *
from dbo.ProjectCustomAttribute pca
join dbo.ProjectCustomAttributeValue pcav on pcav.ProjectCustomAttributeID = pca.ProjectCustomAttributeID
where pca.ProjectCustomAttributeTypeID = 36


select pca.ProjectID, 36 as ProjectCustomAttributeTypeID, 'Yes' as AttributeValue
into #tmpPCA
from dbo.Project pca
where pca.ProjectID in
(
12909,
12923,
12983,
13044,
13103,
13118,
13183,
13212,
13237,
13257,
13288,
13302,
12848,
12862,
12872,
12920,
12925,
12947,
12985,
13030,
13085,
13100,
13202,
13339,
13343,
12821,
12863,
12906,
12907,
12922,
12929,
12943,
12944,
12988,
13043,
13049,
13115,
13127,
13168,
13182,
13190,
13199,
13204,
13232,
13241,
13242,
13330)

insert into dbo.ProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, TenantID)
select p.ProjectID, p.ProjectCustomAttributeTypeID, 11 as TenantID
from #tmpPCA p
left join dbo.ProjectCustomAttribute pca on p.ProjectID = pca.ProjectID and p.ProjectCustomAttributeTypeID = pca.ProjectCustomAttributeTypeID
where pca.ProjectCustomAttributeID is null

insert into dbo.ProjectCustomAttributeValue(ProjectCustomAttributeID, AttributeValue, TenantID)
select pca.ProjectCustomAttributeID, p.AttributeValue, 11 as TenantID
from #tmpPCA p
join dbo.ProjectCustomAttribute pca on p.ProjectID = pca.ProjectID and p.ProjectCustomAttributeTypeID = pca.ProjectCustomAttributeTypeID
left join dbo.ProjectCustomAttributeValue pcav on pcav.ProjectCustomAttributeID = pca.ProjectCustomAttributeID
where pcav.ProjectCustomAttributeValueID is null

select *
from dbo.ProjectCustomAttribute pca
join dbo.ProjectCustomAttributeValue pcav on pcav.ProjectCustomAttributeID = pca.ProjectCustomAttributeID
where pca.ProjectCustomAttributeTypeID = 36
