CREATE TABLE [dbo].[ProjectCustomAttributeGroup](
    [ProjectCustomAttributeGroupID] int identity(1,1) not null constraint PK_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID primary key,
    [TenantID] [int] NOT NULL CONSTRAINT FK_ProjectCustomAttributeGroup_Tenant_TenantID FOREIGN KEY (TenantID) REFERENCES dbo.Tenant(TenantID),
    [ProjectCustomAttributeGroupName] [nvarchar](100) NULL,
    [SortOrder] [int] NULL,
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectCustomAttributeType]
ADD [ProjectCustomAttributeGroupID] [int] NULL CONSTRAINT FK_ProjectCustomAttributeType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID FOREIGN KEY (ProjectCustomAttributeGroupID) REFERENCES dbo.ProjectCustomAttributeGroup(ProjectCustomAttributeGroupID)

GO

-- create default group for each tenant
insert into ProjectCustomAttributeGroup (TenantID, ProjectCustomAttributeGroupName, SortOrder)
select 
    t.TenantID,
    case when fdd.FieldDefinitionLabel is not null then fdd.FieldDefinitionLabel + ' Custom Attributes' else 'Project Custom Attributes' end as GroupName,
    0
    from dbo.Tenant t 
    left join dbo.FieldDefinitionData fdd on t.TenantID = fdd.TenantID and fdd.FieldDefinitionID = 44

GO

-- set default group for each attribute type for tenant
update dbo.ProjectCustomAttributeType
set ProjectCustomAttributeGroupID = pcag.ProjectCustomAttributeGroupID
from dbo.ProjectCustomAttributeType pcat 
    left join dbo.ProjectCustomAttributeGroup pcag on pcat.TenantID = pcag.TenantID
where pcag.ProjectCustomAttributeGroupName like '%Custom Attributes%' and pcat.ProjectCustomAttributeGroupID is null

GO

-- set the projectCustomAttributeGroupID column to not null in the ProjectCustomAttributeType table
ALTER TABLE [dbo].[ProjectCustomAttributeType]
ALTER COLUMN [ProjectCustomAttributeGroupID] [int] NOT NULL