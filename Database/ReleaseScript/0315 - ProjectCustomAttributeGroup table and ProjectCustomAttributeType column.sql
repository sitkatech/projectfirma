CREATE TABLE [dbo].[ProjectCustomAttributeGroup](
    [ProjectCustomAttributeGroupID] int identity(1,1) not null constraint PK_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID primary key,
    [TenantID] [int] NOT NULL CONSTRAINT FK_ProjectCustomAttributeGroup_Tenant_TenantID FOREIGN KEY (TenantID) REFERENCES dbo.Tenant(TenantID),
    [ProjectCustomAttributeGroupName] [nvarchar](100) NULL,
    [SortOrder] [int] NULL,
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectCustomAttributeType]
ADD [ProjectCustomAttributeGroupID] [int] NULL CONSTRAINT FK_ProjectCustomAttributeType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID FOREIGN KEY (ProjectCustomAttributeGroupID) REFERENCES dbo.ProjectCustomAttributeGroup(ProjectCustomAttributeGroupID)


-- create default group for each tenant
-- set default group for each attribute type for tenant
-- set the projectCustomAttributeGroupID column to not null in the ProjectCustomAttributeType table

